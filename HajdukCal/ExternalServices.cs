using System.Web;
using HajdukCal.Service;
using HajdukCal.Service.Hajduk;
using HajdukCal.Service.OpenStreetMap;
using Newtonsoft.Json;

namespace HajdukCal;

public static class ExternalServices
{
    private const string UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:96.0) Gecko/20100101 Firefox/96.0";

    private static readonly string? ScraperApiKey = Environment.GetEnvironmentVariable("SCRAPERAPI_KEY");

    private static HttpClient client;

    static ExternalServices()
    {
        client = new HttpClient();
        client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
        client.DefaultRequestHeaders.Add("Accept","application/json, text/plain, */*");
        client.DefaultRequestHeaders.Add("Accept-Language","hr-HR,hr;q=0.9,en-US;q=0.8,en;q=0.7");
    }

    // hajduk.hr sits behind Cloudflare, which blocks/challenges requests from
    // datacenter IP ranges (including GitHub Actions runners) regardless of client
    // (HttpClient and curl both get 403 from CI, even though both work fine from
    // a residential/dev network). A couple of direct retries handle transient
    // hiccups; if those still fail, route the request through ScraperAPI (a proxy
    // service with clean IPs) so CI keeps working. Requires SCRAPERAPI_KEY to be
    // set - if it isn't, the direct failure is rethrown as before.
    private static async Task<string> GetStringWithRetryAsync(string url, int maxAttempts = 2)
    {
        Exception? lastError = null;
        for (var attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                return await client.GetStringAsync(url);
            }
            catch (HttpRequestException ex)
            {
                lastError = ex;
                if (attempt < maxAttempts) await Task.Delay(TimeSpan.FromSeconds(Math.Pow(2, attempt)));
            }
        }

        if (string.IsNullOrEmpty(ScraperApiKey))
        {
            throw lastError!;
        }

        try
        {
            return await FetchWithScraperApiAsync(url);
        }
        catch (Exception)
        {
            throw lastError!;
        }
    }

    private static async Task<string> FetchWithScraperApiAsync(string url)
    {
        var proxiedUrl = $"https://api.scraperapi.com/?api_key={ScraperApiKey}&url={Uri.EscapeDataString(url)}";
        return await client.GetStringAsync(proxiedUrl);
    }

    public static async Task<Location?> FetchLocation(string location)
    {
        try
        {
            var json = await GetStringWithRetryAsync($"https://nominatim.openstreetmap.org/search.php?q={HttpUtility.UrlEncode(location)}&format=jsonv2");
            return Location.FromJson(json)?.FirstOrDefault() ?? default;
        }
        catch (Exception)
        {
            return default;
        }
    }

    public static async Task<Raspored> FetchNextMatches()
    {
        var json1 = await GetStringWithRetryAsync("https://hajduk.hr/json/ova_sezona/raspored.json");
        return RasporedResponse.FromJson(json1).Raspored;
    }

    public static async Task<IEnumerable<SveUtakmice2>> FetchPastMatches()
    {
        var json2 = await GetStringWithRetryAsync("https://hajduk.hr/json/ova_sezona/sve_utakmice.json");
        return RezultatiResponse.FromJson(json2).Utakmice.Select(i=>i.Utakmice).Where(i => i != null);
    }
}
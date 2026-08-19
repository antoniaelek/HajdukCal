using System.Diagnostics;
using System.Web;
using HajdukCal.Service;
using HajdukCal.Service.Hajduk;
using HajdukCal.Service.OpenStreetMap;
using Newtonsoft.Json;

namespace HajdukCal;

public static class ExternalServices
{
    private const string UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:96.0) Gecko/20100101 Firefox/96.0";

    private static HttpClient client;

    static ExternalServices()
    {
        client = new HttpClient();
        client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
        client.DefaultRequestHeaders.Add("Accept","application/json, text/plain, */*");
        client.DefaultRequestHeaders.Add("Accept-Language","hr-HR,hr;q=0.9,en-US;q=0.8,en;q=0.7");
    }

    // hajduk.hr sits behind Cloudflare, which sometimes serves a JS challenge to
    // System.Net.Http.HttpClient specifically (its TLS/HTTP fingerprint gets flagged)
    // even though an identical request via curl passes straight through with 200.
    // Retry a couple of times first (in case it's transient), then fall back to
    // shelling out to curl, which reliably isn't challenged.
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

        try
        {
            return await FetchWithCurlAsync(url);
        }
        catch (Exception)
        {
            throw lastError!;
        }
    }

    private static async Task<string> FetchWithCurlAsync(string url)
    {
        var psi = new ProcessStartInfo
        {
            FileName = "curl",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
        };
        psi.ArgumentList.Add("-sS");
        psi.ArgumentList.Add("-f");
        psi.ArgumentList.Add("-A");
        psi.ArgumentList.Add(UserAgent);
        psi.ArgumentList.Add(url);

        using var process = Process.Start(psi) ?? throw new InvalidOperationException("Failed to start curl");
        var stdoutTask = process.StandardOutput.ReadToEndAsync();
        var stderrTask = process.StandardError.ReadToEndAsync();
        await process.WaitForExitAsync();

        if (process.ExitCode != 0)
        {
            throw new InvalidOperationException($"curl exited with code {process.ExitCode}: {await stderrTask}");
        }

        return await stdoutTask;
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
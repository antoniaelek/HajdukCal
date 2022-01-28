using System.Web;
using HajdukCal.Service;
using HajdukCal.Service.Hajduk;
using HajdukCal.Service.OpenStreetMap;
using Newtonsoft.Json;

namespace HajdukCal;

public static class ExternalServices
{
    private static HttpClient client;
    
    static ExternalServices()
    {
        client = new HttpClient();
        client.DefaultRequestHeaders.Add("User-Agent","Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:96.0) Gecko/20100101 Firefox/96.0");
    }
    
    public static async Task<Location?> FetchLocation(string location)
    {
        var json = await client.GetStringAsync($"https://nominatim.openstreetmap.org/search.php?q={HttpUtility.UrlEncode(location)}&format=jsonv2");
        return Location.FromJson(json)?.FirstOrDefault() ?? default;
    }

    public static async Task<Raspored> FetchNextMatches()
    {
        var json1 = await client.GetStringAsync("https://hajduk.hr/json/ova_sezona/raspored.json");
        return RasporedResponse.FromJson(json1).Raspored;
    }
    
    public static async Task<IEnumerable<SveUtakmice2>> FetchPastMatches()
    {
        var json2 = await client.GetStringAsync("https://hajduk.hr/json/ova_sezona/sve_utakmice.json");
        return RezultatiResponse.FromJson(json2).Utakmice.Select(i=>i.Utakmice).Where(i => i != null);
    }
}
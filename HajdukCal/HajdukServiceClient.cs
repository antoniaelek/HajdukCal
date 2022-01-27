using HajdukCal.Service;

namespace HajdukCal;

public static class HajdukServiceClient
{
    public static async Task<Raspored> Fetch()
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri("https://hajduk.hr");
        var json = await client.GetStringAsync("/json/ova_sezona/raspored.json");
        return RasporedResponse.FromJson(json).Raspored;
    }
}
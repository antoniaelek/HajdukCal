using Newtonsoft.Json;

namespace HajdukCal.Service.OpenStreetMap;

public static class Serialize
{
    public static string ToJson(this List<Location> self) => JsonConvert.SerializeObject(self, HajdukCal.Service.OpenStreetMap.Converter.Settings);
}
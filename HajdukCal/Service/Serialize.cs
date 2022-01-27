using Newtonsoft.Json;

namespace HajdukCal.Service;

public static class Serialize
{
    public static string ToJson(this RasporedResponse self) => JsonConvert.SerializeObject(self, Converter.Settings);
}
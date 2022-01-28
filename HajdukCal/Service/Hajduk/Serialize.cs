using Newtonsoft.Json;

namespace HajdukCal.Service.Hajduk;

public static class Serialize
{
    public static string ToJson(this RezultatiResponse self) => JsonConvert.SerializeObject(self, Converter.Settings);
    public static string ToJson(this RasporedResponse self) => JsonConvert.SerializeObject(self, Converter.Settings);
}
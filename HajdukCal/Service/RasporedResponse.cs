using Newtonsoft.Json;

namespace HajdukCal.Service
{
    public partial class RasporedResponse
    {
        [JsonProperty("raspored")]
        public Raspored Raspored { get; set; }
    }

    public partial class RasporedResponse
    {
        public static RasporedResponse FromJson(string json) => JsonConvert.DeserializeObject<RasporedResponse>(json, Converter.Settings);
    }
}

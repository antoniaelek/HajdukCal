using Newtonsoft.Json;

namespace HajdukCal.Service.Hajduk;

public partial class Minutaza
{
    [JsonProperty("redni_broj")] public string RedniBroj { get; set; }

    [JsonProperty("igrac")] public string Igrac { get; set; }

    [JsonProperty("minutaze")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long Minutaze { get; set; }
}
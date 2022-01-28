using Newtonsoft.Json;

namespace HajdukCal.Service.Hajduk;

public partial class DomaceGostujuce
{
    [JsonProperty("period")] public string Period { get; set; }

    [JsonProperty("period_eng", NullValueHandling = NullValueHandling.Ignore)]
    public string PeriodEng { get; set; }

    [JsonProperty("gol_za")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long GolZa { get; set; }

    [JsonProperty("gol_protiv")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long GolProtiv { get; set; }

    [JsonProperty("postotak_za")] public string PostotakZa { get; set; }

    [JsonProperty("postotak_protiv")] public string PostotakProtiv { get; set; }

    [JsonProperty("ispis_postotak_za")] public string IspisPostotakZa { get; set; }

    [JsonProperty("ispis_postotak_protiv")]
    public string IspisPostotakProtiv { get; set; }
}
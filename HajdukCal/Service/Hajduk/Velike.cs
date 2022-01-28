using Newtonsoft.Json;

namespace HajdukCal.Service.Hajduk;

public partial class Velike
{
    [JsonProperty("tekst1")] public string Tekst1 { get; set; }

    [JsonProperty("tekst1_eng")] public string Tekst1Eng { get; set; }

    [JsonProperty("tekst2")] public string Tekst2 { get; set; }

    [JsonProperty("tekst2_eng")] public string Tekst2Eng { get; set; }

    [JsonProperty("period")] public string Period { get; set; }

    [JsonProperty("period_eng")] public string PeriodEng { get; set; }

    [JsonProperty("gol_za")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long GolZa { get; set; }

    [JsonProperty("gol_protiv")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long GolProtiv { get; set; }

    [JsonProperty("prosjek_golovi_za")] public string ProsjekGoloviZa { get; set; }

    [JsonProperty("prosjek_golovi_protiv")]
    public string ProsjekGoloviProtiv { get; set; }

    [JsonProperty("postotak_za")] public string PostotakZa { get; set; }

    [JsonProperty("postotak_protiv")] public string PostotakProtiv { get; set; }

    [JsonProperty("ispis_postotak_golovi_za")]
    public string IspisPostotakGoloviZa { get; set; }

    [JsonProperty("ispis_postotak_golovi_protiv")]
    public string IspisPostotakGoloviProtiv { get; set; }
}
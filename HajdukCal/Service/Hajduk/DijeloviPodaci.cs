using Newtonsoft.Json;

namespace HajdukCal.Service.Hajduk;

public partial class DijeloviPodaci
{
    [JsonProperty("br_utakmica")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long BrUtakmica { get; set; }

    [JsonProperty("br_pobjeda")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long BrPobjeda { get; set; }

    [JsonProperty("br_remija")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long BrRemija { get; set; }

    [JsonProperty("br_poraza")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long BrPoraza { get; set; }

    [JsonProperty("gol_razlika")] public string GolRazlika { get; set; }

    [JsonProperty("br_bodova")] public string BrBodova { get; set; }
}
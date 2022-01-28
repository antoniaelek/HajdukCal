using Newtonsoft.Json;

namespace HajdukCal.Service.Hajduk;

public partial class NatjecanjaPodaci
{
    [JsonProperty("br_utakmica")] public Br BrUtakmica { get; set; }

    [JsonProperty("br_pobjeda", NullValueHandling = NullValueHandling.Ignore)]
    public Br? BrPobjeda { get; set; }

    [JsonProperty("br_remija", NullValueHandling = NullValueHandling.Ignore)]
    public Br? BrRemija { get; set; }

    [JsonProperty("br_poraza", NullValueHandling = NullValueHandling.Ignore)]
    public Br? BrPoraza { get; set; }

    [JsonProperty("gol_razlika", NullValueHandling = NullValueHandling.Ignore)]
    public string GolRazlika { get; set; }

    [JsonProperty("prosjek_golova", NullValueHandling = NullValueHandling.Ignore)]
    public string ProsjekGolova { get; set; }

    [JsonProperty("br_gledatelja", NullValueHandling = NullValueHandling.Ignore)]
    public string BrGledatelja { get; set; }

    [JsonProperty("prosjek_po_utakmici", NullValueHandling = NullValueHandling.Ignore)]
    public string ProsjekPoUtakmici { get; set; }

    [JsonProperty("br_max", NullValueHandling = NullValueHandling.Ignore)]
    public string BrMax { get; set; }
}
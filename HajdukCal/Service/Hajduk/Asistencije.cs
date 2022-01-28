using Newtonsoft.Json;

namespace HajdukCal.Service.Hajduk;

public partial class Asistencije
{
    [JsonProperty("redni_broj")] public string RedniBroj { get; set; }

    [JsonProperty("igrac")] public string Igrac { get; set; }

    [JsonProperty("broj_golova")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long BrojGolova { get; set; }

    [JsonProperty("iz_penala")] public Rezultat4 IzPenala { get; set; }

    [JsonProperty("prosjek_po_utakmici")] public string ProsjekPoUtakmici { get; set; }

    [JsonProperty("prosjek_po_minuti")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long ProsjekPoMinuti { get; set; }
}
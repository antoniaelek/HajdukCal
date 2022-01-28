using Newtonsoft.Json;

namespace HajdukCal.Service.Hajduk;

public partial class Protivnici
{
    [JsonProperty("protivnik")] public string Protivnik { get; set; }

    [JsonProperty("rezultat_1")] public string Rezultat1 { get; set; }

    [JsonProperty("rezultat_2")] public string Rezultat2 { get; set; }

    [JsonProperty("rezultat_3")] public string Rezultat3 { get; set; }

    [JsonProperty("rezultat_4")] public Rezultat4 Rezultat4 { get; set; }

    [JsonProperty("broj_bodova")] public string BrojBodova { get; set; }
}
using Newtonsoft.Json;

namespace HajdukCal.Service.Hajduk;

public partial class Nastupi
{
    [JsonProperty("redni_broj")] public string RedniBroj { get; set; }

    [JsonProperty("igrac")] public string Igrac { get; set; }

    [JsonProperty("nastupio")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long Nastupio { get; set; }

    [JsonProperty("broj_nastupa_prv")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long BrojNastupaPrv { get; set; }

    [JsonProperty("broj_nastupa_kup")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long BrojNastupaKup { get; set; }

    [JsonProperty("broj_nastupa_eur")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long BrojNastupaEur { get; set; }

    [JsonProperty("broj_nastupa_spk")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long BrojNastupaSpk { get; set; }

    [JsonProperty("link_na_profil")] public string LinkNaProfil { get; set; }
}
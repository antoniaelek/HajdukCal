﻿using Newtonsoft.Json;

namespace HajdukCal.Service.Hajduk;

public partial class Strijelci
{
    [JsonProperty("redni_broj")] public string RedniBroj { get; set; }

    [JsonProperty("igrac")] public string Igrac { get; set; }

    [JsonProperty("igrac_eng")] public string IgracEng { get; set; }

    [JsonProperty("broj_golova")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long BrojGolova { get; set; }

    [JsonProperty("broj_golova_prv")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long BrojGolovaPrv { get; set; }

    [JsonProperty("broj_golova_kup")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long BrojGolovaKup { get; set; }

    [JsonProperty("broj_golova_eur")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long BrojGolovaEur { get; set; }

    [JsonProperty("broj_golova_spk")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long BrojGolovaSpk { get; set; }

    [JsonProperty("link_na_profil")] public string LinkNaProfil { get; set; }
}
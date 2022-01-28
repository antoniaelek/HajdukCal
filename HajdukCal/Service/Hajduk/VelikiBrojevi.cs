using Newtonsoft.Json;

namespace HajdukCal.Service.Hajduk;

public partial class VelikiBrojevi
{
    [JsonProperty("ukupno_utakmica")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long UkupnoUtakmica { get; set; }

    [JsonProperty("broj_pobjeda")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long BrojPobjeda { get; set; }

    [JsonProperty("prosjek_postignutih")] public string ProsjekPostignutih { get; set; }

    [JsonProperty("prosjek_postignutih_eng")]
    public string ProsjekPostignutihEng { get; set; }

    [JsonProperty("prosjecno_gledatelja")] public string ProsjecnoGledatelja { get; set; }

    [JsonProperty("prosjecno_gledatelja_eng")]
    public string ProsjecnoGledateljaEng { get; set; }

    [JsonProperty("ukupno_igraca")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long UkupnoIgraca { get; set; }

    [JsonProperty("prosjek_godina_pocetni_ukupno_eng")]
    public string ProsjekGodinaPocetniUkupnoEng { get; set; }

    [JsonProperty("prosjek_godina_pocetni_ukupno")]
    public string ProsjekGodinaPocetniUkupno { get; set; }
}
using Newtonsoft.Json;

namespace HajdukCal.Service.Hajduk;

public partial class SveUtakmice
{
    // [JsonProperty("nastupi_minutaza", NullValueHandling = NullValueHandling.Ignore)]
    // public List<NastupiMinutaza> NastupiMinutaza { get; set; }
    //
    // [JsonProperty("strijelci_asistencije", NullValueHandling = NullValueHandling.Ignore)]
    // public List<StrijelciAsistencije> StrijelciAsistencije { get; set; }
    //
    // [JsonProperty("velike", NullValueHandling = NullValueHandling.Ignore)]
    // public List<Velike> Velike { get; set; }
    //
    // [JsonProperty("poluvrijeme", NullValueHandling = NullValueHandling.Ignore)]
    // public List<DomaceGostujuce> Poluvrijeme { get; set; }
    //
    // [JsonProperty("domace_gostujuce", NullValueHandling = NullValueHandling.Ignore)]
    // public List<DomaceGostujuce> DomaceGostujuce { get; set; }
    //
    // [JsonProperty("periodi", NullValueHandling = NullValueHandling.Ignore)]
    // public List<DomaceGostujuce> Periodi { get; set; }

    [JsonProperty("sve_utakmice", NullValueHandling = NullValueHandling.Ignore)]
    public SveUtakmice2 Utakmice { get; set; }

    // [JsonProperty("ukupni_ucinak_graf", NullValueHandling = NullValueHandling.Ignore)]
    // public List<UkupniUcinakGraf> UkupniUcinakGraf { get; set; }
    //
    // [JsonProperty("rezultati_po_natjecanjima", NullValueHandling = NullValueHandling.Ignore)]
    // public RezultatiPoNatjecanjima RezultatiPoNatjecanjima { get; set; }
    //
    // [JsonProperty("veliki_brojevi", NullValueHandling = NullValueHandling.Ignore)]
    // public List<VelikiBrojevi> VelikiBrojevi { get; set; }
    //
    // [JsonProperty("protivnici_hnl", NullValueHandling = NullValueHandling.Ignore)]
    // public List<ProtivniciHnl> ProtivniciHnl { get; set; }
    //
    // [JsonProperty("hnl_ucinak", NullValueHandling = NullValueHandling.Ignore)]
    // public HnlUcinak HnlUcinak { get; set; }
}
using Newtonsoft.Json;

namespace HajdukCal.Service.Hajduk;

public partial class UkupniUcinakGraf
{
    [JsonProperty("naziv")] public string Naziv { get; set; }

    [JsonProperty("naziv_eng")] public string NazivEng { get; set; }

    [JsonProperty("broj")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long Broj { get; set; }

    [JsonProperty("postotak")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long Postotak { get; set; }
}
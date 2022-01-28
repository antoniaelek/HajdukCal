using Newtonsoft.Json;

namespace HajdukCal.Service.Hajduk;

public partial class Natjecanja
{
    [JsonProperty("natjecanje")] public string Natjecanje { get; set; }

    [JsonProperty("natjecanje_eng")] public string NatjecanjeEng { get; set; }

    [JsonProperty("podaci")] public List<NatjecanjaPodaci> Podaci { get; set; }
}
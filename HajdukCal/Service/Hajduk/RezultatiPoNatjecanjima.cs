using Newtonsoft.Json;

namespace HajdukCal.Service.Hajduk;

public partial class RezultatiPoNatjecanjima
{
    [JsonProperty("natjecanja")] public List<Natjecanja> Natjecanja { get; set; }
}
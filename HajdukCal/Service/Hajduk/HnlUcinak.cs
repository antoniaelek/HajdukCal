using Newtonsoft.Json;

namespace HajdukCal.Service.Hajduk;

public partial class HnlUcinak
{
    [JsonProperty("dijelovi")] public List<Dijelovi> Dijelovi { get; set; }
}
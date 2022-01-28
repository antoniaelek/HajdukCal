using Newtonsoft.Json;

namespace HajdukCal.Service.Hajduk;

public partial class ProtivniciHnl
{
    [JsonProperty("protivnici")] public List<Protivnici> Protivnici { get; set; }
}
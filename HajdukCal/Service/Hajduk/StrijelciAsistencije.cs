using Newtonsoft.Json;

namespace HajdukCal.Service.Hajduk;

public partial class StrijelciAsistencije
{
    [JsonProperty("strijelci", NullValueHandling = NullValueHandling.Ignore)]
    public List<Strijelci> Strijelci { get; set; }

    [JsonProperty("asistencije", NullValueHandling = NullValueHandling.Ignore)]
    public List<Asistencije> Asistencije { get; set; }
}
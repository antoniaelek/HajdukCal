using Newtonsoft.Json;

namespace HajdukCal.Service.Hajduk;

public partial class NastupiMinutaza
{
    [JsonProperty("nastupi", NullValueHandling = NullValueHandling.Ignore)]
    public List<Nastupi> Nastupi { get; set; }

    [JsonProperty("minutaza", NullValueHandling = NullValueHandling.Ignore)]
    public List<Minutaza> Minutaza { get; set; }
}
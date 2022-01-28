using Newtonsoft.Json;

namespace HajdukCal.Service.Hajduk;

public partial class Dijelovi
{
    [JsonProperty("dio")] public string Dio { get; set; }

    [JsonProperty("dio_eng")] public string DioEng { get; set; }

    [JsonProperty("podaci")] public List<DijeloviPodaci> Podaci { get; set; }
}
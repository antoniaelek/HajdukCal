using Newtonsoft.Json;

namespace HajdukCal.Service.Hajduk;

public partial class ProtekliMisec
{
    [JsonProperty("misec")] public string Misec { get; set; }

    [JsonProperty("misec_eng")] public string MisecEng { get; set; }

    [JsonProperty("utakmice")] public List<OdigranaUtakmica> Utakmice { get; set; }

    public int GetYear()
    {
        var split = MisecEng.Split(' ');
        if (split.Length != 2)
        {
            throw new Exception($"Unknown month: {MisecEng}");
        }

        if (int.TryParse(split[1], out var year)) return year;

        throw new Exception($"Unknown month: {MisecEng}");
    }
}
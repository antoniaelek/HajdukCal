using Newtonsoft.Json;

namespace HajdukCal.Service;

public class Misec
{
    [JsonProperty("misec")]
    public string MisecHrv { get; set; }

    [JsonProperty("misec_eng")]
    public string MisecEng { get; set; }

    [JsonProperty("utakmice")]
    public List<Utakmica> Utakmice { get; set; }

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
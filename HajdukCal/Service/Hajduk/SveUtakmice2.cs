using Newtonsoft.Json;

namespace HajdukCal.Service.Hajduk;

public partial class SveUtakmice2
{
    [JsonProperty("miseci")] public List<ProtekliMisec> Miseci { get; set; }

    public DTO.Raspored ToDTO()
    {
        var utakmice = new List<DTO.Utakmica>();
        foreach (var misec in Miseci)
        {
            foreach (var utakmica in misec.Utakmice)
            {
                utakmice.Add(utakmica.ToDTO(misec));
            }
        }

        return new DTO.Raspored
        {
            Utakmice = utakmice
        };
    }
}
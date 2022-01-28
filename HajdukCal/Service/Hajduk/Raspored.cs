using Newtonsoft.Json;

namespace HajdukCal.Service.Hajduk;

public class Raspored
{
    [JsonProperty("miseci")] public List<BuduciMisec> Miseci { get; set; }

    public async Task<DTO.Raspored> ToDTO()
    {
        var utakmice = new List<DTO.Utakmica>();
        
        foreach (var misec in Miseci)
        {
            foreach (var utakmica in misec.Utakmice)
            {
                utakmice.Add(await utakmica.ToDTO(misec));
            }
        }

        return new DTO.Raspored()
        {
            Utakmice = utakmice
        };
    }
}
namespace HajdukCal.Service.Hajduk
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public partial class RezultatiResponse
    {
        [JsonProperty("sve_utakmice")] public List<SveUtakmice> Utakmice { get; set; }
    }

    public partial class RezultatiResponse
    {
        public static RezultatiResponse FromJson(string json) =>
            JsonConvert.DeserializeObject<RezultatiResponse>(json, Converter.Settings);
    }
}
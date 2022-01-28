using HajdukCal.DTO;

namespace HajdukCal.Service.OpenStreetMap
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public partial class Location
    {
        [JsonProperty("place_id")]
        public long PlaceId { get; set; }

        [JsonProperty("licence")]
        public string Licence { get; set; }

        [JsonProperty("osm_type")]
        public OsmType OsmType { get; set; }

        [JsonProperty("osm_id")]
        public long OsmId { get; set; }

        [JsonProperty("boundingbox")]
        public List<string> Boundingbox { get; set; }

        [JsonProperty("lat")]
        public string Lat { get; set; }

        [JsonProperty("lon")]
        public string Lon { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("place_rank")]
        public long PlaceRank { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("importance")]
        public double Importance { get; set; }

        [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Icon { get; set; }

        public DTO.Mjesto ToDTO()
        {
            return new Mjesto()
            {
                Naziv = DisplayName,
                Lat = double.TryParse(Lat, out var lat) ? lat : default,
                Long = double.TryParse(Lon, out var lon) ? lon : default
            };
        }
    }

    public partial class Location
    {
        public static List<Location> FromJson(string json) => JsonConvert.DeserializeObject<List<Location>>(json, HajdukCal.Service.OpenStreetMap.Converter.Settings);
    }
}

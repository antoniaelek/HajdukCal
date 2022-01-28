using System.Globalization;
using HajdukCal.DTO;
using Newtonsoft.Json;

namespace HajdukCal.Service.Hajduk;

public class BuducaUtakmica
{
    [JsonProperty("id")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long Id { get; set; }

    [JsonProperty("protivnik")]
    public string Protivnik { get; set; }

    [JsonProperty("datum")]
    public string Datum { get; set; }

    [JsonProperty("datum_eng")]
    public string DatumEng { get; set; }

    [JsonProperty("natjecanje")]
    public Natjecanje Natjecanje { get; set; }

    [JsonProperty("opis")]
    public string Opis { get; set; }

    [JsonProperty("opis_eng")]
    public string OpisEng { get; set; }

    [JsonProperty("dg")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long Dg { get; set; }

    [JsonProperty("mjesto")]
    public string Mjesto { get; set; }

    [JsonProperty("stadion")]
    public Stadion Stadion { get; set; }

    [JsonProperty("stadion_eng")]
    public StadionEng StadionEng { get; set; }

    [JsonProperty("natjecanje_eng")]
    public NatjecanjeEng NatjecanjeEng { get; set; }

    public async Task<Utakmica> ToDTO(BuduciMisec buduciMisec)
    {
        DateOnly? gameDate = default;
        TimeOnly? gameTime = default;
        var datetime = DatumEng.Split('-');
        if (datetime.Length == 2)
        {
            if (DateOnly.TryParseExact(datetime[0] + buduciMisec.GetYear(), "MMM d yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
            {
                gameDate = date;
            }

            if (TimeOnly.TryParseExact(datetime[1].TrimStart().TrimEnd('h'), "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out var time))
            {
                gameTime = time;
            }
        }
        
        var location = await ExternalServices.FetchLocation(Mjesto);
        var mjesto = location?.ToDTO() ?? new Mjesto(){Naziv = Mjesto};
        
        return new Utakmica()
        {
            Naziv = Protivnik,
            Natjecanje = Natjecanje.ToDTO(),
            Stadion = Stadion.ToDTO(),
            Opis = Opis,
            Mjesto = mjesto,
            Datum = gameDate,
            Vrijeme = gameTime
        };
    }
}
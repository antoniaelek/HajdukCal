using HajdukCal.DTO;
using Ical.Net;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;

namespace HajdukCal;

public static class CalendarGenerator
{
    public static string Serialize(this Calendar calendar)
    {
        return new CalendarSerializer().SerializeToString(calendar);
    }

    public static async Task<Calendar> Get()
    {
        var raspored = await ExternalServices.FetchNextMatches();
        var raspoerdDto = await raspored.ToDTO();

        var rezultati = await ExternalServices.FetchPastMatches();
        var rezultatiDto = rezultati.Select(r => r.ToDTO());

        var all = new List<Raspored>();
        all.AddRange(rezultatiDto);
        all.Add(raspoerdDto);

        return Get(all);
    }
    
    private static Calendar Get(IEnumerable<DTO.Raspored> rasporedi)
    {
        var calendar = new Calendar();

        foreach (var raspored in rasporedi)
        {
            foreach (var utakmica in raspored.Utakmice)
            {
                if (!utakmica.Datum.HasValue) continue;

                var startTime = utakmica.Vrijeme ?? new TimeOnly(17, 0);
                var start = new DateTime(
                    utakmica.Datum.Value.Year,
                    utakmica.Datum.Value.Month,
                    utakmica.Datum.Value.Day,
                    startTime.Hour,
                    startTime.Minute,
                    0);

                var calendarEvent = new CalendarEvent
                {
                    Summary = $"{utakmica.Naziv} ({utakmica.Natjecanje.ToString().ToLower()}, {utakmica.Opis})",
                    Description = $"{utakmica.Natjecanje}, {utakmica.Opis}\n{utakmica.Naziv}",
                    Start = new CalDateTime(start, "HR"),
                    End = new CalDateTime(start.AddHours(2), "HR"),
                };
            
                if (utakmica.Mjesto?.Naziv != null)
                {
                    calendarEvent.Location = utakmica.Mjesto.Naziv;
                }
            

                if (utakmica.Mjesto?.Lat != null)
                {
                    calendarEvent.GeographicLocation = new GeographicLocation(utakmica.Mjesto.Lat, utakmica.Mjesto.Long);
                }
            
                calendar.Events.Add(calendarEvent);
            }
        }

        return calendar;
    }
}
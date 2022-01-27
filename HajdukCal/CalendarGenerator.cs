using Ical.Net;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;

namespace HajdukCal;

public static class CalendarGenerator
{
    public static string GetSerialized(DTO.Raspored raspored)
    {
        return new CalendarSerializer().SerializeToString(Get(raspored));
    }
    
    public static Calendar Get(DTO.Raspored raspored)
    {
        var calendar = new Calendar();

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

            calendar.Events.Add(new CalendarEvent
            {
                Summary = $"{utakmica.Naziv} ({utakmica.Natjecanje.ToString().ToLower()}, {utakmica.Opis})",
                Description = $"{utakmica.Natjecanje}, {utakmica.Opis}\n{utakmica.Naziv}",
                Start = new CalDateTime(start),
                End = new CalDateTime(start.AddHours(2)),
            });
        }

        return calendar;
    }
}
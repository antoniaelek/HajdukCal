using HajdukCal;

var calendar = await CalendarGenerator.Get("Hajdukov kalendar", "Kalendar utakmica Hajduk Split");

File.WriteAllText(@"hajduk_cal.ics", calendar.Serialize());
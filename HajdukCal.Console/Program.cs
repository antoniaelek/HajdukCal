using HajdukCal;

var calendar = await CalendarGenerator.Get();

File.WriteAllText(@"cal.ics", calendar.Serialize());
// See https://aka.ms/new-console-template for more information

using HajdukCal;

var timetable = (await HajdukServiceClient.Fetch()).ToDTO();
var serializedCalendar = CalendarGenerator.GetSerialized(timetable);

File.WriteAllText(@"cal.ics", serializedCalendar);
using HygieiaApp.Models;
using HygieiaApp.Models.Models;
using LiteDB;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace HygieiaApp.Utility.Utils.CalendarHelper;

public class JsonHelper
{
    public static string GetEventListJson(List<Scheduler> events)
    {
        var jsonEvents = new List<Event>();
        var id = 1;
        events.ForEach(e =>
        {
            var eventModel = new Event()
            {
                id = e.Id.ToString(),
                start = e.DateOfAppointment,
                end = e.EndDate,
                description = e.Reminder,
                resourceId = e.PatientId,
                title = e.Reminder
            };
            id++;
            jsonEvents.Add(eventModel);
        });
        return JsonSerializer.Serialize(jsonEvents);
    }

    public static string GetResouceListJson(List<ApplicationUser> patients)
    {
        var jsonResources = new List<Resouce>();
        var id = 1;
        patients.ForEach(e =>
        {
            var eventModel = new Resouce()
            {
                id = id,
                title = e.FirstName + " " + e.LastName
            };
            id++;
            jsonResources.Add(eventModel);
        });
        return JsonSerializer.Serialize(jsonResources);
    }
}

public class Event
{
    public string id { get; set; }
    public DateTime start { get; set; }
    public DateTime end { get; set; }
    public string resourceId { get; set; }
    public string description { get; set; }
    public string title { get; set; }
}

public class Resouce
{
    public int id { get; set; }
    public string title { get; set; }
}
using HygieiaApp.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Azure.Cosmos;

namespace HygieiaApp.Models.DTO;

public class EventUserDto
{
    public Scheduler Scheduler { get; set; }
    public string? UserId { get; set; }
    public List<SelectListItem> Patents { get; set; } = new List<SelectListItem>();

    public EventUserDto(Scheduler myScheduler, List<ApplicationUser> patients)
    {
        Scheduler = myScheduler;
        UserId = myScheduler.PatientId;
        patients.ForEach(patient => Patents.Add(new SelectListItem()
        {
            Text = patient.FirstName + " " + patient.LastName,
            Value = patient.Id
        }));
    }
    
    public EventUserDto( List<ApplicationUser> patients)
    {
        Scheduler = new Scheduler();
        patients.ForEach(patient => Patents.Add(new SelectListItem()
        {
            Text = patient.FirstName + " " + patient.LastName,
            Value = patient.Id
        }));
    }

    public EventUserDto()
    {
        
    }
}
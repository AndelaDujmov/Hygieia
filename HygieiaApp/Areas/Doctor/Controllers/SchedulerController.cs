using HygieiaApp.DataAccess.Data;
using HygieiaApp.DataAccess.Repositories;
using HygieiaApp.Models.DTO;
using HygieiaApp.Models.Enums;
using HygieiaApp.Models.Models;
using HygieiaApp.Utility.Utils.CalendarHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace HygieiaApp.Areas.Doctor;

[Area(("Doctor"))]
public class SchedulerController : Controller
{
    private readonly DoctorService _service;
    private readonly AdminService _adminService;

    public SchedulerController(DoctorService doctorService, AdminService adminService)
    {
        _service = doctorService;
        _adminService = adminService;
     }
    [Authorize]
    public IActionResult Index()
    {

        ViewData["Resources"] =
            JsonHelper.GetResouceListJson(_service.ReturnUsers(_service.GetCurrentUser(HttpContext.User)));
        
        var currentUser = _adminService.GetUserById(_service.GetCurrentUser(HttpContext.User));
        
        
        var scheduler = _service.GetAllEvents(_service.GetCurrentUser(HttpContext.User));
        ViewData["Events"] = JsonHelper
            .GetEventListJson(_service.GetAllEvents(_service.GetCurrentUser(HttpContext.User)).ToList());
        
        
        return View(scheduler);
    }

    [HttpGet]
    public IActionResult Details(string id)
    {
        
        var scheduledEvent = _service.GetEventById(Guid.Parse((ReadOnlySpan<char>)id));

        var patientData = _adminService.GetUserById(scheduledEvent.PatientId);
         
        var eventData = new
        {
            id = scheduledEvent.Id,
            title = scheduledEvent.Reminder,
            start = scheduledEvent.DateOfAppointment.ToString("f"),
            end = scheduledEvent.EndDate.ToString("f"),
            patient = patientData.FirstName + " " + patientData.LastName
        };
        
        return Content(JsonConvert.SerializeObject(eventData), "application/json");

        return Json(scheduledEvent);
    }
    
    
    [Authorize(Roles = "Doctor")]
    public IActionResult Create()
    {
        var model = new EventUserDto(_service.ReturnAllDoctorsPatients(_service.GetCurrentUser(HttpContext.User))
            .ToList()); 
        model.Scheduler = new Scheduler();
        return View(model);
    }

    [HttpPost]
    [Authorize(Roles = "Doctor")]
    [ValidateAntiForgeryToken]
    public IActionResult Create(EventUserDto model)
    {
        model.Scheduler.DoctorId = _service.GetCurrentUser(HttpContext.User);   
        if (model is not null)
        {
            if (model.Scheduler.DateOfAppointment.Date<DateTime.Now)
            {
                TempData["error"] = "Unable to book an appointment in the past!";
                return RedirectToAction("Create");
            }

            if (_service.CheckIfDateIsBooked(model.Scheduler.DateOfAppointment, model.Scheduler.DoctorId))
            {
                TempData["error"] = "Term already booked!";
                return RedirectToAction("Create");
            }
                
            _service.AddEvent(model.Scheduler);
            var currentUser = _adminService.GetUserById(_service.GetCurrentUser(HttpContext.User));
            var fullname = currentUser.FirstName + " " + currentUser.LastName;
            _service.SendEmail(fullname, currentUser.Email, _adminService.GetUserById(model.Scheduler.PatientId).Email, 
                "Appointment term", $"Dear {_adminService.GetUserById(model.Scheduler.PatientId).FirstName},\n Your doctor's appointment has been scheduled to {model.Scheduler.DateOfAppointment.ToLongDateString()}.\nYours truly,\nHygieia team");
            TempData["success"] = "Successfully created event!";
        }
        else
            TempData["error"] = "Data input error.";
        return RedirectToAction("Index");
    }

    [Authorize]
    public IActionResult Edit(Guid id)
    {
        var model = new EventUserDto(_service.ReturnAllDoctorsPatients(_service.GetCurrentUser(HttpContext.User))
            .ToList());
        model.Scheduler = _service.ReturnEventById(id);
        return View(model);
    }

   /*[Authorize]
    public IActionResult Edit(EventUserDto model)
    {
        
    }*/
}
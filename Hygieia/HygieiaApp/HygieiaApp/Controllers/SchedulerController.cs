using HygieiaApp.DataAccess.Data;
using HygieiaApp.DataAccess.Repositories;
using HygieiaApp.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace HygieiaApp.Controllers;

public class SchedulerController : Controller
{
    private readonly IEventRepository _eventRepository;

    public SchedulerController(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }
    public IActionResult Index()
    {
        var scheduler = _eventRepository.GetAll();
        return View(scheduler);
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Scheduler scheduler)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _eventRepository.Add(scheduler);
                TempData["success"] = "Event created succesfully.";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["error"] = "Unable to create event due to error.";
                return View(e.Message);
            }
        }

        return View(scheduler);
    }
}
using HygieiaApp.Data;
using HygieiaApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HygieiaApp.Controllers;

public class SchedulerController : Controller
{
    private readonly AppDbContext _appDb = new AppDbContext();
    public IActionResult Index()
    {
        var scheduler = _appDb.Schedulers;
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
                _appDb.Schedulers.Add(scheduler);
                _appDb.SaveChanges();
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
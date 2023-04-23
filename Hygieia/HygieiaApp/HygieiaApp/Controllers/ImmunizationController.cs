using HygieiaApp.Data;
using HygieiaApp.Models;
using HygieiaApp.Utils.DTO;
using Microsoft.AspNetCore.Mvc;

namespace HygieiaApp.Controllers;

public class ImmunizationController : Controller
{
    private readonly AppDbContext _appDb = new AppDbContext();
    public List<ImmunizationDto> _immunizationDtos = new List<ImmunizationDto>();

    public ImmunizationController()
    {
        
    }
    
    public IActionResult Index()
    {
        return View(_immunizationDtos);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(ImmunizationDto immunization)
    {
        if (ModelState.IsValid)
        {
            try
            {
                TempData["success"] = "Immunization created succesfully.";
                _immunizationDtos.Add(immunization);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["error"] = "Unable to create immunization due to error";
                return View(e.Message);
            }
        }

        TempData["success"] = "Unable to create immunization with invalid model.";
        return View(immunization);
    }
    
    public IActionResult Edit(string Type)
    {
        
        var immunization = _immunizationDtos.FirstOrDefault(x => x.Type == Type);

        if (immunization is null)
        {
            TempData["error"] = "Immunization does not exist.";
            return NotFound();
        }

        return View(immunization);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(ImmunizationDto immunization)
    {

        if (ModelState.IsValid)
        {
            try
            {
                TempData["success"] = "Immunization created succesfully.";
              
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["error"] = "Unable to create immunization due to error";
                return View(e.Message);
            }
        }

        TempData["success"] = "Unable to create immunization with invalid model.";
        return View(immunization);
    }

    public IActionResult Delete(string type)
    {
        var element = _immunizationDtos.FirstOrDefault(x => x.Type == type);

        if (element is null)
        {
            TempData["error"] = "Unable to create immunization with invalid model.";
            return NotFound();
        }

        TempData["success"] = "Succesfully removed.";
        _immunizationDtos.Remove(element);
        return RedirectToAction("Index");
    }
    
   
}
using HygieiaApp.DataAccess.Data;
using HygieiaApp.DataAccess.Repositories;
using HygieiaApp.Models.Models;
using HygieiaApp.Utility.Utils;
using Microsoft.AspNetCore.Mvc;

namespace HygieiaApp.Areas.Doctor;

[Area(("Doctor"))]
public class ImmunizationController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    public List<ImmunizationDto> _immunizationDtos = new List<ImmunizationDto>();
    public List<string> TypeImmunization { get; set; } = new List<string>();
    public List<string> UsedForImmunization { get; set; } = new List<string>();

    public ImmunizationController(IUnitOfWork vaccineRepository)
    {
        _unitOfWork = vaccineRepository;
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
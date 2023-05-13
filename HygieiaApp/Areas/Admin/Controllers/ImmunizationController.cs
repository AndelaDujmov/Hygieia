using HygieiaApp.DataAccess.Repositories.Impl;
using HygieiaApp.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HygieiaApp.Areas.Admin;

[Area(("Admin"))]
public class ImmunizationController : Controller
{
    private readonly UnitOfWork _unitOfWork;
    public List<string> ImmunizationType { get; set; } = new List<string>();
    
    public ImmunizationController(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [IgnoreAntiforgeryToken]
    public IActionResult Create(Immunization immunization)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _unitOfWork.VaccineRepository.Add(immunization);
                ImmunizationType.Add(immunization.Type);
                _unitOfWork.Save();
                TempData["success"] = "Successfully added!";
                return RedirectToAction("");
            }
            catch (Exception e)
            {
                TempData["error"] = "Unable to add due to error!";
                return View(e.Message);
            }
        }

        return View(immunization);
    }
}
using HygieiaApp.DataAccess.Repositories;
using HygieiaApp.DataAccess.Repositories.Impl;
using HygieiaApp.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HygieiaApp.Areas.Admin;

[Area(("Admin"))]
public class ImmunizationController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    public List<string> ImmunizationType { get; set; } = new List<string>();
    
    public ImmunizationController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        var immunizations = _unitOfWork.VaccineRepository.GetAll();
        return View(immunizations);
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
    
    public IActionResult Edit(Guid? id)
    {
        if (id is null)
        {
            TempData["error"] = "Unable to edit immunization due to unknown id.";
            return NotFound();
        }

        var medicalcond = _unitOfWork.VaccineRepository.Get(x=> x.Id == id);

        if (medicalcond is null)
        {
            TempData["error"] = "Unable to update empty data.";
            return NotFound();
        }
            
        
        return View(medicalcond);
    }
    
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Immunization immunization)
    {

        if (ModelState.IsValid)
        {
            try
            {
                _unitOfWork.VaccineRepository.Update(immunization);
                _unitOfWork.Save();
                TempData["success"] = "Immunization edited succesfully.";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["error"] = "Unable to edit immunization due to error.";
                return View(e.Message);
            }
        }

        return View(immunization);
    }
}
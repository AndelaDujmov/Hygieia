using HygieiaApp.DataAccess.Data;
using HygieiaApp.DataAccess.Repositories;
using HygieiaApp.DataAccess.Repositories.Impl;
using HygieiaApp.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace HygieiaApp.Areas.Admin;

[Area(("Admin"))]
public class MedicationController : Controller
{
    private readonly IUnitOfWork _medicationRepository;

    public MedicationController(IUnitOfWork medicationRepository)
    {
        _medicationRepository = medicationRepository;
    }
    
    public IActionResult Index()
    {
        var medication = _medicationRepository.MedicationRepository.GetAll();
        return View(medication);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Medication medication)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _medicationRepository.MedicationRepository.Add(medication);
                _medicationRepository.Save();
                TempData["success"] = "Medication created succesfully.";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["error"] = "Unable to create medication due to error";
                return View(e.Message);
            }
        }

        TempData["error"] = "Unable to create medication with invalid parameter.";
        return View(medication);
    }
    
    public IActionResult Edit(Guid? id)
    {
        var medication = _medicationRepository.MedicationRepository.Get(x => x.Id == id);

        if (medication is null)
        {
            TempData["error"] = "Unable to create medication with invalid parameter.";
            return NotFound();
        }

        return View(medication);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Medication medication)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _medicationRepository.MedicationRepository.Update(medication);
                _medicationRepository.Save();
                TempData["success"] = "Medication updated succesfully.";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["error"] = "Unable to update medication due to error";
                return View(e.Message);
            }
        }

        TempData["error"] = "Unable to update medication with invalid parameter.";
        return View(medication);
    }
    
    
    public IActionResult Delete(Guid? id)
    {
        var medication = _medicationRepository.MedicationRepository.Get(x=> x.Id==id);
        
        
        if (medication is null)
        {
            TempData["error"] = "Unable to get medication with invalid parameter.";
            return NotFound();
        }

        return View(medication);
    }

    [HttpPost]
    public IActionResult DeletePost(Medication medication)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _medicationRepository.MedicationRepository.Delete(medication);
                _medicationRepository.Save();
                TempData["success"] = "Medication deleted succesfully.";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["error"] = "Unable to delete medication due to error";
                return View(e.Message);
            }
        }

        TempData["success"] = "Unable to delete medication with invalid parameter.";
        return RedirectToAction("Index");
    }
}
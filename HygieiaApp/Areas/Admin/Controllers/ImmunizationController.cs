using HygieiaApp.DataAccess.Repositories;
using HygieiaApp.DataAccess.Repositories.Impl;
using HygieiaApp.Models.Enums;
using HygieiaApp.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HygieiaApp.Areas.Admin;

[Area(("Admin"))]
public class ImmunizationController : Controller
{
    private readonly AdminService _service;

    public ImmunizationController(AdminService service)
    {
        _service = service;
    }

    [Authorize]
    public IActionResult Index()
    {
        var immunizations = _service.ReturnAllVaccinations();
        return View(immunizations);
    }
    
    [Authorize(Roles = "Administrator")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    [IgnoreAntiforgeryToken]
    public IActionResult Create(Immunization immunization)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _service.CreateVaccination(immunization);
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
    
    [Authorize(Roles = "Administrator")]
    public IActionResult Edit(Guid? id)
    {
        if (id is null)
        {
            TempData["error"] = "Unable to edit immunization due to unknown id.";
            return NotFound();
        }

        var medicalcond = _service.GetVaccineById(id);

        if (medicalcond is null)
        {
            TempData["error"] = "Unable to update empty data.";
            return NotFound();
        }
        
        return View(medicalcond);
    }
    
    
    [HttpPost]
    [Authorize(Roles = "Administrator")]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Immunization immunization)
    {

        if (ModelState.IsValid)
        {
            try
            {
                _service.UpdateVaccination(immunization);
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
    
    [Authorize(Roles = "Administrator")]
    public IActionResult Delete(Guid? id)
    {
        if (id is null)
            return NotFound();

        var immunization = _service.GetVaccineById(id);
        
        
        if (immunization is null)
            return NotFound();

        return View(immunization);
    }

    [HttpPost, ActionName("Delete")]
    [Authorize(Roles = "Administrator")]
    public IActionResult DeletePost(Guid? id)
    {
        var immunization = _service.GetVaccineById(id);

        if (immunization.Equals(null))
        {
            TempData["error"] = "Unable to get medication with invalid parameter.";
            return NotFound();
        }

        _service.DeleteVaccination(immunization);
        TempData["success"] = "Medication deleted succesfully.";
        return RedirectToAction("Index");
    }
}
using HygieiaApp.DataAccess.Data;
using HygieiaApp.DataAccess.Repositories;
using HygieiaApp.DataAccess.Repositories.Impl;
using HygieiaApp.Models;
using HygieiaApp.Models.DTO;
using HygieiaApp.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Exception = System.Exception;


namespace HygieiaApp.Areas.Admin;

[Area(("Admin"))]
public class MedicationController : Controller
{
    private readonly AdminService _service;

    public MedicationController(AdminService service)
    {
        _service = service;
    }
    
    [Authorize]
    public IActionResult Index()
    {
        var medication = _service.ReturnAllMedications();
        return View(medication);
    }

    [Authorize]
    public IActionResult Create()
    {
        return View();
    }

    [Authorize(Roles = "Administrator")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Medication medication)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _service.CreateMedication(medication);
                TempData["success"] = "Created Medication!";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["error"] = "Unable to create medication due to error";
                return View();
            }
        }
        
        TempData["error"] = "Model not valid!";
        return RedirectToAction("Index");
        
    }
    
   
    [Authorize(Roles = "Administrator")]
    public IActionResult Edit(Guid? id)
    {
        var medication = _service.GetMedicationById(id);

        if (medication is null)
        {
            TempData["error"] = "Unable to create medication with invalid parameter.";
            return NotFound();
        }

        return View(medication);
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Medication medication)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _service.UpdateMedication(medication);
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
    [Authorize]
    public IActionResult Info(Guid? id)
    {
        var medication = _service.GetMedicationById(id);

        if (medication is null)
        {
            TempData["error"] = "Unable to create medication with invalid parameter.";
            return NotFound();
        }

        return View(medication);
    }

    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public IActionResult Info(Medication medication)
    {
        return View(medication);
    }
    
    public IActionResult Delete(Guid? id)
    {
        if (id is null)
            return NotFound();

        var medication = _service.GetMedicationById(id);
        
        if (medication is null)
            return NotFound();

        return View(medication);
    }

    [Authorize(Roles = "Administrator")]
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePost(Guid? id)
    {
        var medication = _service.GetMedicationById(id);

        if (medication.Equals(null))
        {
            TempData["error"] = "Unable to get medication with invalid parameter.";
            return NotFound();
        }
        
        _service.DeleteMedication(medication);
        
        TempData["success"] = "Medication deleted succesfully.";
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult GetAllRemoved()
    {
        var medications = _service.ReturnAllDeletedMedications();
        return medications == null || !medications.Any() ? RedirectToAction("NotFoundData", "MedicalCondition") : View(medications);
    }
    
    [Authorize(Roles = "Administrator")]
    public IActionResult UndoMedication(Guid id)
    {
        _service.UndoMedication(id);
        TempData["success"] = "Medication successfully readded!";
        return RedirectToAction("GetAll");
    }
    
    #region DATA_CALLS

    [HttpGet]
    public IActionResult GetAll()
    {
        IEnumerable<Medication> medications = _service.ReturnAllMedications();
        return Json(new { data = medications });
    }
    
    [HttpGet]
    public IActionResult GetAllDeleted()
    {
        IEnumerable<Medication> medications = _service.ReturnAllDeletedMedications();
        return Json(new { data = medications });
    }
    #endregion
}
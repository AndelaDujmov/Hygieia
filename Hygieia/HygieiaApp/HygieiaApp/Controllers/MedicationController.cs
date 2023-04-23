using HygieiaApp.Data;
using HygieiaApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HygieiaApp.Controllers;

public class MedicationController : Controller
{
    private readonly AppDbContext _appDb = new AppDbContext();
    public IActionResult Index()
    {
        var medication = _appDb.Medications;
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
                _appDb.Add(medication);
                _appDb.SaveChanges();
                TempData["success"] = "Medication created succesfully.";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["error"] = "Unable to create medication due to error";
                return View(e.Message);
            }
        }

        TempData["success"] = "Unable to create medication with invalid parameter.";
        return View(medication);
    }
    
    public IActionResult Edit(Guid? id)
    {
        var medication = _appDb.Medications.Find(id);

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
                _appDb.Update(medication);
                _appDb.SaveChanges();
                TempData["success"] = "Medication updated succesfully.";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["error"] = "Unable to update medication due to error";
                return View(e.Message);
            }
        }

        TempData["success"] = "Unable to update medication with invalid parameter.";
        return View(medication);
    }
    
    
    public IActionResult Delete(Guid? id)
    {
        var medication = _appDb.Medications.Find(id);

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
                _appDb.Remove(medication);
                _appDb.SaveChanges();
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
        return View(medication);
    }
}
using HygieiaApp.Data;
using HygieiaApp.Models;
using Microsoft.AspNetCore.Mvc;
namespace HygieiaApp.Controllers;

public class MedicalConditionController : Controller
{
    private readonly AppDbContext _appDb = new AppDbContext();


    public MedicalConditionController( )
    {
       
    }
    public IActionResult Index()
    {
        IEnumerable<MedicalCondition> medicalConditions = _appDb.MedicalConditions;
        
        return View(medicalConditions);
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(MedicalCondition condition)
    {

        if (condition.NameOfDiagnosis == condition.Type)
        {
            ModelState.AddModelError("", "Name of diagnosis and type are not the same.");
            return View(condition);
        }


        if (condition.NameOfDiagnosis.ToLower() == "test")
            ModelState.AddModelError("", "Test value not allowed.");

        
        if (ModelState.IsValid)
        {
            try
            {
                _appDb.MedicalConditions.Add(condition);
                _appDb.SaveChanges();
                TempData["success"] = "Medical condition created succesfully.";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["error"] = "Unable to create medical condition due to error.";
                return View(e.Message);
            }
        }

        return View(condition);
    }
    
    public IActionResult Edit(Guid? id)
    {
        if (id is null)
        {
            TempData["error"] = "Unable to edit medical condition due to unknown id.";
            return NotFound();
        }

        var medicalcond = _appDb.MedicalConditions.FirstOrDefault(x=> x.Id == id);

        if (medicalcond is null)
        {
            TempData["error"] = "Unable to update empty data.";
            return NotFound();
        }
            
        
        return View(medicalcond);
    }
    
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(MedicalCondition condition)
    {

        if (ModelState.IsValid)
        {
            try
            {
                _appDb.MedicalConditions.Update(condition);
                _appDb.SaveChanges();
                TempData["success"] = "Medical condition edited succesfully.";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["error"] = "Unable to edit medical condition due to error.";
                return View(e.Message);
            }
        }

        return View(condition);
    }
    
    public IActionResult Delete(Guid? id)
    {
        if (id is null)
            return NotFound();

        var medicalcond = _appDb.MedicalConditions.FirstOrDefault(x=> x.Id == id);

        if (medicalcond is null)
            return NotFound();
        
        return View(medicalcond);
    }
    
    
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePost(Guid? id)
    {
        var category = _appDb.MedicalConditions.FirstOrDefault(x => x.Id == id);

        if (category == null)
        {
            TempData["error"] = "Unable to delete medical condition due to error.";
            return NotFound();
        }

        _appDb.MedicalConditions.Remove(category);
        _appDb.SaveChanges();
        TempData["success"] = "Medical condition deleted succesfully.";
        return RedirectToAction("Index");
    }
}
using HygieiaApp.DataAccess.Data;
using HygieiaApp.DataAccess.Repositories;
using HygieiaApp.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Exception = System.Exception;

namespace HygieiaApp.Areas.Admin;

[Area(("Admin"))]
public class MedicalConditionController : Controller
{
    private readonly IUnitOfWork _medicalConditionRepository;


    public MedicalConditionController(IUnitOfWork medicalConditionRepository)
    {
        _medicalConditionRepository = medicalConditionRepository;
    }
    
    public IActionResult Index()
    {
        IEnumerable<MedicalCondition> medicalConditions = _medicalConditionRepository.MedicalConditionRepository.GetAll();
        
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
                _medicalConditionRepository.MedicalConditionRepository.Add(condition);
                _medicalConditionRepository.Save();
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

        var medicalcond = _medicalConditionRepository.MedicalConditionRepository.Get(x=> x.Id == id);

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
                _medicalConditionRepository.MedicalConditionRepository.Update(condition);
                _medicalConditionRepository.Save();
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

        var medicalcond = _medicalConditionRepository.MedicalConditionRepository.Get(x=> x.Id == id);

        if (medicalcond is null)
            return NotFound();
        
        return View(medicalcond);
    }
    
    
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePost(Guid? id)
    {
        var category = _medicalConditionRepository.MedicalConditionRepository.Get(x => x.Id == id);

        if (category == null)
        {
            TempData["error"] = "Unable to delete medical condition due to error.";
            return NotFound();
        }

        _medicalConditionRepository.MedicalConditionRepository.Delete(category);
        _medicalConditionRepository.Save();
        TempData["success"] = "Medical condition deleted succesfully.";
        return RedirectToAction("Index");
    }
}
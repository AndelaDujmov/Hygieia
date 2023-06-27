using HygieiaApp.DataAccess.Data;
using HygieiaApp.DataAccess.Repositories;
using HygieiaApp.Models.DTO;
using HygieiaApp.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Exception = System.Exception;

namespace HygieiaApp.Areas.Admin;

[Area(("Admin"))]
public class MedicalConditionController : Controller
{
    private readonly AdminService _service;

    public MedicalConditionController(AdminService adminServiceImpl)
    {
        _service = adminServiceImpl;
    }
    
    public IActionResult Index()
    {
        IEnumerable<MedicalCondition> medicalConditions = _service.ReturnAllMedicalConditions();
        
        return View(medicalConditions);
    }
    
    public IActionResult Create()
    {
        var conditionDto = new MedicationConditionDto();
        conditionDto.SelectListItems = _service.MedicationNameSelectList();
        conditionDto.MedicalCondition = new MedicalCondition();
        conditionDto.MedicalConditionMedication = new MedicalConditionMedication();
        return View(conditionDto);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(MedicationConditionDto condition)
    {

        if (ModelState.IsValid)
        {
            
            try
            {
                _service.CreateCondition(condition.MedicalCondition);
                _service.LinkConditionToMed(condition.MedicalCondition.Id, condition.MedicalConditionMedication);
                TempData["success"] = "Medical condition created succesfully.";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["error"] = "Unable to create medical condition due to error.";
                return View(e.Message);
            }
        }

        TempData["error"] = "Unable to create medical condition due to invalid model.";
     
        return View();
    }
    
    
    public IActionResult Edit(Guid? id)
    {
        if (id is null)
        {
            TempData["error"] = "Unable to edit medical condition due to unknown id.";
            return NotFound();
        }

        var medicalcond = _service.GetConditionById(id);

        if (medicalcond is null)
        {
            TempData["error"] = "Unable to update empty data.";
            return NotFound();
        }

        var medicineForCondition = _service.GetLinkByIdConditionId(medicalcond.Id);
        var conditionDto = new MedicationConditionDto();
        conditionDto.MedicalCondition = medicalcond;
        conditionDto.MedicalConditionMedication = medicineForCondition;
        conditionDto.SelectListItems = _service.MedicationNameSelectList();
        
        return View(conditionDto);
    }
    
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(MedicationConditionDto condition)
    {

        if (ModelState.IsValid)
        {
            try
            {
                _service.UpdateCondition(condition.MedicalCondition);
                _service.LinkConditionToMed(condition.MedicalCondition.Id, condition.MedicalConditionMedication);

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
    
    public IActionResult Info(Guid? id)
    {
        if (id is null)
        {
            TempData["error"] = "Unable to get information of medical condition due to unknown id.";
            return NotFound();
        }

        var medicalcond = _service.GetConditionById(id);

        if (medicalcond is null)
        {
            TempData["error"] = "Unable to update empty data.";
            return NotFound();
        }

        var medicineForCondition = _service.GetLinkByIdConditionId(medicalcond.Id);
        var conditionDto = new MedicationConditionDto();
        conditionDto.MedicalCondition = medicalcond;
        conditionDto.MedicalConditionMedication = medicineForCondition;
        conditionDto.SelectListItems = _service.MedicationNameSelectList();
        
        return View(conditionDto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Info(MedicationConditionDto condition)
    {

        return View(condition);
    }
    
    public IActionResult Delete(Guid? id)
    {
        if (id is null)
            return NotFound();

        var medicalcond = _service.GetConditionById(id);
        if (medicalcond is null)
            return NotFound();
        
        return View(medicalcond);
    }
    
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePost(Guid? id)
    {
        var category = _service.GetConditionById(id);

        if (category == null)
        {
            TempData["error"] = "Unable to delete medical condition due to error.";
            return NotFound();
        }

        _service.DeleteCondition(category);
        TempData["success"] = "Medical condition deleted succesfully.";
        return RedirectToAction("Index");
    }
   
}
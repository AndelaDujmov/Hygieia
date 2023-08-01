using HygieiaApp.DataAccess.Data;
using HygieiaApp.DataAccess.Repositories;
using HygieiaApp.Models.DTO;
using HygieiaApp.Models.Enums;
using HygieiaApp.Models.Models;
using Microsoft.AspNetCore.Authorization;
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
    
    [Authorize]
    public IActionResult Index()
    {
        IEnumerable<MedicalCondition> medicalConditions = _service.ReturnAllMedicalConditions();
        
        return View(medicalConditions);
    }
    
    [Authorize(Roles = "Administrator")]
    public IActionResult Create()
    {
        var conditionDto = new MedicationConditionDto();
        conditionDto.SelectListItems = _service.MedicationNameSelectList();
        conditionDto.MedicalCondition = new MedicalCondition();
        conditionDto.MedicalConditionMedication = new MedicalConditionMedication();
        return View(conditionDto);
    }
    
    [HttpPost]
    [Authorize(Roles = "Administrator")]
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
    
    [Authorize(Roles = "Administrator")]
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
        conditionDto.MedicalConditionMedications = _service.ReturnMedicationsByCondition(medicalcond.Id); 
        return View(conditionDto);
    }
    
    
    [HttpPost]
    [Authorize(Roles = "Administrator")]
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
    
    [Authorize]
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
        conditionDto.MedicalConditionMedications = _service.ReturnMedicationsByCondition(medicalcond.Id); 
        conditionDto.SelectListItems = _service.MedicationNameSelectList();
        
        return View(conditionDto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Administrator")]
    public IActionResult Info(MedicationConditionDto condition)
    {
        return View(condition);
    }

    public IActionResult AddNewMedicationToCondition(Guid id)
    {

        var medicineForCondition = new MedicalConditionMedication();
        medicineForCondition.MedicalConditionId = id;
        var conditionDto = new MedicationConditionDto();
        conditionDto.MedicalCondition = _service.GetConditionById(id);
        conditionDto.MedicalConditionMedication = medicineForCondition;
        conditionDto.SelectListItems = _service.MedicationNameSelectList();
        
        return View(conditionDto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public IActionResult AddNewMedicationToCondition(MedicationConditionDto medicationConditionDto)
    {
        medicationConditionDto.MedicalCondition = _service.GetConditionById(medicationConditionDto.MedicalConditionMedication.MedicalConditionId);
        
        _service.LinkConditionToMed(medicationConditionDto.MedicalCondition.Id, medicationConditionDto.MedicalConditionMedication);

        TempData["success"] = "Medical condition edited succesfully.";
        return RedirectToAction("Index");
        

        return View(medicationConditionDto);
    }
    public IActionResult UpdateMedicationToCondition(Guid id)
    {
        var meicationConditionView = new MedicationConditionDto();
        meicationConditionView.MedicalConditionMedication = new MedicalConditionMedication();
        meicationConditionView.MedicalConditionMedication = _service.GetMedicationForCondition(id);
        meicationConditionView.SelectListItems = _service.MedicationNameSelectList();
        meicationConditionView.MedicalCondition =
            _service.GetConditionById(meicationConditionView.MedicalConditionMedication.MedicalConditionId);

        return View(meicationConditionView);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public IActionResult UpdateMedicationToCondition(MedicationConditionDto medicationConditionDto)
    {
        medicationConditionDto.MedicalConditionMedication.MedicalConditionId =
            _service.GetConditionById(medicationConditionDto.MedicalConditionMedication.MedicalConditionId).Id;
        _service.UpdateMedicationForCondition(medicationConditionDto.MedicalConditionMedication);
        TempData["success"] = "Successfully updated!";
        return RedirectToAction("AddNewMedicationToCondition");
    }

    [Authorize]
    public IActionResult RemoveMedicationFromCondition(Guid id)
    {
        var medicalConditionMedication = _service.GetMedicationForCondition(id);

        medicalConditionMedication.Deleted = true;
        _service.UpdateMedicationForCondition(medicalConditionMedication);
        
        return RedirectToAction("Edit");
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
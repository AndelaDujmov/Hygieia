using HygieiaApp.DataAccess.Repositories.Impl;
using HygieiaApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Index = Microsoft.EntityFrameworkCore.Metadata.Internal.Index;

namespace HygieiaApp.Areas.Admin;

[Area(("Admin"))]
public class UserController : Controller
{
    private readonly AdminService _service;

    public UserController(AdminService service)
    {
        _service = service;
    }

    [Authorize(Roles = "Administrator")]
    public IActionResult Index()
    {
        var users = _service.ReturnAllUsers();
        return View(users);
    }
    
    [Authorize(Roles = "Administrator")]
    public IActionResult Edit(string id)
    {
        
        var user = _service.GetUserById(id);

        if (user is null)
        {
            TempData["error"] = "Unable to update empty data.";
            return NotFound();
        }
        
        
        return View(user);
    }
   
    [HttpPost]
    [Authorize(Roles = "Administrator")]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(ApplicationUser user)
    {
        if (ModelState.IsValid)
        {
            try
            {
               

                TempData["success"] = "User edited succesfully.";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["error"] = "Unable to edit medical condition due to error.";
                return View(e.Message);
            }
        }

        return View(user);
    }
    /*
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
        conditionDto.SelectListItems = _service.MedicationNameSelectList();
        
        return View(conditionDto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
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
   
    */
}
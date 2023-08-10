using HygieiaApp.DataAccess.Repositories.Impl;
using HygieiaApp.Models;
using HygieiaApp.Models.DTO;
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
   
        try
        {
            _service.UpdateUser(user);
            TempData["success"] = "User edited succesfully.";
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            TempData["error"] = "Unable to edit medical condition due to error.";
            return View(e.Message);
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
   */
    
    [Authorize(Roles = "Administrator")]
    public IActionResult Delete(string id)
    {
        _service.DeleteUser(id);
        TempData["success"] = "User deleted succesfully.";
        return RedirectToAction("Index");
    }

    [Authorize(Roles = "Administrator")]
    public IActionResult SeeDeletedUsers()
    {
        var users = _service.DeletedUsers();

        return View(users);
    }

    [Authorize(Roles = "Administrator")]
    public IActionResult UndoUser(string id)
    {
        _service.Undo(id);
        TempData["success"] = "User successfully readded!";
        return RedirectToAction("SeeDeletedUsers");
    }
    
    [Authorize]
    public IActionResult ChangePassword(string id)
    {
        var passwordChange = new ChangePasswordDto();
        passwordChange.CurrentPassword = _service.ReturnPasswordForUser(id);

        return View(passwordChange);
    }

    [Authorize]
    [HttpPost]
    public IActionResult ChangePassword(ChangePasswordDto model)
    {
        if (ModelState.IsValid)
        {
            /*
                        ApplicationUserManager UserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                        ApplicationUser user = UserManager.FindById(model.UserId);
            
                        if (user != null)
                        {
                            IdentityResult result = UserManager.ResetPassword(model.UserId, model.Token, model.NewPassword);
                            if (result.Succeeded)
                            {
                                return RedirectToAction("Index", "Home");
                            }
            
                            foreach (string error in result.Errors)
                                ModelState.AddModelError("", error);
            
                            return View(model);
                        }
            
            
                        return HttpNotFound();
                    }
            */
        }

        return View(model);
    }
}
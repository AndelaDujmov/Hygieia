using HygieiaApp.Razor.Data;
using HygieiaApp.Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HygieiaApp.Razor.Pages.MedicalConditions;

[BindProperties]
public class Edit : PageModel
{
    private AppDbContext _appDb = new AppDbContext();
    public MedicalCondition MedicalCondition { get; set; }
    
    public void OnGet(Guid? id)
    {
        if (id is not null)
            MedicalCondition = _appDb.MedicalConditions.Find(id);
            
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            try
            { 
                _appDb.MedicalConditions.Update(MedicalCondition);
                _appDb.SaveChanges();
                TempData["success"] = "Medical condition updated succesfully.";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["error"] = "Unable to create medical condition due to error.";
                //return RedirectToAction(e.Message);
            }
        }

        return Page();
    }
}
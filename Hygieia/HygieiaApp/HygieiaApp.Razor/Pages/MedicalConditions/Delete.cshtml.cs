using HygieiaApp.Razor.Data;
using HygieiaApp.Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HygieiaApp.Razor.Pages.MedicalConditions;

[BindProperties]
public class Delete : PageModel
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
       
        try
        {
            var condition = _appDb.MedicalConditions.Find(MedicalCondition.Id);
            _appDb.MedicalConditions.Remove(condition);
            _appDb.SaveChanges();
            TempData["success"] = "Medical condition deleted succesfully.";
            return RedirectToPage("Index");
        }
        catch (Exception e)
        {
            TempData["error"] = "Unable to delete medical condition due to error.";
            //return RedirectToAction(e.Message);
        }

        return Page();

    }
}
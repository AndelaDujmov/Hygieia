using HygieiaApp.Razor.Data;
using HygieiaApp.Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HygieiaApp.Razor.Pages.MedicalConditions;
[BindProperties]
public class Create : PageModel
{
    private AppDbContext _appDb { get; set; } = new AppDbContext();
    
    public MedicalCondition MedicalCondition { get; set; }
    
    public void OnGet()
    {
        
    }
    
    public async Task<IActionResult> OnPost()
    {
        await _appDb.MedicalConditions.AddAsync(MedicalCondition);
        await _appDb.SaveChangesAsync();
        TempData["success"] = "Medical condition created succesfully.";
        return RedirectToPage("Index");
    }
}
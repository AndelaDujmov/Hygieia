using HygieiaApp.Razor.Data;
using HygieiaApp.Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HygieiaApp.Razor.Pages.Immunizations;

[BindProperties]
public class Create : PageModel
{

    private AppDbContext _appDb { get; set; } = new AppDbContext();
    
    public Immunization Immunization { get; set; }
    
    public void OnGet()
    {
        
    }
    
    public async Task<IActionResult> OnPost()
    {
        await _appDb.Immunizations.AddAsync(Immunization);
        await _appDb.SaveChangesAsync();
        TempData["success"] = "Immunization created succesfully.";
        return RedirectToPage("Index");
    }
}
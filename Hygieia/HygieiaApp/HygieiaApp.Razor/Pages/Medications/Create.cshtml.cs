using HygieiaApp.Razor.Data;
using HygieiaApp.Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HygieiaApp.Razor.Pages.Medications;

[BindProperties]
public class Create : PageModel
{
    private AppDbContext _appDb { get; set; } = new AppDbContext();
    public Medication Medication { get; set; }

    public void OnGet()
    {
        
    }

    public async Task<IActionResult> OnPost()
    {
        await _appDb.Medications.AddAsync(Medication);
        await _appDb.SaveChangesAsync();
        TempData["success"] = "Medication created succesfully.";
        return RedirectToPage("Index");
    }
}
using HygieiaApp.Razor.Data;
using HygieiaApp.Razor.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HygieiaApp.Razor.Pages.Medications;

public class Index : PageModel
{
    private AppDbContext _db { get; set; } = new AppDbContext();
    public List<Medication> Medications { get; set; }
    public void OnGet()
    {
        Medications = _db.Medications.ToList();
    }
}
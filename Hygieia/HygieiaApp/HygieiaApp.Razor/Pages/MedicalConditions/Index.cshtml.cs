using HygieiaApp.Razor.Data;
using HygieiaApp.Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HygieiaApp.Razor.Pages.MedicalConditions;

[BindProperties]
public class Index : PageModel
{
    private readonly AppDbContext _appDb = new AppDbContext();
    public List<MedicalCondition> MedicalConditionsList { get; set; } = new List<MedicalCondition>();

   
    
    public void OnGet()
    {
        MedicalConditionsList = _appDb.MedicalConditions.ToList();
    }
}
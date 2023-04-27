using HygieiaApp.Razor.Data;
using HygieiaApp.Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HygieiaApp.Razor.Pages.Immunizations;

[BindProperties]
public class Index : PageModel
{

    private AppDbContext _appDbContext = new AppDbContext();
    public List<Immunization> Immunizations { get; set; }
    
    public void OnGet()
    {
        Immunizations = _appDbContext.Immunizations.ToList();
    }
}
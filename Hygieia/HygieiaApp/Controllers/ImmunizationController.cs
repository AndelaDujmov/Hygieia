using Microsoft.AspNetCore.Mvc;

namespace HygieiaApp.Controllers;

public class ImmunizationController : Controller
{
    public ImmunizationController()
    {
        
    }
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }
}
using Microsoft.AspNetCore.Mvc;

namespace HygieiaApp.Controllers;

public class MedicationController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
using Microsoft.AspNetCore.Mvc;

namespace HygieiaApp.Controllers;

public class SchedulerController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
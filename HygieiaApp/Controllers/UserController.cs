using Microsoft.AspNetCore.Mvc;

namespace HygieiaApp.Controllers;

[Area("Patient")]
public class UserController : Controller
{
   public IActionResult Index()
   {
      return View();
   }
   
}
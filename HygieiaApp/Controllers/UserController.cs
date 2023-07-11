using Microsoft.AspNetCore.Mvc;

namespace HygieiaApp.Controllers;

public class UserController : Controller
{
   public IActionResult Index()
   {
      return View();
   }
   
}
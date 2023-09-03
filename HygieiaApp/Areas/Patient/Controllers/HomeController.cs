using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HygieiaApp.Models.Models;
using Microsoft.AspNetCore.Authorization;

namespace HygieiaApp.Areas.Patient;

[Area(("Patient"))]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly PatientService _service;
    private readonly DoctorService _drService;

    public HomeController(ILogger<HomeController> logger, PatientService service, DoctorService drService)
    {
        _logger = logger;
        _service = service;
        _drService = drService;
    }

    public IActionResult Index()
    {
      
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult ShowData()
    {
        var data = _service.ReturnData(_drService.GetCurrentUser(HttpContext.User));
        return View(data);
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
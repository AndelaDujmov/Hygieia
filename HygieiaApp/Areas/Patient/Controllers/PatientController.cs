using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HygieiaApp.Areas.Patient;

[Area(("Patient"))]
public class PatientController : Controller
{
    private readonly PatientService _service;

    public PatientController(PatientService patientService, DoctorService drService)
    {
        _service = patientService;
    }

    [Authorize]
    public IActionResult ReturnMyTests()
    {
        var testsUser = _service.ReturnTestsByPatient(HttpContext.User);

        return View(testsUser);
    }
    
    
}
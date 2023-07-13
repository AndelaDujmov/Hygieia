using HygieiaApp.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HygieiaApp.Areas.Patient;

[Area(("Patient"))]
public class PatientController : Controller
{
    private readonly PatientService _service;

    public PatientController(PatientService patientService)
    {
        _service = patientService;
    }

    [Authorize]
    public IActionResult ReturnMyTests()
    {
        var testsUser = _service.ReturnTestsByPatient(HttpContext.User);

        return View(testsUser);
    }

    public IActionResult CheckDateForVaccination()
    {
        var vaccine = new PatientVaccinationDto();
      

        return View(vaccine);
    }

    [HttpPost]
    [Authorize]
    public IActionResult CheckDateForVaccination(PatientVaccinationDto vaccinationDto, DateTime date)
    {
        if (ModelState.IsValid)
        {
            var vaccine = _service.ReturnVaccAppointmentByDate(date);

            if (vaccine.ImmunizationPatients != null)
            {
                
                return View(vaccine);
            }
            else
            {
                TempData["error"] = $"Unable to find vaccination appointment on the date {date.ToString()}";
                return View(vaccinationDto);
            }
        }
        TempData["error"] = "Server error";
        return RedirectToAction("Index", "Home");
    }

    [Authorize]
    public IActionResult AssignForImmunizationDate(Guid id)
    {

        var immunization = _service.ReturnImmunizationPatientById(id);
        var user = _service.ReturnUserById(HttpContext.User);

        if (immunization.UserId is not null && immunization.UserId.Equals(user.Id))
        {
            TempData["error"] = "You already applied to this event!";
            return RedirectToAction("CheckDateForVaccination");
        }
        _service.SignUpPatientForVaccination(id, user);
        
        TempData["success"] = "You succesfully signed up for vaccination!";
        return RedirectToAction("ReturnMyTests");
    }
    
    [Authorize]
    public IActionResult ShowUpcommingVaccinations()
    {
        var all = _service.GetAllVaccinationsByUser(HttpContext.User);
        
        return View(all);
    }
    
}


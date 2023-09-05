using HygieiaApp.Models.DTO;
using HygieiaApp.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HygieiaApp.Areas.Patient;

[Area(("Patient"))]
public class PatientController : Controller
{
    private readonly PatientService _service;
    private readonly DoctorService _doctorService;

    public PatientController(PatientService patientService, DoctorService doctorService)
    {
        _service = patientService;
        _doctorService = doctorService;
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
        
        if(User.IsInRole(RoleName.Patient.ToString()))
            return RedirectToAction("ReturnMyTests");
        return RedirectToAction("ShowUpcommingVaccinations");
    }

    [Authorize]
    public IActionResult ShowUpcommingVaccinations()
    {
        var all = _service.GetAllVaccinationsByUser(HttpContext.User);

        return View(all);
    }

    [Authorize]
    public IActionResult CancelVaccination(Guid id)
    {
        _service.CancelVaccination(id);
        TempData["success"] = "You succesfully cancelled vaccination!";
        return RedirectToAction("ShowUpcommingVaccinations");
    }

    [Authorize]
    public IActionResult ShowAllPatientsAppointments()
    {
        var patientsAppointments = _service.ReturnPatientsEvents(_doctorService.GetCurrentUser(HttpContext.User));

        return View(patientsAppointments);
    }

    [Authorize]
    public IActionResult CancelAppointment(Guid id)
    {
        _service.CancelAppointment(id);
        TempData["success"] = "You succesfully cancelled the appointment!";
        return RedirectToAction("ShowAllPatientsAppointments");
    }
}


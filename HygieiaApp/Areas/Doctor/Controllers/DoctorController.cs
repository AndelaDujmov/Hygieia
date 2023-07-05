using HygieiaApp.DataAccess.Repositories;
using HygieiaApp.Models;
using HygieiaApp.Models.DTO;
using HygieiaApp.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HygieiaApp.Areas.Doctor;

[Area(("Doctor"))]
public class DoctorController : Controller
{
    private readonly DoctorService _service;
    private readonly AdminService _adminService;
    private readonly UserManager<IdentityUser> _userManager;

    public DoctorController(DoctorService service, AdminService adminService, UserManager<IdentityUser> userManager)
    {
        _service = service;
        _adminService = adminService;
        _userManager = userManager;
    }

    public IActionResult Index()
    {

        return View();
    }

    [Authorize]
    
    public IActionResult AssignPatientToDoctor(Guid? id)
    {
        var guid = _userManager.GetUserId(HttpContext.User);
        var doctor = _adminService.GetUserById(guid);

        return View(doctor);
    }
/*
    [Authorize(Roles = "Doctor")]
    public IActionResult PatientsPage()
    {
        var patients = _service.Patients();
        return View(patients);
    }

    [Authorize(Roles = "Administrator, Doctor")]
    public IActionResult PatientInfo(Guid id)
    {
        var patient = _service.GetPatientById(id);

        var pd = _service.ReturnPatientDoctorById(patient.Id);
        var doctor = _service.GetDoctorById(pd.DoctorsId);
        var tests = _service.ReturnTestsPatientById(pd.PatientsId);
        var testType = _adminService.GetTestResultById(tests.TestResultId);

        var patientDoctor = new UserDoctorDto(patient, pd, doctor, tests, testType);

        return View(patientDoctor);
    }

    [Authorize(Roles = "Doctor")]
    public IActionResult UploadResults(Guid id)
    {
        var patient = _service.GetPatientById(id);
        var testDto = new TestUserDto();
        testDto.TypeOfTest = _adminService.TestNamesSelectList();

        testDto.ResultsPatient = new TestResultsPatient();
        testDto.ResultsPatient.PatientId = patient.Id;
        return View(testDto);
    }

    [HttpPost]
    [Authorize(Roles = "Doctor")]
    [ValidateAntiForgeryToken]
    public IActionResult UploadResults(TestUserDto testUserDto)
    {
        if (ModelState.IsValid)
        {
            _service.AddTestResult(testUserDto.ResultsPatient);

            TempData["success"] = "Successfully added.";
            return RedirectToAction("PatientsPage");
        }

        TempData["error"] = "An error occured while creating data..";
        return View();
    }

    [Authorize(Roles = "Doctor")]
    public IActionResult EditResults(Guid id)
    {
        var testDto = new TestUserDto();
        testDto.TypeOfTest = _adminService.TestNamesSelectList();
        testDto.ResultsPatient = _service.ReturnTestsPatientById(id);

        return View(testDto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Doctor")]
    public IActionResult EditResults(TestUserDto testUserDto)
    {
        if (ModelState.IsValid)
        {
            _service.UpdatePatientsResult(patientsResult: testUserDto.ResultsPatient);
            TempData["success"] = "Data successfully edited";
            return RedirectToAction("PatientsPage");
        }

        TempData["error"] = "Unable to edit user due to error.";
        return View();
    }  */
}  
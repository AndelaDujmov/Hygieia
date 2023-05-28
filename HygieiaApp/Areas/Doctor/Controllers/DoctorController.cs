using HygieiaApp.DataAccess.Repositories;
using HygieiaApp.Models.DTO;
using HygieiaApp.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HygieiaApp.Areas.Doctor;

[Area(("Doctor"))]
public class DoctorController : Controller
{
    private readonly DoctorService _service;
    private readonly AdminService _adminService;

    public DoctorController(DoctorService service, AdminService adminService)
    {
        _service = service;
        _adminService = adminService;
    }

    public IActionResult Index()
    {

        return View();
    }

    public IActionResult PatientsPage()
    {
        var patients = _service.Patients();
        return View(patients);
    }

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

    public IActionResult EditResults(Guid id)
    {
        var testDto = new TestUserDto();
        testDto.TypeOfTest = _adminService.TestNamesSelectList();
        testDto.ResultsPatient = _service.ReturnTestsPatientById(id);

        return View(testDto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
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
    }  
}  
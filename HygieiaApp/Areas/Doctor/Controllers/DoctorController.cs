using HygieiaApp.DataAccess.Repositories;
using HygieiaApp.Models;
using HygieiaApp.Models.DTO;
using HygieiaApp.Models.Enums;
using HygieiaApp.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Azure.Cosmos.Linq;

namespace HygieiaApp.Areas.Doctor;

[Area(("Doctor"))]
public class DoctorController : Controller
{
    private readonly DoctorService _service;
    private readonly AdminService _adminService;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public DoctorController(DoctorService service, AdminService adminService, IWebHostEnvironment webHostEnvironment)
    {
        _service = service;
        _adminService = adminService;
        _webHostEnvironment = webHostEnvironment;
    }

    public IActionResult NoResults()
    {
        return View();
    }
    public IActionResult Index()
    {
        var guid = _service.GetCurrentUser(HttpContext.User);
        var patients = _service.ReturnAllDoctorsPatients(guid);
        return View(patients);
    }

    [Authorize(Roles = "Doctor")]
    [HttpGet]
    public IActionResult AssignPatientToDoctor(Guid? id)
    {

        var patientDoctor = new PatientDoctorDTO();
        var guid = _service.GetCurrentUser(HttpContext.User);
        var doctor = _adminService.GetUserById(guid);
        patientDoctor.User = doctor;
        patientDoctor.Selected = String.Empty;
        patientDoctor.ItemsForDoctor = new List<SelectListItem>();
        patientDoctor.ItemsForDoctor = _service.PatientsSelectList();
        return View(patientDoctor);
    }

    [HttpPost]
    [Authorize(Roles = "Doctor")] 
    [ValidateAntiForgeryToken]
    public IActionResult AssignPatientToDoctor(PatientDoctorDTO patientDoctorDto)
    {
        var guid = _service.GetCurrentUser(HttpContext.User);
        var doctor = _adminService.GetUserById(guid);
        patientDoctorDto.User = doctor;
        try
        {
            if (_service.CheckIfPatientIsAlreadyAtTheDoctor(patient: patientDoctorDto.Selected, doctor: guid))
            {
                TempData["error"] = $"Patient already assigned to another doctor!";
                return View(patientDoctorDto);
            }

            _service.LinkPatientToDoctor(patient: patientDoctorDto.Selected, doctor: patientDoctorDto.User.Id);
            TempData["success"] = $"Sucessfully added patient to {patientDoctorDto.User.UserName}!";
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            TempData["error"] = "Unable to create medical condition due to error.";
            return View(e.Message);
        }
        
        TempData["error"] = "Please fill the data again and come back later!.";
        return View(patientDoctorDto);
    }
    
    public IActionResult Remove(string id)
    {

        var user = _service.ReturnAllDoctorsPatients(_service.GetCurrentUser(HttpContext.User))
            .Where(user => user.Id.Equals(id))
            .FirstOrDefault();
        
        if (user is null)
            return BadRequest();

        return View(user);
    }
    
    [HttpPost, ActionName("Remove")]
    public IActionResult RemovePost(string id)
    {
        var user = _service.ReturnAllDoctorsPatients(_service.GetCurrentUser(HttpContext.User))
            .Where(user => user.Id.Equals(id))
            .Select(user => user.Id)
            .FirstOrDefault();

        _service.RemovePatient(patient: user);
        TempData["success"] = "Patient removed succesfully.";
        return RedirectToAction("AssignPatientToDoctor");
    }
   
    [Authorize]
    public IActionResult PatientInfo(string id)
    {
        var patient= _service.ReturnAllDoctorsPatients(_service.GetCurrentUser(HttpContext.User))
                                   .Where(user => user.Id.Equals(id))
                                   .FirstOrDefault();
        
        var doctor = _adminService.GetUserById(_service.GetCurrentUser(HttpContext.User));
        var tests = _service.ReturnAllTestsByUser(patient.Id);
        _service.ReturnTestNames(tests);

        var patientDoctor = new PatientDoctorDTO();

        patientDoctor.Patient = patient;  
        patientDoctor.User = doctor;
        patientDoctor.Tests = tests;

        return View(patientDoctor);
    }

    [Authorize]
    public IActionResult UploadResults(string id)
    {
        var patient =  _service.ReturnAllDoctorsPatients(_service.GetCurrentUser(HttpContext.User))
            .Where(user => user.Id.Equals(id))
            .FirstOrDefault();
        var testDto = new TestUserDto();
        testDto.TypeOfTest = _adminService.TestNamesSelectList();

        testDto.ResultsPatient = new TestResultsPatient();
        testDto.ResultsPatient.PatientId = patient.Id ?? string.Empty;
        return View(testDto);
    }

    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public IActionResult UploadResults(TestUserDto? testUserDto, IFormFile? file)
    {
        if (ModelState.IsValid)
        {
            var wwwrootPath = _webHostEnvironment.WebRootPath;

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var scans = Path.Combine(wwwrootPath, @"scans");

            using (var filestream = new FileStream(Path.Combine(scans, fileName), FileMode.Create))
            {
                file.CopyTo(filestream);
            }

            testUserDto.ResultsPatient.Results = "/scans/" + fileName;
        
            _service.AddTestResult(resultsPatient: testUserDto.ResultsPatient);
            TempData["success"] = "Succesfully uploaded!";
            return RedirectToAction("Index");
        }
        TempData["error"] = "An error occured while creating data..";
        return View(testUserDto);
    }

    [Authorize]
    public IActionResult EditResults(string id)
    {
        var testDto = new TestUserDto();
        testDto.ResultsPatient = new TestResultsPatient();
        testDto.ResultsPatient.PatientId = _service.ReturnAllDoctorsPatients(_service.GetCurrentUser(HttpContext.User))
                                                   .Where(user => user.Id.Equals(id))
                                                   .Select(user => user.Id)
                                                   .FirstOrDefault();
        
        testDto.TypeOfTest = _adminService.TestNamesSelectList();
        testDto.ResultsPatient = _service.ReturnTestsPatientById(id);

        if (testDto.ResultsPatient.Results == null)
            return RedirectToAction("NoResults");

        return View(testDto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public IActionResult EditResults(TestUserDto? testUserDto, IFormFile? file)
    {
        if (ModelState.IsValid)
        {
            var wwwrootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var scans = Path.Combine(wwwrootPath, @"scans");

                if (!string.IsNullOrEmpty(testUserDto.ResultsPatient.Results))
                {
                    var oldImgPath = Path.Combine(wwwrootPath, testUserDto.ResultsPatient.Results.TrimStart('\\'));
                    
                    if(System.IO.File.Exists(oldImgPath)) System.IO.File.Delete(oldImgPath);
                }
                using (var filestream = new FileStream(Path.Combine(scans, fileName), FileMode.Create))
                {
                    file.CopyTo(filestream);
                }

                testUserDto.ResultsPatient.Results = "/scans/" + fileName;
            }
            _service.UpdatePatientsResult(patientsResult: testUserDto.ResultsPatient);
            TempData["success"] = "Succesfully updated!";
            return RedirectToAction("Index");
        }

        TempData["error"] = "Unable to edit user due to error.";
        return View(testUserDto);
    }
}  
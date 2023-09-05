using HygieiaApp.DataAccess.Repositories;
using HygieiaApp.Models;
using HygieiaApp.Models.DTO;
using HygieiaApp.Models.Enums;
using HygieiaApp.Models.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Azure.Cosmos.Linq;
using MemoryStream = System.IO.MemoryStream;


namespace HygieiaApp.Areas.Doctor;

[Area(("Doctor"))]
public class DoctorController : Controller
{
    private readonly DoctorService _service;
    private readonly AdminService _adminService;
    private readonly IWebHostEnvironment _webHostEnvironment;
    
    [BindProperty]
    public ApplicationUser Patient { get; set; }

    public DoctorController(DoctorService service, AdminService adminService, IWebHostEnvironment webHostEnvironment)
    {
        _service = service;
        _adminService = adminService;
        _webHostEnvironment = webHostEnvironment;
    }

    public IActionResult NoRecords()
    {
        return View();
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
                return RedirectToAction("AssignPatientToDoctor");
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

  
    public IActionResult PatientInfo(string? id)
    {
        
        var patient = (User.IsInRole(RoleName.Doctor.ToString())) ? _service.ReturnAllDoctorsPatients(_service.GetCurrentUser(HttpContext.User))
            .Where(user => user.Id.Equals(id))
            .FirstOrDefault()
            : _adminService.GetUserById(_service.GetCurrentUser(HttpContext.User));

        var doctor = (User.IsInRole(RoleName.Doctor.ToString())) ? _adminService.GetUserById(_service.GetCurrentUser(HttpContext.User))
                : _service.GetDoctorByPatient(patient.Id);
        var tests   = _service.ReturnAllTestsByUser(patient.Id);
        _service.ReturnTestNames(tests);

        var patientDoctor = new PatientDoctorDTO();

        patientDoctor.Patient = patient;
        patientDoctor.User = doctor;
        patientDoctor.Tests = tests;
  
        return View(patientDoctor);
    }

    [Authorize]
    public IActionResult GetAllPatientsResults(string id)
    {
        var patientsResults = _service.GetAllTestsByPatient(id);

        Patient = _adminService.GetUserById(id);

        return patientsResults == null || !patientsResults.Any() ? RedirectToAction("NotFoundData", "MedicalCondition", new {area = "Admin"}) : View(patientsResults);
    }

    [Authorize]
    public IActionResult GetUsersMedicalHistory(string? id)
    {
        var userId = (HttpContext.User.IsInRole(RoleName.Patient.ToString()))
            ? _service.GetCurrentUser(HttpContext.User)
            : id;
        var userHistoryDto = new PatientMedicalHistoryDto();
        userHistoryDto.Conditions = _service.GetUsersConditions(userId).Where(x => !x.Deleted);
        userHistoryDto.PatientName = _adminService.GetUserById(userId);
        return View(userHistoryDto);
    }

    [Authorize]
    public IActionResult GetUsersConditionDetails(Guid id)
    {
        var conditionMedDto = new ConditionMedicationViewDto();
        conditionMedDto.PatientMedicalCondition = _service.ReturnPatientsConditionById(id);
        conditionMedDto.ConditionMedicated = _service.GetUsersMedications(id);
        return View(conditionMedDto);
    }

    [Authorize]
    public IActionResult UploadResults(string id)
    {
        var patient = _service.ReturnAllDoctorsPatients(_service.GetCurrentUser(HttpContext.User))
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

                    if (System.IO.File.Exists(oldImgPath)) System.IO.File.Delete(oldImgPath);
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

    [Authorize]
    public IActionResult CreateVaccinationForPatient()
    {
        var vaccine = new PatientVaccinationDto();
        vaccine.Vaccines = _service.ReturnVaccinationNames();
        vaccine.ImmunizationForPatient = new ImmunizationPatient();

        return View(vaccine);
    }

    [HttpPost]
    [Authorize]
    public IActionResult CreateVaccinationForPatient(PatientVaccinationDto? patientVaccinationDto)
    {
  
        if (patientVaccinationDto.ImmunizationForPatient.DateOfVaccination < DateTime.Now)
        {
            TempData["error"] = "Unable to create vaccination in the past";
            return View(patientVaccinationDto);
        }

        _service.Save(patientVaccinationDto.ImmunizationForPatient);
        TempData["success"] = "Vaccination appointment successfully created!";
        return RedirectToAction("ReturnAllVaccines");
        
    }
    public IActionResult ReturnAllVaccines()
    {
        var vaccines = (HttpContext.User.IsInRole(RoleName.Doctor.ToString())) 
            ? _service.ReturnAllVaccinesWithDoctorPatients(_service.GetCurrentUser(HttpContext.User)) :
                _service.ReturnAllVaccinesWithPatients();

        if (vaccines.Equals(null))
            RedirectToAction("NoRecords");

        return View(vaccines);
    }

    public IActionResult UpdateTheTimeOfVaccination(Guid id)
    {
        var vaccination = _service.ReturnPatientWithVaccination(id);

        return View(vaccination);
    }

    [HttpPost]
    [Authorize]
    public IActionResult UpdateTheTimeOfVaccination(ImmunizationPatient vaccination)
    {
        if (ModelState.IsValid)
        {
            _service.ChangeTimeOfImmunization(vaccination.Id, vaccination.DateOfVaccination);
            TempData["success"] = "Succesfuly updated";
            return RedirectToAction("ReturnAllVaccines");
        }
        
        TempData["error"] = "There is an error while updating data.";
        return View(vaccination);
    }

    [Authorize]
    public IActionResult DiagnosePatient(string id)
    {
        var patientMedicalC = new PatientConditionsDto(); 
        var user = _adminService.GetUserById(id);
        patientMedicalC.patientName = user.FirstName + " " + user.LastName;
        patientMedicalC.MedicalCondition = new MedicalCondition();
        patientMedicalC.MedicalConditions = _service.MedicalConditionsSelectList();
        patientMedicalC.PatientMedicalCondition = new PatientMedicalCondition();
        patientMedicalC.SelectedMedication = Guid.Empty;
        patientMedicalC.PatientMedicalCondition.UserId = id;
        patientMedicalC.MedicationSelectList = _adminService.MedicationNameSelectList();
        return View(patientMedicalC);
    }
    
    [Authorize]
    [HttpPost]
    public IActionResult DiagnosePatient(PatientConditionsDto patientc, DateTime? start, string? reason, decimal? maxdose, int? frequency)
    {
           
        if (_service.CheckIfPatientDiagnosed(patientc.PatientMedicalCondition))
        {
            TempData["error"] = "Patient already diagnosed.";
            return RedirectToAction("DiagnosePatient");
        }
        
        if (patientc.SelectedMedication != Guid.Empty)
        {
            var medication =  _adminService.GetMedicationById(patientc.SelectedMedication);

            if (medication is null)
            {
                TempData["error"] = "There is no record known for that condition. Please contact administrator.";
                return RedirectToAction("DiagnosePatient");
            }
            
            var conditionMedication = _service.ReturnMcByConditionAndMedication(medicationId: medication.Id,
                conditionId: patientc.PatientMedicalCondition.MedicalConditionId);

            _service.DiagnosePatient(patientc.PatientMedicalCondition);
            var conditionMedicated = new MedicalConditionMedicated();
            conditionMedicated.MedicalConditionPatientId = patientc.PatientMedicalCondition.Id;
            conditionMedicated.MedicalConditionMedicationId = conditionMedication.Id;
            conditionMedicated.StartDate = ((DateTime)start);
            conditionMedicated.Frequency = (int)frequency;
         
            conditionMedicated.Reason = reason;
            conditionMedicated.Dosage = (decimal)maxdose;
            
            _service.MedicatePatient(conditionMedicated);
        }
        else
        {
            _service.DiagnosePatient(patientc.PatientMedicalCondition);
        }
     
        TempData["success"] = "Added successfully.";
        return RedirectToAction("Index");
        
    }

    public IActionResult AddAnotherMedicationToCondition(Guid id)
    {
        var patientMedicalC = new PatientConditionsDto();
        patientMedicalC.PatientMedicalCondition =  _service.ReturnPatientsConditionById(id);
        patientMedicalC.MedicalCondition =
            _adminService.GetConditionById(patientMedicalC.PatientMedicalCondition.MedicalConditionId);
        patientMedicalC.MedicationSelectList = _adminService.MedicationNameSelectList();
        patientMedicalC.SelectedMedication = Guid.Empty;
        
        return View(patientMedicalC);
    }

    [HttpPost]
    public IActionResult AddAnotherMedicationToCondition(PatientConditionsDto patientc, DateTime start, string reason,
        decimal maxdose, int frequency)
    {
        var medication =  _adminService.GetMedicationById(patientc.SelectedMedication);

        if (medication is null)
        {
            TempData["error"] = "There is no record known for that condition. Please contact administrator.";
            return RedirectToAction("DiagnosePatient");
        }

        patientc.PatientMedicalCondition = _service.ReturnPatientsConditionById(patientc.PatientMedicalCondition.Id);
        var conditionMedication = _service.ReturnMcByConditionAndMedication(medicationId: medication.Id,
            conditionId: patientc.PatientMedicalCondition.MedicalConditionId);
        var conditionMedicated = new MedicalConditionMedicated();
        conditionMedicated.MedicalConditionPatientId = patientc.PatientMedicalCondition.Id;
        conditionMedicated.MedicalConditionMedicationId = conditionMedication.Id;
        conditionMedicated.StartDate = ((DateTime)start);
        conditionMedicated.Frequency = (int)frequency;
        conditionMedicated.Reason = reason;
        conditionMedicated.Dosage = (decimal)maxdose;
            
        _service.MedicatePatient(conditionMedicated);
        
        return RedirectToAction("GetUsersConditionDetails", new {id = patientc.PatientMedicalCondition.Id});
    }

    public IActionResult GetAllPastVaccinations(string? id)
    {
        var vaccinations = _service.GetAllPatientsVaccinations(id);
        
        if(!vaccinations.ImmunizationPatients.Any() || vaccinations.ImmunizationPatients is not null)
            vaccinations.ImmunizationPatients = vaccinations.ImmunizationPatients.Where(x => x.DateOfVaccination < DateTime.Now);
        
        return View(vaccinations);
    }

    public IActionResult GetAllOnGoingVaccinations(string? id)
    {
        var vaccinations = _service.GetAllPatientsVaccinations(id);
        
        if(!vaccinations.ImmunizationPatients.Any() || vaccinations.ImmunizationPatients is not null)
            vaccinations.ImmunizationPatients = vaccinations.ImmunizationPatients.Where(x => x.DateOfVaccination > DateTime.Now);
        
        return View(vaccinations);
    }

    public IActionResult ERefferalImmunization(string? id2, Guid id)
    {
        var patient =
            _adminService.GetUserById(id2 ?? _service.GetCurrentUser(HttpContext.User));

        ApplicationUser? drName = HttpContext.User.IsInRole(RoleName.Doctor.ToString()) ?
                        _adminService.GetUserById(_service.GetCurrentUser(HttpContext.User)) :
                        _service.GetPatientsDoctor(id2);
        
        var immunizationPerPatient = _service.ReturnPatientWithVaccination(id);
        immunizationPerPatient.User = patient;

        using (MemoryStream ms = new MemoryStream())
        {
            var document = new Document(PageSize.A4, 25, 25, 30, 30);
            var writer = PdfWriter.GetInstance(document, ms);
            document.Open();

            var image = Image.GetInstance("/home/andela/RiderProjects/HygieiaApp/HygieiaApp/wwwroot/HygieiaLogo/logoForErefferal.png");
            image.Alignment = Element.ALIGN_CENTER;
            
            document.Add(image);
            
            var paragraph = new Paragraph($"\n\n{immunizationPerPatient.User.LastName}, {immunizationPerPatient.User.FirstName}", new Font(Font.FontFamily.HELVETICA, 20));
        
            paragraph.Alignment = Element.ALIGN_LEFT;
            document.Add(paragraph);
            var paragraph2 = new Paragraph($"{immunizationPerPatient.User.DateOfBirth.ToString("D")}, {immunizationPerPatient.User.Gender.ToString()}", new Font(Font.FontFamily.HELVETICA, 15));
        
            paragraph2.Alignment = Element.ALIGN_LEFT;
            document.Add(paragraph2);
            var paragraph3 = new Paragraph($"\n\nAssigned to: {immunizationPerPatient.Selected}\nDate And Time: {immunizationPerPatient.DateOfVaccination.ToString("R")}.");
            paragraph3.Alignment = Element.ALIGN_CENTER;
            document.Add(paragraph3);
            var paragraph4 = new Paragraph($"\n\nMade by: {drName.FirstName} {drName.LastName}\nDate And Time: {DateTime.Now.ToString("D")} ________________________________________");
            paragraph4.Alignment = Element.ALIGN_LEFT;
            document.Add(paragraph4);
            
            document.Close();
            writer.Close();
            var constant = ms.ToArray();
            return File(constant, "application/vnd", "ERefferal.pdf");
        }
    }

    public IActionResult EPrescription(string? idp, Guid id)
    {
        var patient =
            _adminService.GetUserById(idp ?? _service.GetCurrentUser(HttpContext.User));

        ApplicationUser? drName = HttpContext.User.IsInRole(RoleName.Doctor.ToString()) ?
            _adminService.GetUserById(_service.GetCurrentUser(HttpContext.User)) :
            _service.GetPatientsDoctor(idp);

        var medicationForCondition = _service.ReturnUsersMedicationById(id);
        
        using (MemoryStream ms = new MemoryStream())
        {
            var document = new Document(PageSize.A4, 25, 25, 30, 30);
            var writer = PdfWriter.GetInstance(document, ms);
            document.Open();

            var image = Image.GetInstance("/home/andela/RiderProjects/HygieiaApp/HygieiaApp/wwwroot/HygieiaLogo/logoForErefferal.png");
            image.Alignment = Element.ALIGN_CENTER;
            
            document.Add(image);
            
            var paragraph = new Paragraph($"\n\n{patient.LastName}, {patient.FirstName}", new Font(Font.FontFamily.HELVETICA, 20));
        
            paragraph.Alignment = Element.ALIGN_LEFT;
            document.Add(paragraph);
            var paragraph2 = new Paragraph($"{patient.DateOfBirth.ToString("D")}, {patient.Gender.ToString()}", new Font(Font.FontFamily.HELVETICA, 15));
        
            paragraph2.Alignment = Element.ALIGN_LEFT;
            document.Add(paragraph2);
        
            var paragraph4 = new Paragraph($"\n\nMedication name: {medicationForCondition.MedicationName} on date {medicationForCondition.StartDate.ToString("yyyy MMMM dd")}");
            paragraph4.Alignment = Element.ALIGN_CENTER;
            document.Add(paragraph4);
            var paragraph5 = new Paragraph($"\n\nPrescribed for: {medicationForCondition.MedicalCondition} by reason {medicationForCondition.Reason}");
            paragraph5.Alignment = Element.ALIGN_CENTER;
            document.Add(paragraph5);
            var paragraph6 = new Paragraph($"\n\nDosage: {medicationForCondition.Dosage} mg\nFrequency: {medicationForCondition.Frequency} times per day");
            paragraph6.Alignment = Element.ALIGN_CENTER;
            document.Add(paragraph6);
            
            var paragraph3 = new Paragraph($"\n\nPrescriper: dr. {drName.FirstName} {drName.LastName} ____________________________________");
            paragraph3.Alignment = Element.ALIGN_LEFT;
            document.Add(paragraph3);
            
            document.Close();
            writer.Close();
            var constant = ms.ToArray();
            return File(constant, "application/vnd", "EPrescription.pdf");
        }
    }

    [Authorize]
    public IActionResult GetDeceasedPatients()
    {
        var deceased = _service.GetAllConditions()
            .Where(x => x.Stage.Equals(Stage.Dead))
            .Select(x => x.UserId)
            .ToList();
        var allDeceased = _adminService.DeletedUsers().ToList().Where(x => deceased.Contains(x.Id));
        
        return View(allDeceased);
    }
    
    #region DATATABLE_API_CALLS

    public IActionResult GetMyPatients()
    {
        IEnumerable<ApplicationUser> patients =
            _service.ReturnAllDoctorsPatients(_service.GetCurrentUser(HttpContext.User));
           
        return Json(new { data = patients });
    }
    
    public IActionResult Deceased()
    {
        var deceased = _service.GetAllConditions()
            .Where(x => x.Stage.Equals(Stage.Dead))
            .Select(x => x.UserId)
            .ToList();
        var allDeceased = _adminService.DeletedUsers().ToList().Where(x => deceased.Contains(x.Id));

        return Json(new {data = allDeceased});
    }
    
    #endregion
  
}  

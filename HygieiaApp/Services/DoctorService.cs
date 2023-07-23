using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using HygieiaApp.DataAccess.Repositories;
using HygieiaApp.Models;
using HygieiaApp.Models.DTO;
using HygieiaApp.Models.Enums;
using HygieiaApp.Models.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;


namespace HygieiaApp;

public class DoctorService
{
    private readonly IUnitOfWork _repository;
    private readonly UserManager<IdentityUser> _userManager;
    

    public DoctorService(IUnitOfWork repository, UserManager<IdentityUser> userManager)
    {
        _repository = repository;
        _userManager = userManager;
    }
    

    public ImmunizationPatient ReturnPatientWithVaccination(Guid id)
    {
        var results =  _repository.VaccinePatientRepository.Get(x => x.Id.Equals(id)) ?? new ImmunizationPatient();

        if (results != null)
            results.Selected = ReturnTheTypeForVaccination(results);

        return results;
    }
    
    public IEnumerable<ApplicationUser> ReturnAllPatients()
    {
        var users = _repository.ApplicationUserRepository.GetUsers();
        
        users.Where(x => x.Role.Equals(null))
            .ToList()
            .ForEach(x => x.Role = RoleName.Patient.ToString());

        return users.Where(role => role.Role.Equals(RoleName.Patient.ToString()));
    }

    public IEnumerable<SelectListItem> PatientsSelectList()
    {
        var items = ReturnAllPatients();

        return items.Select(x => new SelectListItem
        {
            Value = x.Id,
            Text = $"{x.Oib} {x.FirstName}  {x.LastName}"
        });
    }
    
    public IEnumerable<SelectListItem> ReturnVaccinationNames()
    {
        var tests = _repository.VaccineRepository.GetAll();

        return tests.Select(x => new SelectListItem
        {
            Value = x.Id.ToString(),
            Text = x.Type
        });
    }

    public IEnumerable<ApplicationUser> ReturnAllDoctorsPatients(string id)
    {
        var doctors = _repository.PatientDoctorRepository.GetAll()
            .Where(x => x.DoctorsId.Equals(id) && x.Deleted == false) ?? new List<PatientDoctor>();

        var patientsIds = doctors.Select(x => x.PatientsId).ToList();

       if (doctors.Equals(null))
            return new List<ApplicationUser>();

        var patients = ReturnAllPatients()
            .Where(patient => patientsIds.Contains(patient.Id));

        return patients;
    }
    public  string? GetCurrentUser(ClaimsPrincipal httpContextUser)
    {
        return _userManager.GetUserId(httpContextUser);
    }

    public bool CheckIfPatientIsAlreadyAtTheDoctor(string patient, string doctor)
    {
        var patients = _repository.PatientDoctorRepository.GetAll()
                                                                    .Where(x => !x.Deleted)
                                                                    .Select(x => x.PatientsId).ToList();

        if (patients.Contains(patient))
            return true;

        return false;
    }
    
    
    public void LinkPatientToDoctor(string patient, string doctor)
    {
        var patientDoctor = new PatientDoctor();
        patientDoctor.PatientsId = patient;
        patientDoctor.DoctorsId = doctor;
        _repository.PatientDoctorRepository.Add(patientDoctor);
        _repository.Save();
    }
    
    public void RemovePatient(string? patient)
    {
        var patientDoctor = _repository.PatientDoctorRepository.Get(x => x.PatientsId.Equals(patient));

        patientDoctor.Deleted = true;
        _repository.Save();
    }
    
    public void AddTestResult(TestResultsPatient resultsPatient)
    {
        _repository.TestResultPatientRepository.Add(resultsPatient);
        _repository.Save();
    }

    public TestResultsPatient ReturnTestsPatientById(string id)
    {
        return _repository.TestResultPatientRepository.GetAll()
                                                      .Where(x => x.PatientId.Equals(id))
                                                      .FirstOrDefault() ?? new TestResultsPatient();
    }
    
    public void UpdatePatientsResult(TestResultsPatient patientsResult)
    {
        _repository.TestResultPatientRepository.Update(patientsResult);
    }
    
    public IEnumerable<TestResultsPatient> ReturnAllTestsByUser(string patientId)
    {
        var tests = _repository.TestResultPatientRepository.GetAll()
                                                      .Where(test => test.PatientId.Equals(patientId));
        
        tests.ToList().ForEach(test => test.TestName = MatchNames(test));
        return tests;
    }

    public string MatchNames(TestResultsPatient result)
    {
        return _repository.ResultsRepository.GetAll().Where(x => x.Id.Equals(result.TestResultId)).Select(x => x.Type).FirstOrDefault() ?? string.Empty;
    }
    
    public void ReturnTestNames(IEnumerable<TestResultsPatient> tests)
    {
        tests.ToList().ForEach(test => test.TestName = MatchNames(test));
    }

    public void Save(ImmunizationPatient immunizationPatient)
    {
        _repository.VaccinePatientRepository.Add(immunizationPatient);
        _repository.Save();
    }
    
    public string ReturnTheTypeForVaccination(ImmunizationPatient patient)
    {
        var immunization = _repository.VaccineRepository.Get(x => x.Id.Equals(patient.ImmunizationId)) ?? null;

        if (immunization != null)
        {
            return immunization.Type;
        }

        return string.Empty;
    }

    public IEnumerable<PatientVaccinationDto> ReturnAllVaccinesWithPatients()
    {
        var vaccines = _repository.VaccinePatientRepository.GetAll();
        
        vaccines.ToList().ForEach(v => v.Selected = ReturnTheTypeForVaccination(v));

        return ReturnVaccinationDto(vaccines);
    }

    public void ChangeTimeOfImmunization(Guid id, DateTime dateTime)
    {
        var immunization = ReturnVaccinationsOnDate(ReturnPatientWithVaccination(id).DateOfVaccination);

         immunization.ToList().ForEach(x =>
            {
                x.DateOfVaccination = dateTime;
                FindUserAndSendEmail(x.UserId, x.DateOfVaccination);
            });
         
        
        _repository.Save();
    }

    public IEnumerable<SelectListItem> MedicalConditionsSelectList()
    {
        var users = _repository.MedicalConditionRepository.GetAll();

        return users.Select(x => new SelectListItem
        {
            Value = x.Id.ToString(),
            Text = x.NameOfDiagnosis
        });
    }
    
    public void SendEmail(string userInChargeName, string userInChargeEmail, string email, string subject, string body)
    {
        var mailMessage = new MimeMessage();
        mailMessage.From.Add(new MailboxAddress(userInChargeName, userInChargeEmail));
        mailMessage.To.Add(MailboxAddress.Parse(email));
        mailMessage.Subject = subject;
        mailMessage.Body = new TextPart("plain")
        {
            Text = body
        };

        using (var smtpClient = new SmtpClient())
        {
            smtpClient.Connect("smtp.gmail.com", 465, true);
            smtpClient.Authenticate("hygieiaapp874@gmail.com", "ygdrsoaimcdiwpny");
            smtpClient.Send(mailMessage);
            smtpClient.Disconnect(true);
            smtpClient.Dispose();
        }
    }

    public bool CheckIfEmailExists(string email)
    {
        var userEmail = _repository.ApplicationUserRepository.GetAll().Select(x => x.Email);

        if (userEmail.Contains(email))
            return true;
        
        return false;
    }

    public bool CheckIfUsernameExists(string username)
    {
        var userName = _repository.ApplicationUserRepository.GetAll().Select(x => x.UserName);

        if (userName.Contains(username))
            return true;

        return false;
    }
    
    public void DiagnosePatient(PatientMedicalCondition condition)
    {
        _repository.PatientConditionRepository.Add(condition);
        _repository.Save();
    }

    public MedicalConditionMedication ReturnMcByConditionAndMedication(Guid medicationId, Guid conditionId)
    {
        return _repository.MedicineForConditionRepository.Get(x =>
            x.MedicalConditionId.Equals(conditionId) && x.MedicationId.Equals(medicationId));
    }
    
    public void MedicatePatient(MedicalConditionMedicated conditionMedicated)
    {
        _repository.PatientMedicatedRepository.Add(conditionMedicated);
        _repository.Save();
    }

    private ApplicationUser GetAdmin()
    {
        var admin = _repository.ApplicationUserRepository.GetUserByRole(RoleName.Administrator.ToString());
        return admin;
    }

    private ApplicationUser GetPatientsDoctor(string id)
    {
        var user = new ApplicationUser();
        var docPat = _repository.PatientDoctorRepository.Get(x => x.PatientsId.Equals(id)) ?? null;
        try
        {


            if (docPat != null)
                user = _repository.ApplicationUserRepository.Get(x => x.Id.Equals(docPat.DoctorsId));
            else
                user = GetAdmin();
        }
        catch (NullReferenceException e)
        {
        }
       
        return user;
    }
    
    private void FindUserAndSendEmail(string id, DateTime dateTime)
    {
        var user = _repository.ApplicationUserRepository.Get(x => x.Id.Equals(id));

        var userInCharge = new ApplicationUser();
        //userInCharge = CheckIfUserInRole(user.Id, RoleName.Patient.ToString()) ? GetPatientsDoctor(user.Id) : GetAdmin();

        if (CheckIfUserInRole(user.Id, RoleName.Patient.ToString()))
            userInCharge = GetPatientsDoctor(user.Id);
        else
            userInCharge = GetAdmin();
        
        var fullName = userInCharge.FirstName + " " + userInCharge.LastName;
        
        SendEmail(fullName, userInCharge.Email,user.Email, 
            "Change of vaccination date", 
            $"Dear {user.FirstName} {user.LastName},\n your appointment has been changed to the new date {dateTime}\nBest regards,\n{userInCharge.FirstName} {userInCharge.LastName}");
    }
    
  
    private bool CheckIfUserInRole(string userId, string rolename)
    {
        var role = _repository.ApplicationUserRepository.GetRoleByUser(userId);

        if (role.Equals(rolename))
            return true;
        return false;
    }
    
    private string? GetFullUserName(ImmunizationPatient immunizationPatient)
    {
        var user = _repository.ApplicationUserRepository.Get(x => x.Id.Equals(immunizationPatient.UserId));

        return user.FirstName + " " + user.LastName;
    }

    private List<PatientVaccinationDto> ReturnVaccinationDto(IEnumerable<ImmunizationPatient> immunizationPatients)
    {
        var vaccinationDtoList = new List<PatientVaccinationDto>();
        
        /* immunizationPatients.ToList().ForEach(x =>
         {
             var dto = new PatientVaccinationDto();
             dto.ImmunizationForPatient = x;
             if (!x.UserId.Equals(null))
                 dto.FullNamePatient = GetFullUserName(x);
         });*/

        foreach (var patient in immunizationPatients)
        {
            var dto = new PatientVaccinationDto();
            dto.ImmunizationForPatient = patient;
            if (patient.UserId != null)
                dto.FullNamePatient = GetFullUserName(patient);
            vaccinationDtoList.Add(dto);
        }

        return vaccinationDtoList;
    }
    
    private IEnumerable<ImmunizationPatient> ReturnVaccinationsOnDate(DateTime date)
    {
        var all = _repository.VaccinePatientRepository.GetAll().Where(x => x.DateOfVaccination.Equals(date));
        
        all.ToList().ForEach(x => x.Selected = ReturnTheTypeForVaccination(x));

        return all;
    }
}
using System.Security.Claims;
using HygieiaApp.DataAccess.Repositories;
using HygieiaApp.Models;
using HygieiaApp.Models.DTO;
using HygieiaApp.Models.Enums;
using HygieiaApp.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Azure.Cosmos;

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
            Text = x.Oib + " " + x.FirstName + " " + x.LastName
        });
    }

    public string? GetCurrentUser(ClaimsPrincipal httpContextUser)
    {
        return _userManager.GetUserId(httpContextUser);
    }
/*
    public List<User> Patients()
    {
        return _repository.UserRepository
                          .GetAll()
                          .Where(x => x.Deleted == false)
                          .ToList();
    }

    public User GetPatientById(Guid? id)
    {
        return _repository.UserRepository.Get(x => x.Id.Equals(id)) ?? new User();
    }

    public User? GetDoctorById(Guid? id)
    {
        if (id.Equals(Guid.Empty))
            return new User();
        return _repository.UserRepository.Get(x => x.Id.Equals(id)) ?? new User();
    }
    
    public PatientDoctor? ReturnPatientDoctorById(Guid? id)
    {
        if (id.Equals(Guid.Empty))
            return new PatientDoctor();
        
        var obj = _repository.PatientDoctorRepository
                          .GetAll();

        if (obj.Count() is 0)
            return new PatientDoctor();
        else
            return  obj.Where(x => x.PatientsId.Equals(id)).FirstOrDefault();
    
    }
    public TestResultsPatient? ReturnTestsPatientById(Guid? id)
    {
        if (id.Equals(Guid.Empty))
            return new TestResultsPatient();
        
        var obj = _repository.TestResultPatientRepository
                          .GetAll()
                          .Where(x => x.PatientId.Equals(id));
        return obj.Equals(null) ? null : obj.FirstOrDefault();
    }
    
    public IEnumerable<SelectListItem> ReturnConditionsSelectList()
    {
        var users = _repository.MedicalConditionRepository.GetAll();

        return users.Select(x => new SelectListItem
        {
            Value = x.Id.ToString(),
            Text = x.NameOfDiagnosis
        });
    }

    public void AddTestResult(TestResultsPatient resultsPatient)
    {
        _repository.TestResultPatientRepository.Add(resultsPatient);
        _repository.Save();
    }

    public TestResultsPatient FindPatientWithResultById(Guid id)
    {
        return _repository.TestResultPatientRepository.Get(x => x.Id.Equals(id));
    }

    public void UpdatePatientsResult(TestResultsPatient patientsResult)
    {
        _repository.TestResultPatientRepository.Update(patientsResult);
    }
*/



}
using System.Security.Claims;
using HygieiaApp.DataAccess.Repositories;
using HygieiaApp.DataAccess.Repositories.Impl;
using HygieiaApp.Models;
using HygieiaApp.Models.DTO;
using HygieiaApp.Models.Models;

namespace HygieiaApp;

public class PatientService
{
    private readonly IUnitOfWork _repository;
    private readonly DoctorService _drService;

    public PatientService(IUnitOfWork repository, DoctorService drService)
    {
        _repository = repository;
        _drService = drService;
    }
    
    public ApplicationUser ReturnData(string id)
    {
        return _repository.ApplicationUserRepository.Get(x => x.Id.Equals(id)) ?? new ApplicationUser();
    }

  
    
    public PatientDoctorDTO ReturnTestsByPatient(ClaimsPrincipal claimsPrincipal)
    {
        var id = _drService.GetCurrentUser(httpContextUser: claimsPrincipal);
        var patientDoctorDto = new PatientDoctorDTO();

        patientDoctorDto.Tests =  _drService.ReturnAllTestsByUser(id);
        patientDoctorDto.Patient = ReturnData(id);

        return patientDoctorDto;
    }

 

    private List<ImmunizationPatient> ReturnListOfImmunizationsForTheDate(DateTime date)
    {
        var immunizations = _repository.VaccinePatientRepository.GetAll();
        var vaccineList = new List<ImmunizationPatient>();

        foreach (var vaccine in immunizations)
        {
            if (vaccine.DateOfVaccination.Date.Equals(date.Date))
            {
                vaccine.Selected = _drService.ReturnTheTypeForVaccination(vaccine);
                vaccineList.Add(vaccine);
            }
        }

        return vaccineList;
    }
    
    public PatientVaccinationDto ReturnVaccAppointmentByDate(DateTime date)
    {
        var patientVaccine = new PatientVaccinationDto();

        patientVaccine.ImmunizationPatients = ReturnListOfImmunizationsForTheDate(date);

        return patientVaccine;
    }

    public ApplicationUser ReturnUserById( ClaimsPrincipal httpContextUser)
    {
        return _repository.ApplicationUserRepository.Get(x => x.Id.Equals(_drService.GetCurrentUser(httpContextUser)));
    }
    
    public void SignUpPatientForVaccination(Guid id, ApplicationUser applicationUser)
    {
        var immunization = _repository.VaccinePatientRepository.Get(x => x.Id.Equals(id));

        if (immunization.UserId == null)
        {
            var immunizationNew = new ImmunizationPatient();
            immunizationNew.ImmunizationId = immunization.ImmunizationId;
            immunizationNew.DateOfVaccination = immunization.DateOfVaccination;
            immunizationNew.UserId = applicationUser.Id;
            _repository.VaccinePatientRepository.Add(immunizationNew);
        }

        immunization.UserId = applicationUser.Id;
        _repository.Save();
    }

    public ImmunizationPatient ReturnImmunizationPatientById(Guid id)
    {
        return _repository.VaccinePatientRepository.Get(x => x.Id.Equals(id));
    }


    public IEnumerable<ImmunizationPatient> GetAllVaccinationsByUser(ClaimsPrincipal httpContextUser)
    {
        var user = ReturnUserById(httpContextUser);
        var users = _repository.VaccinePatientRepository.GetAll();
        var userList = new List<ImmunizationPatient>();

        foreach (var vaccine in users)
        {
            if (vaccine.UserId != null)
            {
                if(vaccine.UserId.Equals(user.Id))
                    userList.Add(vaccine);
            }
        }
        
        userList.ToList().ForEach(user => user.Selected = _drService.ReturnTheTypeForVaccination(user));

        return userList;
    }


    public void CancelVaccination(Guid id)
    {
        var vaccination = _repository.VaccinePatientRepository.Get(x => x.Id.Equals(id));

        vaccination.UserId = null;
        
        _repository.Save();
    }
}
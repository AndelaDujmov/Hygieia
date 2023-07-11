using System.Security.Claims;
using HygieiaApp.DataAccess.Repositories;
using HygieiaApp.DataAccess.Repositories.Impl;
using HygieiaApp.Models;
using HygieiaApp.Models.DTO;

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
}
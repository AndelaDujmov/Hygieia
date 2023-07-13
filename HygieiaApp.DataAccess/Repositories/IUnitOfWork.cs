using HygieiaApp.DataAccess.Repositories.Impl;
using HygieiaApp.Models;
using Microsoft.AspNetCore.Identity;

namespace HygieiaApp.DataAccess.Repositories;

public interface IUnitOfWork
{
    IEventRepository EventRepository { get; }
    IMedicalConditionRepository MedicalConditionRepository { get; }
    IMedicationRepository MedicationRepository { get; }
    IPatientConditionRepository PatientConditionRepository { get; }
    IPatientDoctorRepository PatientDoctorRepository { get; }
    IPatientMedicatedRepository PatientMedicatedRepository { get; }
    IResultsRepository ResultsRepository { get; }
    IVaccineRepository VaccineRepository { get; } 
    IMedicineForConditionRepository MedicineForConditionRepository { get; }
    ITestResultPatientRepository TestResultPatientRepository { get; }
    IApplicationUserRepository ApplicationUserRepository { get; }
    IVaccinePatientRepository VaccinePatientRepository { get; }
    void Save();
}
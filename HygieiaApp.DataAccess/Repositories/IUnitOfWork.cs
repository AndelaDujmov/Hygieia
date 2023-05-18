using HygieiaApp.DataAccess.Repositories.Impl;

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
    IUserRepository UserRepository { get; }
    IVaccineRepository VaccineRepository { get; } 
    IMedicineForConditionRepository MedicineForConditionRepository { get; }

    void Save();
}
using HygieiaApp.DataAccess.Data;
using HygieiaApp.Models;
using Microsoft.AspNetCore.Identity;

namespace HygieiaApp.DataAccess.Repositories.Impl;

public class UnitOfWork : IUnitOfWork
{
    public IEventRepository EventRepository { get; private set; }
    public IMedicalConditionRepository MedicalConditionRepository { get; private set; }
    public IMedicationRepository MedicationRepository { get; private set;}
    public IPatientConditionRepository PatientConditionRepository { get; private set;}
    public IPatientDoctorRepository PatientDoctorRepository { get; private set;}
    public IPatientMedicatedRepository PatientMedicatedRepository { get; private set;}
    public IResultsRepository ResultsRepository { get; private set;}
    public IVaccineRepository VaccineRepository { get; private set;}
    public IVaccinePatientRepository VaccinePatientRepository { get; private set; }
    public ITestResultPatientRepository TestResultPatientRepository { get; private set; }
    public IApplicationUserRepository ApplicationUserRepository { get; }

    public IMedicineForConditionRepository MedicineForConditionRepository { get; private set; }
    

    private readonly AppDbContext _appDb;

    public UnitOfWork(AppDbContext appDb)
    {
        _appDb = appDb;
        EventRepository = new EventRepository(_appDb);
        MedicalConditionRepository = new MedicalConditionRepository(_appDb);
        MedicationRepository = new MedicationRepository(_appDb);
        PatientConditionRepository = new PatientConditionRepository(_appDb);
        PatientDoctorRepository = new PatientDoctorRepository(_appDb);
        PatientMedicatedRepository = new PatientMedicatedRepository(_appDb);
        ResultsRepository = new ResultsRepository(_appDb);
        ApplicationUserRepository = new ApplicationUserRepository(_appDb);
        VaccineRepository = new VaccineRepository(_appDb);
        VaccinePatientRepository = new VaccinePatientRepository(_appDb);
        TestResultPatientRepository = new TestResultPatientRepository(_appDb);
        MedicineForConditionRepository = new MedicineForConditionRepository(_appDb);
    }

    public void Save()
    {
        _appDb.SaveChanges();
    }
}
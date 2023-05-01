using HygieiaApp.DataAccess.Data;

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
    public IUserRepository UserRepository { get; private set;}
    public IVaccineRepository VaccineRepository { get; private set;}
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
        UserRepository = new UserRepository(_appDb);
        VaccineRepository = new VaccineRepository(_appDb);
    }

    public void Save()
    {
        _appDb.SaveChanges();
    }
}
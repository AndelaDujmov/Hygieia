using HygieiaApp.DataAccess.Data;
using HygieiaApp.Models.Models;

namespace HygieiaApp.DataAccess.Repositories.Impl;

public class MedicationRepository : Repository<Medication>, IMedicationRepository
{
    private readonly AppDbContext _appDb;

    public MedicationRepository(AppDbContext appDb) : base(appDb)
    {
        _appDb = appDb;
    }

    public void Update(Medication medication)
    {
        _appDb.Medications.Update(medication);
    }

    public void Save()
    {
        _appDb.SaveChanges();
    }
}
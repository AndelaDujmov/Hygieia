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

    public IEnumerable<Medication> GetANonDeleted()
    {
        return base.GetAll()
            .Where(x => x.Deleted == false);
    }

    public IEnumerable<Medication> GetAllDeleted()
    {
        return base.GetAll()
            .Where(x => x.Deleted == true);
    }

    public void SoftDelete(Guid id)
    {
        var element = _appDb.Medications.Where(x =>
            x.Deleted.Equals(false) && x.Id.Equals(id));

        _appDb.Update(element);
        _appDb.SaveChanges();
    }

    public void RetrieveDeleted(Guid id)
    {
        var element = _appDb.Medications.Where(x =>
            x.Deleted.Equals(false) && x.Id.Equals(id));

        _appDb.Update(element);
        _appDb.SaveChanges();
    }
}
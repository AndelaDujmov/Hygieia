using HygieiaApp.DataAccess.Data;
using HygieiaApp.Models.Models;

namespace HygieiaApp.DataAccess.Repositories.Impl;

public class PatientMedicatedRepository : Repository<MedicalConditionMedicated>, IPatientMedicatedRepository
{
    
    private readonly AppDbContext _appDb;
    public PatientMedicatedRepository(AppDbContext appDb) : base(appDb)
    {
        _appDb = appDb;
    }
    
    public IEnumerable<MedicalConditionMedicated> GetANonDeleted()
    {
        return base.GetAll()
            .Where(x => x.Deleted == false);
    }

    public IEnumerable<MedicalConditionMedicated> GetAllDeleted()
    {
        return base.GetAll()
            .Where(x => x.Deleted == true);
    }

    public void SoftDelete(Guid id)
    {
        var element = _appDb.MedicalConditionMedicateds.Where(x =>
            x.Deleted.Equals(false) && x.Id.Equals(id));

        _appDb.Update(element);
        _appDb.SaveChanges();
    }

    public void RetrieveDeleted(Guid id)
    {
        var element = _appDb.MedicalConditionMedicateds.Where(x =>
            x.Deleted.Equals(false) && x.Id.Equals(id));

        _appDb.Update(element);
        _appDb.SaveChanges();
    }
}
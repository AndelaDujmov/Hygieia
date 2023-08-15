using HygieiaApp.DataAccess.Data;
using HygieiaApp.Models.Models;

namespace HygieiaApp.DataAccess.Repositories.Impl;

public class VaccinePatientRepository : Repository<ImmunizationPatient>, IVaccinePatientRepository
{
    
    private readonly AppDbContext _appDb;
    public VaccinePatientRepository(AppDbContext appDb) : base(appDb)
    {
        _appDb = appDb;
    }
    
    public IEnumerable<ImmunizationPatient> GetANonDeleted()
    {
        return base.GetAll()
                   .Where(x => x.Deleted == false);
    }

    public IEnumerable<ImmunizationPatient> GetAllDeleted()
    {
        return base.GetAll()
                   .Where(x => x.Deleted == true);
    }

    public void SoftDelete(Guid id)
    {
        var element = _appDb.ImmunizationPatients.Where(x =>
                                              x.Deleted.Equals(false) && x.Id.Equals(id));

        _appDb.Update(element);
        _appDb.SaveChanges();
    }

    public void RetrieveDeleted(Guid id)
    {
        var element = _appDb.ImmunizationPatients.Where(x =>
            x.Deleted.Equals(false) && x.Id.Equals(id));

        _appDb.Update(element);
        _appDb.SaveChanges();
    }
    
    public void Update(ImmunizationPatient result)
    {
        _appDb.Update(result);
        _appDb.SaveChanges();
    }
}
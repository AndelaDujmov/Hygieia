using HygieiaApp.DataAccess.Data;
using HygieiaApp.Models.Models;

namespace HygieiaApp.DataAccess.Repositories.Impl;

public class VaccineRepository : Repository<Immunization>, IVaccineRepository
{
    private readonly AppDbContext _appDb;
    
    public VaccineRepository(AppDbContext appDb) : base(appDb)
    {
        _appDb = appDb;
    }

    public void Update(Immunization immunization)
    {
        _appDb.Immunizations.Update(immunization);
    }

    public void Save()
    {
        _appDb.SaveChanges();
    }
}
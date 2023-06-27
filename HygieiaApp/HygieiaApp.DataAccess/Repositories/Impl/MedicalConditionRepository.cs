using HygieiaApp.DataAccess.Data;
using HygieiaApp.Models.Models;

namespace HygieiaApp.DataAccess.Repositories.Impl;

public class MedicalConditionRepository : Repository<MedicalCondition>, IMedicalConditionRepository
{
    
    private readonly AppDbContext _appDb;
    public MedicalConditionRepository(AppDbContext appDb) : base(appDb)
    {
        _appDb = appDb;
    }

    public void Update(MedicalCondition medicalCondition)
    {
        _appDb.MedicalConditions.Update(medicalCondition);
        _appDb.SaveChanges();
    }
    
    public IEnumerable<MedicalCondition> GetANonDeleted()
    {
        return base.GetAll()
            .Where(x => x.Deleted == false);
    }

    public IEnumerable<MedicalCondition> GetAllDeleted()
    {
        return base.GetAll()
            .Where(x => x.Deleted == true);
    }

    public void SoftDelete(Guid id)
    {
        var element = _appDb.MedicalConditions.Where(x =>
            x.Deleted.Equals(false) && x.Id.Equals(id));

        _appDb.Update(element);
        _appDb.SaveChanges();
    }

    public void RetrieveDeleted(Guid id)
    {
        var element = _appDb.MedicalConditions.Where(x =>
            x.Deleted.Equals(false) && x.Id.Equals(id));

        _appDb.Update(element);
        _appDb.SaveChanges();
    }
    
}
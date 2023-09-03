using HygieiaApp.DataAccess.Data;
using HygieiaApp.Models.Models;

namespace HygieiaApp.DataAccess.Repositories.Impl;

public class PatientConditionRepository : Repository<PatientMedicalCondition>, IPatientConditionRepository
{

    private readonly AppDbContext _appDb;
    public PatientConditionRepository(AppDbContext appDb) : base(appDb)
    {
    }
    
    public IEnumerable<PatientMedicalCondition> GetANonDeleted()
    {
        return base.GetAll()
            .Where(x => x.Deleted == false);
    }

    public IEnumerable<PatientMedicalCondition> GetAllDeleted()
    {
        return base.GetAll()
            .Where(x => x.Deleted == true);
    }

    public void SoftDelete(Guid id)
    {
        var element = _appDb.PatientMedicalConditions.Where(x =>
            x.Deleted.Equals(false) && x.Id.Equals(id));

        _appDb.Update(element);
        _appDb.SaveChanges();
    }

    public void RetrieveDeleted(Guid id)
    {
        var element = _appDb.PatientMedicalConditions.Where(x =>
            x.Deleted.Equals(false) && x.Id.Equals(id));

        _appDb.Update(element);
        _appDb.SaveChanges();
    }
    
}
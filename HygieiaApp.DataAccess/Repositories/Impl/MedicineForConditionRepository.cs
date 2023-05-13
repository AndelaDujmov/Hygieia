using HygieiaApp.DataAccess.Data;
using HygieiaApp.Models.Models;

namespace HygieiaApp.DataAccess.Repositories.Impl;

public class MedicineForConditionRepository : Repository<MedicalConditionMedication>, IMedicineForConditionRepository
{

    private readonly AppDbContext _appDb;
    public MedicineForConditionRepository(AppDbContext appDb) : base(appDb)
    {
        _appDb = appDb;
    }
    
    public IEnumerable<MedicalConditionMedication> GetANonDeleted()
    {
        return base.GetAll()
            .Where(x => x.Deleted == false);
    }

    public IEnumerable<MedicalConditionMedication> GetAllDeleted()
    {
        return base.GetAll()
            .Where(x => x.Deleted == true);
    }

    public void SoftDelete(Guid id)
    {
        var element = _appDb.MedicalConditionMedications.Where(x =>
            x.Deleted.Equals(false) && x.Id.Equals(id));

        _appDb.Update(element);
        _appDb.SaveChanges();
    }

    public void RetrieveDeleted(Guid id)
    {
        var element = _appDb.MedicalConditionMedications.Where(x =>
            x.Deleted.Equals(false) && x.Id.Equals(id));

        _appDb.Update(element);
        _appDb.SaveChanges();
    }
}
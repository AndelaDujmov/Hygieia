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
    }
    
}
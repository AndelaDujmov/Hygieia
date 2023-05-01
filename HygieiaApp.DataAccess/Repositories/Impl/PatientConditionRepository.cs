using HygieiaApp.DataAccess.Data;
using HygieiaApp.Models.Models;

namespace HygieiaApp.DataAccess.Repositories.Impl;

public class PatientConditionRepository : Repository<PatientMedicalCondition>, IPatientConditionRepository
{
    public PatientConditionRepository(AppDbContext appDb) : base(appDb)
    {
    }
}
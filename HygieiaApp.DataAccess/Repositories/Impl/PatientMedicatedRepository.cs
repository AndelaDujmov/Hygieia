using HygieiaApp.DataAccess.Data;
using HygieiaApp.Models.Models;

namespace HygieiaApp.DataAccess.Repositories.Impl;

public class PatientMedicatedRepository : Repository<MedicalConditionMedicated>, IPatientMedicatedRepository
{
    public PatientMedicatedRepository(AppDbContext appDb) : base(appDb)
    {
    }
}
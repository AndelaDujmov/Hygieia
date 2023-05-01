using HygieiaApp.DataAccess.Data;
using HygieiaApp.Models.Models;

namespace HygieiaApp.DataAccess.Repositories.Impl;

public class MedicineForConditionRepository : Repository<MedicalConditionMedication>, IMedicineForConditionRepository
{
    public MedicineForConditionRepository(AppDbContext appDb) : base(appDb)
    {
    }
}
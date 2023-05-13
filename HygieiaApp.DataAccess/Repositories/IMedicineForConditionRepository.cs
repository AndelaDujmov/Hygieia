using HygieiaApp.DataAccess.Repositories.Impl;
using HygieiaApp.Models.Models;

namespace HygieiaApp.DataAccess.Repositories;

public interface IMedicineForConditionRepository : IRepository<MedicalConditionMedication>, ISoftDeleteRepository<MedicalConditionMedication>
{
    
}
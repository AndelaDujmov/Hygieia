using HygieiaApp.Models.Models;
namespace HygieiaApp.DataAccess.Repositories;

public interface IMedicalConditionRepository : IRepository<MedicalCondition>, ISoftDeleteRepository<MedicalCondition>
{
    void Update(MedicalCondition medicalCondition);

    IEnumerable<MedicalCondition> GetMedications(List<Guid> medicalConditionUser);
}
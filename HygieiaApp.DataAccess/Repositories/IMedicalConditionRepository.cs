using HygieiaApp.Models.Models;
namespace HygieiaApp.DataAccess.Repositories;

public interface IMedicalConditionRepository : IRepository<MedicalCondition>
{
    void Update(MedicalCondition medicalCondition);
  
}
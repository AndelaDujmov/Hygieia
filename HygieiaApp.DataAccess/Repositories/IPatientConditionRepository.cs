using HygieiaApp.DataAccess.Data;
using HygieiaApp.Models.Models;

namespace HygieiaApp.DataAccess.Repositories;

public interface IPatientConditionRepository : IRepository<PatientMedicalCondition>, ISoftDeleteRepository<PatientMedicalCondition>
{

}
using HygieiaApp.Models.Models;

namespace HygieiaApp.DataAccess.Repositories;

public interface ITestResultPatientRepository : IRepository<TestResultsPatient>, ISoftDeleteRepository<TestResultsPatient>
{
    void Update(TestResultsPatient testResultsPatient);
}
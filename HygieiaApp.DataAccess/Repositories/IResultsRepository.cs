using HygieiaApp.Models.Models;

namespace HygieiaApp.DataAccess.Repositories;

public interface IResultsRepository : IRepository<TestResult>
{
    void Update(TestResult result);
   
}
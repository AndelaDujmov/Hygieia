using HygieiaApp.DataAccess.Data;
using HygieiaApp.Models.Models;

namespace HygieiaApp.DataAccess.Repositories.Impl;

public class ResultsRepository : Repository<TestResult>, IResultsRepository
{
    private readonly AppDbContext _appDb;
    
    public ResultsRepository(AppDbContext appDb) : base(appDb)
    {
        _appDb = appDb;
    }

    public void Update(TestResult result)
    {
        _appDb.TestResults.Update(result);
    }


}
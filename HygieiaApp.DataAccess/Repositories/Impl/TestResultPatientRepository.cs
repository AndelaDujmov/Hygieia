using HygieiaApp.DataAccess.Data;
using HygieiaApp.Models.Models;

namespace HygieiaApp.DataAccess.Repositories.Impl;

public class TestResultPatientRepository : Repository<TestResultsPatient>, ITestResultPatientRepository
{
    
    private readonly AppDbContext _appDb;
    public TestResultPatientRepository(AppDbContext appDb) : base(appDb)
    {
        _appDb = appDb;
    }
    
    public IEnumerable<TestResultsPatient> GetANonDeleted()
    {
        return base.GetAll()
            .Where(x => x.Deleted == false);
    }

    public IEnumerable<TestResultsPatient> GetAllDeleted()
    {
        return base.GetAll()
            .Where(x => x.Deleted == true);
    }

    public void SoftDelete(Guid id)
    {
        var element = _appDb.TestResultsPatients.Where(x =>
            x.Deleted.Equals(false) && x.Id.Equals(id));

        _appDb.Update(element);
        _appDb.SaveChanges();
    }

    public void RetrieveDeleted(Guid id)
    {
        var element = _appDb.TestResultsPatients.Where(x =>
            x.Deleted.Equals(false) && x.Id.Equals(id));

        _appDb.Update(element);
        _appDb.SaveChanges();
    }

    public void Update(TestResultsPatient testResultsPatient)
    {
        _appDb.Update(testResultsPatient);
        _appDb.SaveChanges();
    }
}
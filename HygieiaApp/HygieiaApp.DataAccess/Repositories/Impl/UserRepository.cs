using HygieiaApp.DataAccess.Data;
using HygieiaApp.Models.Models;

namespace HygieiaApp.DataAccess.Repositories.Impl;

public class UserRepository : Repository<User>, IUserRepository
{
    
    private readonly AppDbContext _appDb;
    public UserRepository(AppDbContext appDb) : base(appDb)
    {
        _appDb = appDb;
    }

    public IEnumerable<User> GetANonDeleted()
    {
        return base.GetAll()
            .Where(x => x.Deleted == false);
    }

    public IEnumerable<User> GetAllDeleted()
    {
        return base.GetAll()
            .Where(x => x.Deleted == true);
    }

    public void SoftDelete(Guid id)
    {
        var element = _appDb.Users.Where(x =>
            x.Deleted.Equals(false) && x.Id.Equals(id));

        _appDb.Update(element);
        _appDb.SaveChanges();
    }

    public void RetrieveDeleted(Guid id)
    {
        var element = _appDb.Users.Where(x =>
            x.Deleted.Equals(false) && x.Id.Equals(id));

        _appDb.Update(element);
        _appDb.SaveChanges();
    }
}
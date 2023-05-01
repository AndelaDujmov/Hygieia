using HygieiaApp.DataAccess.Data;
using HygieiaApp.Models.Models;

namespace HygieiaApp.DataAccess.Repositories.Impl;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AppDbContext appDb) : base(appDb)
    {
    }
}
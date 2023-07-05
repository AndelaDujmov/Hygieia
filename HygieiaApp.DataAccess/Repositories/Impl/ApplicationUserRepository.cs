using HygieiaApp.DataAccess.Data;
using HygieiaApp.Models;

namespace HygieiaApp.DataAccess.Repositories.Impl;

public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
{
    public ApplicationUserRepository(AppDbContext appDb) : base(appDb)
    {
    }
}
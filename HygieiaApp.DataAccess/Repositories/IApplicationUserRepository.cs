using HygieiaApp.Models;

namespace HygieiaApp.DataAccess.Repositories;

public interface IApplicationUserRepository : IRepository<ApplicationUser>
{
    public IEnumerable<ApplicationUser> GetUsers();
}
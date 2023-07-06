using HygieiaApp.DataAccess.Data;
using HygieiaApp.Models;

namespace HygieiaApp.DataAccess.Repositories.Impl;

public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
{
    private readonly AppDbContext _dbContext;
    public ApplicationUserRepository(AppDbContext appDb) : base(appDb)
    {
        _dbContext = appDb;
    }

    public IEnumerable<ApplicationUser> GetUsers()
    {
        var users = base.GetAll().ToList();
        var roles = _dbContext.Roles.ToList();
        var userroles = _dbContext.UserRoles.ToList();
        
        users.ForEach(user =>
        {
            var userRoleId = userroles.FirstOrDefault(userRole => userRole.UserId == user.Id).RoleId;
            user.Role = roles.FirstOrDefault(role => role.Id == userRoleId).Name;
        });

        return users;
    }
}
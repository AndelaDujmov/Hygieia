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

    public string GetRoleByUser(string userId)
    {
        var userrole = (from roleuser in _dbContext.UserRoles
                              where roleuser.UserId.Equals(userId) 
                              select roleuser.RoleId).FirstOrDefault();

        var role = (from r in _dbContext.Roles
                          where r.Id.Equals(userrole) 
                          select r.Name).FirstOrDefault();

        return role;
    }

    public ApplicationUser GetUserByRole(string rolename)
    {
        var role = (from rn in _dbContext.Roles
                          where rn.Name.Equals(rolename)
                          select rn.Id).First();

        var userrole = (from ur in _dbContext.UserRoles
                              where ur.RoleId.Equals(role) 
                              select ur.UserId).First();
        
        var user = (from u in _dbContext.ApplicationUsers
                                         where u.Id.Equals(userrole) 
                                         select u).First();
        return user;
    }

    public void UpdateUser(ApplicationUser applicationUser)
    {
        var user = _dbContext.ApplicationUsers.ToList().Where(x => x.Id.Equals(applicationUser.Id)).First();

        user.Email = applicationUser.Email;
        user.Gender = applicationUser.Gender;
        user.DateOfBirth = applicationUser.DateOfBirth;

        _dbContext.ApplicationUsers.Update(user);
        _dbContext.SaveChanges();
    }
}
using HygieiaApp.DataAccess.Data;
using HygieiaApp.Models;
using HygieiaApp.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HygieiaApp.DataAccess.DbInitializer;

public class DbInitializer : IDbInitalizer
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly AppDbContext _appDbContext;

    public DbInitializer(RoleManager<IdentityRole> roleManager,
                         UserManager<IdentityUser> userManager,
                         AppDbContext appDbContext)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _appDbContext = appDbContext;
    }

    private ApplicationUser? GetUserByUsername(string username)
    {
        return _appDbContext.ApplicationUsers.SingleOrDefault(x => x.UserName.Equals(username));
    }
    
    public void Initialize()
    {
        try
        {
            if (_appDbContext.Database.GetPendingMigrations().Count() > 0)
            {
                _appDbContext.Database.Migrate();
            }
        }
        catch(Exception e)
        {
            
        }
        
        if (!_roleManager.RoleExistsAsync(RoleName.Administrator.ToString()).GetAwaiter().GetResult()) 
            _roleManager.CreateAsync(new IdentityRole(RoleName.Administrator.ToString())).GetAwaiter().GetResult();
        if (!_roleManager.RoleExistsAsync(RoleName.Patient.ToString()).GetAwaiter().GetResult()) 
            _roleManager.CreateAsync(new IdentityRole(RoleName.Patient.ToString())).GetAwaiter().GetResult();
        if (!_roleManager.RoleExistsAsync(RoleName.Doctor.ToString()).GetAwaiter().GetResult()) 
            _roleManager.CreateAsync(new IdentityRole(RoleName.Doctor.ToString())).GetAwaiter().GetResult();

        _userManager.CreateAsync(new ApplicationUser
        {
            Oib = 23456765456,
            Mbo = 234567876,
            UserName = "andeladujmov199",
            Email = "andeladujmov3@gmail.com",
            PhoneNumber = "+3859176543",
            DateOfBirth = new DateTime(1999, 7, 4),
            FirstName = "Anđela",
            LastName = "Dujmov",
            Deleted = false,
            Gender = Gender.Female
        }, "AdminA040799.").GetAwaiter().GetResult();

        var user = GetUserByUsername("andeladujmov199");
        _userManager.AddToRoleAsync(user, RoleName.Administrator.ToString()).GetAwaiter().GetResult();
    }
}
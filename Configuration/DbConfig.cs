using Hygieia.Entities;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Hygieia.Configuration;

public class DbConfig : DbContext
{
    public DbConfig(DbContextOptions<DbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<Role> Roles;
}
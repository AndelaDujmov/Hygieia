using HygieiaApp.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace HygieiaApp.DataAccess.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("server=localhost;database=hygieia2;uid=root;pwd=andu404595;");
    }
    
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Immunization> Immunizations{ get; set; }
    public DbSet<MedicalCondition> MedicalConditions { get; set; }
    public DbSet<Medication> Medications { get; set; }
    public DbSet<TestResult> TestResults { get; set; }
    public DbSet<PatientDoctor> PatientDoctors { get; set; }
    public DbSet<Scheduler> Schedulers{ get; set; }
    public DbSet<PatientMedicalCondition> PatientMedicalConditions { get; set; }
    public DbSet<MedicalConditionMedication> MedicalConditionMedications { get; set; }
    public DbSet<MedicalConditionMedicated> MedicalConditionMedicateds { get; set; }
}
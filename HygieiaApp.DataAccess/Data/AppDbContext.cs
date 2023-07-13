using HygieiaApp.DataAccess.Migrations;
using HygieiaApp.Models;
using HygieiaApp.Models.Enums;
using HygieiaApp.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HygieiaApp.DataAccess.Data;

public class AppDbContext : IdentityDbContext<IdentityUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("server=localhost;database=hygieia;uid=root;pwd=andu404595;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        base.OnModelCreating(modelBuilder);
        
    }
    
    public DbSet<Immunization> Immunizations{ get; set; }
    public DbSet<MedicalCondition> MedicalConditions { get; set; }
    public DbSet<Medication> Medications { get; set; }
    public DbSet<TestResult> TestResults { get; set; }
    public DbSet<PatientDoctor> PatientDoctors { get; set; }
    public DbSet<Scheduler> Schedulers{ get; set; }
    public DbSet<PatientMedicalCondition> PatientMedicalConditions { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<ImmunizationPatient> ImmunizationPatients { get; set; }
    public DbSet<TestResultsPatient> TestResultsPatients { get; set; }
    public DbSet<MedicalConditionMedication> MedicalConditionMedications { get; set; }
    public DbSet<MedicalConditionMedicated> MedicalConditionMedicateds { get; set; }
}
using HygieiaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HygieiaApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("server=localhost;database=hygieia;uid=root;pwd=andu404595;");
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
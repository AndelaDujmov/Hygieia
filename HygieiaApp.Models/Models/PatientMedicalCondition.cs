using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HygieiaApp.Models.Enums;


namespace HygieiaApp.Models.Models;

public class PatientMedicalCondition 
{
    [Key]
    public Guid Id { get; set; }
    [ForeignKey("User")]
    public Guid PatientId { get; set; }
    public User Patient { get; set; }
    public List<MedicalCondition> MedicalCondition { get; set; }
    public DateTime DateOfDiagnosis { get; set; }
    public Stage Stage { get; set; }
    public bool Deleted { get; set; } = false;
}

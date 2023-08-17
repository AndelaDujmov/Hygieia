using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HygieiaApp.Models.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace HygieiaApp.Models.Models;

public class PatientMedicalCondition 
{
    [Key]
    public Guid Id { get; set; }
    public string? UserId { get; set; }
    [ForeignKey("UserId")]
    [ValidateNever]
    public ApplicationUser? User { get; set; }
    public Guid? MedicalConditionId { get; set; }
    [ForeignKey("MedicalConditionId")]
    [ValidateNever]
    public MedicalCondition? MedicalCondition { get; set; }
    public DateTime DateOfDiagnosis { get; set; }
    public Stage Stage { get; set; }
    public bool Deleted { get; set; } = false;
}

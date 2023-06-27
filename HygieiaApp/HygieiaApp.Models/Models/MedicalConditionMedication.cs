using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HygieiaApp.Models.Models;

public class MedicalConditionMedication 
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid MedicalConditionId { get; set; }
    [ForeignKey("MedicalConditionId")]
    [ValidateNever]
    public MedicalCondition? MedicalCondition { get; set; }
    public Guid MedicationId { get; set; }
    [ForeignKey("MedicationId")]
    [ValidateNever]
    public Medication? Medication { get; set; } 
    public decimal MaximumDosage { get; set; }
    public bool Deleted { get; set; } = false;

 
}

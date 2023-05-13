using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HygieiaApp.Models.Models;

public class MedicalConditionMedication 
{
    [Key]
    public Guid Id { get; set; }
    [ForeignKey("MedicalCondition")]
    public Guid MedicalConditionId { get; set; }
    public MedicalCondition MedicalCondition { get; set; }
    [ForeignKey("Medication")]
    public Guid MedicationId { get; set; }
    public Medication Medication { get; set; }
    public decimal MaximumDosage { get; set; }
    public bool Deleted { get; set; } = false;
}

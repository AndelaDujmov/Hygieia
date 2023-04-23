using System.ComponentModel.DataAnnotations;

namespace HygieiaApp.Models;

public class MedicalConditionMedication 
{
    [Key]
    public Guid Id { get; set; }
    public int MedicalConditionId { get; set; }
    public MedicalCondition MedicalCondition { get; set; }
    public int MedicationId { get; set; }
    public Medication Medication { get; set; }
    public decimal MaximumDosage { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HygieiaApp.Models.Models;

public class MedicalConditionMedicated 
{
    [Key] public Guid Id { get; set; }
    public Guid MedicalConditionPatientId { get; set; }
    [ForeignKey("MedicalConditionPatientId")]
    public PatientMedicalCondition MedicalConditionPatient { get; set; }
    public Guid MedicalConditionMedicationId { get; set; }
    [ForeignKey("MedicalConditionMedicationId")]
    [ValidateNever]
    public MedicalConditionMedication MedicalConditionMedication { get; set; }
    [Range(0d, 1000d, ErrorMessage = "Dosage must be between 0 and 1000 mg")]
    public decimal Dosage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Reason { get; set; }
    public int Frequency { get; set; }
    public bool Deleted { get; set; } = false;
}

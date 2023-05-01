using System.ComponentModel.DataAnnotations;

namespace HygieiaApp.Models.Models;

public class MedicalConditionMedicated 
{
    [Key]
    public Guid Id { get; set; }
    public int MedicalConditionPatientId { get; set; }
    public PatientMedicalCondition MedicalConditionPatient { get; set; }
    public int MedicalConditionMedicationId { get; set; }
    public MedicalConditionMedication MedicalConditionMedication { get; set; }
    [Range(0d, 1000d, ErrorMessage = "Dosage must be between 0 and 1000 mg")]
    public decimal Dosage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Reason { get; set; }
    public int Frequency { get; set; }
}

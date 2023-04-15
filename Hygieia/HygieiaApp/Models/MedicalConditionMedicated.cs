using System.ComponentModel.DataAnnotations;

namespace HygieiaApp.Models;

public class MedicalConditionMedicated 
{
    [Key]
    public Guid Id { get; set; }
    public int MedicalConditionPatientId { get; set; }
    public PatientMedicalCondition MedicalConditionPatient { get; set; }
    public int MedicalConditionMedicationId { get; set; }
    public MedicalConditionMedication MedicalConditionMedication { get; set; }
    public decimal Dosage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Reason { get; set; }
    public int Frequency { get; set; }
}

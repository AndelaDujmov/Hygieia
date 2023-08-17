using HygieiaApp.Models.Models;

namespace HygieiaApp.Models.DTO;

public class ConditionMedicationViewDto
{
    public PatientMedicalCondition PatientMedicalCondition { get; set; }
    public IEnumerable<MedicalConditionMedicated> ConditionMedicated { get; set; }
}
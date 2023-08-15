using HygieiaApp.Models.Models;

namespace HygieiaApp.Models.DTO;

public class PatientMedicalHistoryDto
{
    public ApplicationUser? Patient { get; set; }
    public List<MedicalCondition>? Conditions { get; set; }
}
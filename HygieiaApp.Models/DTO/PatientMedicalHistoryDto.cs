using HygieiaApp.Models.Models;

namespace HygieiaApp.Models.DTO;

public class PatientMedicalHistoryDto
{
    public ApplicationUser PatientName { get; set; }
    public IEnumerable<PatientMedicalCondition> Conditions { get; set; }
}
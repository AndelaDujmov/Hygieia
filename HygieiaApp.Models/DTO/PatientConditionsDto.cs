using HygieiaApp.Models.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HygieiaApp.Models.DTO;

public class PatientConditionsDto
{
    public MedicalCondition? MedicalCondition { get; set; }
    public PatientMedicalCondition? PatientMedicalCondition { get; set; }
 
    public Guid SelectedMedication { get; set; }

    [ValidateNever]
    public IEnumerable<SelectListItem>? MedicalConditions{ get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem>? MedicationSelectList{ get; set; }
    
    public string? patientName { get; set; }
}
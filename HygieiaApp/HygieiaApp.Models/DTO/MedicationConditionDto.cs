using System.ComponentModel.DataAnnotations.Schema;
using HygieiaApp.Models.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HygieiaApp.Models.DTO;

public class MedicationConditionDto
{
    public MedicalCondition MedicalCondition { get; set; }
    public MedicalConditionMedication? MedicalConditionMedication { get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem>? SelectListItems { get; set; }

  
}
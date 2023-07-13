using HygieiaApp.Models.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HygieiaApp.Models.DTO;

public class PatientVaccinationDto
{
    public ImmunizationPatient? ImmunizationForPatient { get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem> Vaccines { get; set; }
    public IEnumerable<ImmunizationPatient>? ImmunizationPatients { get; set; }
    public string? ChosenType { get; set; }
    public string? FullNamePatient { get; set; }
}
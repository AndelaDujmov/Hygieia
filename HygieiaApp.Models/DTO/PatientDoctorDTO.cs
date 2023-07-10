using HygieiaApp.Models.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HygieiaApp.Models.DTO;

public class PatientDoctorDTO
{
    public ApplicationUser User { get; set; }
    public string? Selected { get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem>? ItemsForDoctor { get; set; }
    public TestResultsPatient? Tests { get; set; }
    public TestResult? TestType { get; set; }
    public ApplicationUser? Patient { get; set; }
}
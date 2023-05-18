using HygieiaApp.Models.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HygieiaApp.Models.DTO;

public class TestUserDto
{
    public TestResultsPatient ResultsPatient { get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem> TypeOfTest { get; set; }
}
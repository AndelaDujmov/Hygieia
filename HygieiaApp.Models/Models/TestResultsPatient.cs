using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HygieiaApp.Models.Models;

public class TestResultsPatient
{
    [Key] public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime DateOfTesting { get; set; }
    public string Results { get; set; } 
    public string PatientId { get; set; }
    [ForeignKey("PatientId")]
    [ValidateNever]
    public ApplicationUser? Patient { get; set; }
    public Guid TestResultId { get; set; }
    [ForeignKey("TestResultId")]
    [ValidateNever]
    public TestResult? TestResult { get; set; }
    public bool Deleted { get; set; } = false;
}
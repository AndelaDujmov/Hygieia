using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HygieiaApp.Models.Models;

public class TestResultsPatient
{
    [Key]
    public Guid Id { get; set; }
    public DateTime DateOfTesting { get; set; }
    public string Results { get; set; } 
    public Guid PatientId { get; set; }
    [ForeignKey("PatientId")]
    public User Patient { get; set; }
    public Guid TestResultId { get; set; }
    [ForeignKey("TestResultId")]
    public TestResult TestResult { get; set; }
    public bool Deleted { get; set; } = false;
}
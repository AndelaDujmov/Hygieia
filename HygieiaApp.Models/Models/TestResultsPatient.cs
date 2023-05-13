using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HygieiaApp.Models.Models;

public class TestResultsPatient
{
    [Key]
    public Guid Id { get; set; }
    public DateTime DateOfTesting { get; set; }
    public string Results { get; set; }
    [ForeignKey("User")]
    public Guid PatientId { get; set; }
    public User Patient { get; set; }
    public bool Deleted { get; set; } = false;
}
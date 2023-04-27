using System.ComponentModel.DataAnnotations;

namespace HygieiaApp.Razor.Models;

public class TestResult 
{
    [Key]
    public Guid Id { get; set; }
    public string Type { get; set; }
    public DateTime DateOfTesting { get; set; }
    public string Results { get; set; }
    public int PatientId { get; set; }
    public User Patient { get; set; }
}

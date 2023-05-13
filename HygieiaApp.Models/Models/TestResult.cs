using System.ComponentModel.DataAnnotations;

namespace HygieiaApp.Models.Models;

public class TestResult 
{
    [Key]
    public Guid Id { get; set; }
    public string Type { get; set; }
   
}

using System.ComponentModel.DataAnnotations;
namespace HygieiaApp.Models.Models;

public class Immunization
{
    [Key]
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string UsedFor { get; set; }
    
}

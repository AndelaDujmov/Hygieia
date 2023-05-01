using System.ComponentModel.DataAnnotations;



namespace HygieiaApp.Models.Models;
public class Medication 
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Class { get; set; }
    public string Type { get; set; }
    public string SideEffects { get; set; }
    public bool Deleted { get; set; } = false;
}

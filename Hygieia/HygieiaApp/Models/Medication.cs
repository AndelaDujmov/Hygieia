using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Objects.DataClasses;
using HygieiaApp.Utils.ComplexObjects;

namespace HygieiaApp.Models;
public class Medication 
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Class { get; set; }
    public string Type { get; set; }
    public string SideEffects { get; set; }
    [EdmComplexProperty()]
    [NotMapped]
    public Allergies? Allergies { get; set; }
    public bool Deleted { get; set; } = false;
}

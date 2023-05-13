using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HygieiaApp.Models.Models;

public class ImmunizationPatient 
{
    [Key]
    public Guid Id { get; set; }
    public DateTime DateOfVaccination { get; set; }
    [ForeignKey("Immunization")]
    public Guid ImmunizationId { get; set; }
    public Immunization Immunization { get; set; }
    [ForeignKey("User")]
    public Guid UserId { get; set; }
    public User User { get; set; }
    public bool Deleted { get; set; } = false;
}
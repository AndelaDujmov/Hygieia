using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HygieiaApp.Models.Models;

public class ImmunizationPatient 
{
    [Key]
    public Guid Id { get; set; }

    public DateTime DateOfVaccination { get; set; }
    public Guid ImmunizationId { get; set; }
    [ForeignKey("ImmunizationId")]
    public Immunization Immunization { get; set; }
    public Guid UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }
    public bool Deleted { get; set; } = false;
}
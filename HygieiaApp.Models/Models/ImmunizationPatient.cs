using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HygieiaApp.Models.Models;

public class ImmunizationPatient 
{
    [Key]
    public Guid Id { get; set; }

    public DateTime DateOfVaccination { get; set; }
    public Guid ImmunizationId { get; set; }
    [ForeignKey("ImmunizationId")]
    public Immunization Immunization { get; set; }
    public string UserId { get; set; }
    [ForeignKey("UserId")]
    [ValidateNever]
    public ApplicationUser User { get; set; }
    public bool Deleted { get; set; } = false;
}
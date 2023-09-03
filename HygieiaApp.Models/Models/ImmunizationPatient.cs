using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HygieiaApp.Models.Models;

public class ImmunizationPatient 
{
    [Key]
    public Guid Id { get; set; }

    public DateTime DateOfVaccination { get; set; }
    public Guid? ImmunizationId { get; set; }
    [ForeignKey("ImmunizationId")]
    [ValidateNever]
    public Immunization? Immunization { get; set; }
    [AllowNull]
    public string? UserId { get; set; }
    [ForeignKey("UserId")]
    [ValidateNever]
    public ApplicationUser? User { get; set; }
    [NotMapped]
    public string? Selected { get; set; }
    [NotMapped]
    public string? MadeByDoctor { get; set; }
    public bool Deleted { get; set; } = false;
}
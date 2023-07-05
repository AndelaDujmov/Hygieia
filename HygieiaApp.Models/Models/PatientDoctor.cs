using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HygieiaApp.Models.Models;

public class PatientDoctor 
{
    [Key]
    public Guid Id { get; set; }
    public string PatientsId { get; set; }
    [ForeignKey("PatientsId")]
    [ValidateNever]
    public ApplicationUser Patient { get; set; }
    public string DoctorsId { get; set; }
    [ForeignKey("DoctorsId")]
    [ValidateNever]
    public ApplicationUser Doctor { get; set; }
    public bool Deleted { get; set; } = false;
}

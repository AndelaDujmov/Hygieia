using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HygieiaApp.Models.Models;

public class Scheduler
{
    [Key] public Guid Id { get; set; } = Guid.NewGuid();
    public string Reminder { get; set; }
    public DateTime DateOfAppointment { get; set; }
    public DateTime EndDate { get; set; }
    public string? DoctorId { get; set; }
    [ForeignKey("DoctorId")]
    [ValidateNever]
    public ApplicationUser? Doctor { get; set; }
    public string? PatientId { get; set; }
    [ForeignKey("PatientId")]
    [ValidateNever]
    public ApplicationUser? Patient { get; set; }
    public bool Deleted { get; set; } = false;
}

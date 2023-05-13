using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HygieiaApp.Models.Models;

public class Scheduler 
{
    [Key]
    public Guid Id { get; set; }
    public string Reminder { get; set; }
    public DateTime DateOfAppointment { get; set; }
    [ForeignKey("User")]
    public Guid DoctorId { get; set; }
    public User Doctor { get; set; }
    [ForeignKey("User")]
    public Guid PatientId { get; set; }
    public User Patient { get; set; }
    public bool Deleted { get; set; } = false;
}

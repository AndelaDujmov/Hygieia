using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HygieiaApp.Models.Models;

public class Scheduler 
{
    [Key]
    public Guid Id { get; set; }
    public string Reminder { get; set; }
    public DateTime DateOfAppointment { get; set; }
    public Guid DoctorId { get; set; }
    [ForeignKey("DoctorId")]
    public User Doctor { get; set; }
    public Guid PatientId { get; set; }
    [ForeignKey("PatientId")]
    public User Patient { get; set; }
    public bool Deleted { get; set; } = false;
}

using System.ComponentModel.DataAnnotations;

namespace HygieiaApp.Razor.Models;

public class Scheduler 
{
    [Key]
    public Guid Id { get; set; }
    public string Reminder { get; set; }
    public DateTime DateOfAppointment { get; set; }
    public int DoctorId { get; set; }
    public User Doctor { get; set; }
    public int PatientId { get; set; }
    public User Patient { get; set; }
}

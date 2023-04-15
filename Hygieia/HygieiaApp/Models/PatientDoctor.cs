using System.ComponentModel.DataAnnotations;

namespace HygieiaApp.Models;

public class PatientDoctor 
{
    [Key]
    public Guid Id { get; set; }
    public int PatientsId { get; set; }
    public User Patient { get; set; }
    public int DoctorsId { get; set; }
    public User Doctor { get; set; }
}

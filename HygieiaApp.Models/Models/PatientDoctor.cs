using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HygieiaApp.Models.Models;

public class PatientDoctor 
{
    [Key]
    public Guid Id { get; set; }
    [ForeignKey("User")]
    public Guid PatientsId { get; set; }
    public User Patient { get; set; }
    [ForeignKey("User")]
    public Guid DoctorsId { get; set; }
    public User Doctor { get; set; }
    public bool Deleted { get; set; } = false;
}

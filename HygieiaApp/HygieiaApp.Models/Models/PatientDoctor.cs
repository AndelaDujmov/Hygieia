using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HygieiaApp.Models.Models;

public class PatientDoctor 
{
    [Key]
    public Guid Id { get; set; }
    public Guid PatientsId { get; set; }
    [ForeignKey("PatientsId")]
    public User Patient { get; set; }
    public Guid DoctorsId { get; set; }
    [ForeignKey("DoctorsId")]
    public User Doctor { get; set; }
    public bool Deleted { get; set; } = false;
}

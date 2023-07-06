using HygieiaApp.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HygieiaApp.Models.DTO;

public class PatientDoctorDTO
{
    public ApplicationUser User { get; set; }
    public PatientDoctor Connection { get; set; }
    public IEnumerable<SelectListItem> ItemsForDoctor { get; set; }
}
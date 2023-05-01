using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using HygieiaApp.Models.Enums;

namespace HygieiaApp.Models.Models;

public class MedicalCondition
{
    [Key]
    public Guid Id { get; set; }
    public ConditionCategory Category { get; set; }
    public string Type { get; set; }
    public string Symptoms { get; set; }
    [DisplayName("Name Of Diagnosis")]
    public string NameOfDiagnosis { get; set; }
    public string Treatment { get; set; }
    public bool Deleted { get; set; } = false;
}

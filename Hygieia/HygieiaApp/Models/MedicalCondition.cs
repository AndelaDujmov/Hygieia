using System.ComponentModel.DataAnnotations;
using HygieiaApp.Utils.Enums;

namespace HygieiaApp.Models;

public class MedicalCondition
{
    [Key]
    public Guid Id { get; set; }
    public ConditionCategory Category { get; set; }
    public string Type { get; set; }
    public string Symptoms { get; set; }
    public string NameOfDiagnosis { get; set; }
    public string Treatment { get; set; }
    public bool Deleted { get; set; } = false;
}

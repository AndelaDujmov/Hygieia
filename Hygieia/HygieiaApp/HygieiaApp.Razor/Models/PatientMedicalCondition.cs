﻿using System.ComponentModel.DataAnnotations;
using HygieiaApp.Razor.Utils.Enums;


namespace HygieiaApp.Razor.Models;

public class PatientMedicalCondition 
{
    [Key]
    public Guid Id { get; set; }
    public int PatientId { get; set; }
    public User Patient { get; set; }
    public int MedicalConditionId { get; set; }
    public List<MedicalCondition> MedicalCondition { get; set; }
    public DateTime DateOfDiagnosis { get; set; }
    public Stage Stage { get; set; }
}

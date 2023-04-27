using System.ComponentModel.DataAnnotations;

namespace HygieiaApp.Razor.Models;

public class Immunization
{
    [Key]
    public Guid Id { get; set; }
    public DateTime DateOfVaccination { get; set; }
    public string Type { get; set; }
    public string UsedFor { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public bool Deleted { get; set; } = false;
}
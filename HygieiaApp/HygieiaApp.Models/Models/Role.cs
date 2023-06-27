using System.ComponentModel.DataAnnotations;
using HygieiaApp.Models.Enums;


namespace HygieiaApp.Models.Models;

public class Role 
{
    [Key]
    public Guid Id { get; set; }
    public RoleName Name { get; set; }
}

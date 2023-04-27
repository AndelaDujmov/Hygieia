using System.ComponentModel.DataAnnotations;
using HygieiaApp.Razor.Utils.Enums;


namespace HygieiaApp.Razor.Models;

public class Role 
{
    [Key]
    public Guid Id { get; set; }
    public RoleName Name { get; set; }
}

using System.ComponentModel.DataAnnotations;
using HygieiaApp.Utils.Enums;

namespace HygieiaApp.Models;

public class Role 
{
    [Key]
    public Guid Id { get; set; }
    public RoleName Name { get; set; }
}

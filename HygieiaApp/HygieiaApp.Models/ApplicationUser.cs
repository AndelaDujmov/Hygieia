using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace HygieiaApp.Models;

public class ApplicationUser : IdentityUser
{
    [Required]
    public int UserName { get; set; }
    public string? Zipcode { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public string? Address { get; set; }
}
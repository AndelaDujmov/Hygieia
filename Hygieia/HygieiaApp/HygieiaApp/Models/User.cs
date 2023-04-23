using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using HygieiaApp.Utils.Enums;
using Microsoft.EntityFrameworkCore;

namespace HygieiaApp.Models;

[Index(nameof(Email), IsUnique = true)]
public class User 
{
    [Key]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "First name field is required!")]
    [StringLength(maximumLength: 30, MinimumLength = 3)]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Last name field is required")]
    [StringLength(maximumLength: 30, MinimumLength = 2)]
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Username { get; set; }
    [Required(ErrorMessage = "Password field is required!")]
    [StringLength(maximumLength: 15, MinimumLength = 6)]
    [PasswordPropertyText]
    public string Password { get; set; }
    [Required(ErrorMessage = "Email field is required!")]
    [StringLength(maximumLength: 100, MinimumLength = 15)]
    [EmailAddress]
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public Gender Gender { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }
    public bool Deleted { get; set; } = false;
}

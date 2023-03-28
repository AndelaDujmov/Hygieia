using Hygieia.Utils.Enums;

namespace Hygieia.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public int RoleID { get; set; }
        public Role Role { get; set; }
        public bool Deleted { get; set; }

    }
    
    
}

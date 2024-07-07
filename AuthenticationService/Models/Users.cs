using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EstateManager.Models
{
    public class Users: IdentityUser<int>
    {
        [Key] 
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required Guid Identifier { get; set; }
        public required DateOnly Dob { get; set; }
        public required DateTime CreatedOn { get; set; }
        public ICollection<UserRole> UserRoles { get; set; } = [];
    }
}

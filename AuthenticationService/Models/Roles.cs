using Microsoft.AspNetCore.Identity;

namespace EstateManager.Models
{
    public class Roles : IdentityRole<int> {

        public ICollection<UserRole> UserRoles { get; set; } = [];
    }
}

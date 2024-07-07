using Microsoft.AspNetCore.Identity;

namespace EstateManager.Models
{
    public class UserRole : IdentityUserRole<int> {
        public Users User { get; set; } = null!;
        public Roles Role{ get; set; } = null!;
    }
}

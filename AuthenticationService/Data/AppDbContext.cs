using EstateManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EstateManager.Data
{
    public class AppDbContext(DbContextOptions options) : IdentityDbContext<Users, Roles, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>(options)
    {

        public DbSet<Users> Users { get; set; }     
        public  DbSet<Roles>  Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Users>().HasMany(u => u.UserRoles).WithOne(u => u.User).HasForeignKey(u => u.UserId).IsRequired();
            
            builder.Entity<Roles>().HasMany(u => u.UserRoles).WithOne(u => u.Role).HasForeignKey(u => u.RoleId).IsRequired();

        }
    }
}

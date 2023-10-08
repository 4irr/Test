using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Persistence
{
    public class ApplicationContext : IdentityDbContext<AppUser, AppRole, string>, IApplicationContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
                        .HasMany(u => u.Roles)
                        .WithMany(r => r.Users)
                        .UsingEntity<IdentityUserRole<string>>
                        (au => au.HasOne<AppRole>().WithMany(role => role.UserRoles).HasForeignKey(u => u.RoleId),
                        au => au.HasOne<AppUser>().WithMany(user => user.UserRoles).HasForeignKey(r => r.UserId));
        }
    }
}

using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class DataSeed
    {
        public static async Task SeedDataAsync(ApplicationContext context, UserManager<AppUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                var roles = new List<IdentityRole>
                {
                    new IdentityRole { Name = "User" },
                    new IdentityRole { Name = "Admin" },
                    new IdentityRole { Name = "Support" },
                    new IdentityRole { Name = "SuperAdmin" }
                };

                foreach(var role in roles)
                {
                    var result = await roleManager.CreateAsync(role);
                }
            }

            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        DisplayName = "user1",
                        UserName = "user1",
                        Email = "testuserfirst@test.com",
                        Age = 20
                    },

                    new AppUser
                    {
                        DisplayName = "user2",
                        UserName = "user2",
                        Email = "testusersecond@test.com",
                        Age = 30
                    }
                };

                foreach (var user in users)
                {
                    var result = await userManager.CreateAsync(user, "password");

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, "Admin");
                    }
                }
            }
        }
    }
}

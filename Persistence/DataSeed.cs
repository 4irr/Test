using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class DataSeed
    {
        public static async Task SeedDataAsync(ApplicationContext context, UserManager<AppUser> userManager, 
            RoleManager<AppRole> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                var roles = new List<AppRole>
                {
                    new AppRole { Name = "User" },
                    new AppRole { Name = "Admin" },
                    new AppRole { Name = "Support" },
                    new AppRole { Name = "SuperAdmin" }
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

using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class DataSeed
    {
        public static async Task SeedDataAsync(ApplicationContext context, UserManager<AppUser> userManager)
        {
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
                }
            }
        }
    }
}

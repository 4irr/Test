using Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                                            DisplayName = "TestUserFirst",
                                            UserName = "TestUserFirst",
                                            Email = "testuserfirst@test.com",
                                            Age = 20
                                        },

                                    new AppUser
                                        {
                                            DisplayName = "TestUserSecond",
                                            UserName = "TestUserSecond",
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

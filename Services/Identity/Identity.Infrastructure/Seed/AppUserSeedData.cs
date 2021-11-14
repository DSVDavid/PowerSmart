using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.Domain;
using Microsoft.AspNetCore.Identity;

namespace Identity.Infrastructure.Seed
{
    public static class AppUserSeedData
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager,
        RoleManager<AppRole> roleManager)
        {

            if (!userManager.Users.Any())
            {
                if (!roleManager.Roles.Any())
                {
                    var roles = new List<AppRole>{
                    new AppRole{Name="Admin"},
                    new AppRole{Name="BasicUser"}
                    };

                    foreach (var role in roles)
                    {
                        await roleManager.CreateAsync(role);
                    }
                }


                var adminUser = new AppUser()
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com",
                    FirstName = "System",
                    LastName = "Admin",
                    Address = new Address
                    {
                        Street = "Street 1",
                        City = "Craiova",
                        Country = "Romania",
                        ZipCode = "200200",
                        Details = "Number 1, Ap 5"
                    }

                };

                await userManager.CreateAsync(adminUser, "Pa$$w0rd");

                await userManager.AddToRoleAsync(adminUser, "Admin");

            }

        }
    }
}
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagement.Models
{
    public static class IdentityHelper
    {
        public const string Realtor = "Realtor";
        public const string Buyer = "Buyer";

        public static void SetIdentityOptions(IdentityOptions options)
        {
            // set sign-in options
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;

            // Set password strength
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 8;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = false;
        }

        public static async Task CreateRoles(IServiceProvider provider, params string[] roles)
        {
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();

            // Create role if does not exist
            foreach (string role in roles)
            {
                bool doesRoleExist = await roleManager.RoleExistsAsync(role);
                if (!doesRoleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        public static async Task CreateDefaultRealtor(IServiceProvider serviceProvider)
        {
            const string email = "realtor1@realtor.com";
            const string username = "realtor1";
            const string password = "Ibuyhouses";

            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // check if any users in DB
            if (userManager.Users.Count() == 0)
            {
                IdentityUser realtor = new IdentityUser()
                {
                    Email = email,
                    UserName = username

                };

                // Create the realtor
                await userManager.CreateAsync(realtor, password);

                // Add to realtor role
                await userManager.AddToRoleAsync(realtor, Realtor);
            }
        }
    }
}

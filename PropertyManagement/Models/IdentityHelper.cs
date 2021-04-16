using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagement.Models
{
    public static class IdentityHelper
    {
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
    }
}

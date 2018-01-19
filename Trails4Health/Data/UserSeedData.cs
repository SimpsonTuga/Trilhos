using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trails4Health.Models;

namespace Trails4Health.Data
{
    public class UserSeedData
    {
        public static async Task EnsurePopulatedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            const string adminName = "Admin";
            const string adminPass = "Secret123$";
            const string customerName = "john";
            const string customerPass = adminPass;


            if (!await roleManager.RoleExistsAsync("Administrator"))
            {
                await roleManager.CreateAsync(new IdentityRole("Administrator"));
            }

            if (!await roleManager.RoleExistsAsync("Customer"))
            {
                await roleManager.CreateAsync(new IdentityRole("Customer"));
            }

            // Create other roles ...

            ApplicationUser admin = await userManager.FindByNameAsync(adminName);
            if (admin == null)
            {
                admin = new ApplicationUser { UserName = adminName };
                await userManager.CreateAsync(admin, adminPass);
            }

            if (!await userManager.IsInRoleAsync(admin, "Administrator"))
            {
                await userManager.AddToRoleAsync(admin, "Administrator");
            }

            ApplicationUser customer = await userManager.FindByNameAsync(customerName);
            if (customer == null)
            {
                customer = new ApplicationUser { UserName = customerName };
                await userManager.CreateAsync(customer, customerPass);
            }

            if (!await userManager.IsInRoleAsync(customer, "Customer"))
            {
                await userManager.AddToRoleAsync(customer, "Customer");
            }
        }
    }
}


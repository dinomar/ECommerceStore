using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace ECommerceStore.Models
{
    public static class IdentitySeedData
    {
        private const string _adminEmail = "admin@store.local";
        private const string _adminName = "Admin";
        private const string _adminPassword = "Admin123$";

        private const string _adminRole = "Admins";

        public static async Task EnsurePopulated(IServiceProvider serviceProvider)
        {
            UserManager<IdentityUser> userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();


            IdentityUser adminUser = await userManager.FindByEmailAsync(_adminEmail);
            if (adminUser == null)
            {
                if (await roleManager.FindByNameAsync(_adminRole) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(_adminRole));
                }

                adminUser = new IdentityUser(_adminName);
                adminUser.Email = _adminEmail;
                IdentityResult identityResult = await userManager.CreateAsync(adminUser, _adminPassword);
                if (identityResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, _adminRole);
                }
            }
        }
    }
}

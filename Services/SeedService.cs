using Fahasa.Data;
using Fahasa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;

namespace Fahasa.Services
{
    public class SeedService
    {
        public static async Task SeedDatabase(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<SeedService>>();

            try
            {
                // Ensure the database is ready
                logger.LogInformation("Applying database migrations.");
                await context.Database.MigrateAsync();

                // Add roles
                logger.LogInformation("Seeding roles.");
                await AddRoleAsync(roleManager, "Admin");
                await AddRoleAsync(roleManager, "Customer");
                await AddRoleAsync(roleManager, "Shipper");

                // Add admin user
                logger.LogInformation("Seeding admin user.");
                var adminEmail = "admin@gmail.com";
                if (await userManager.FindByEmailAsync(adminEmail) == null)
                {
                    var adminUser = new ApplicationUser
                    {
                        FullName = "Admin",
                        UserName = adminEmail,
                        NormalizedUserName = adminEmail.ToUpper(),
                        Email = adminEmail,
                        NormalizedEmail = adminEmail.ToUpper(),
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString()
                    };

                    var result = await userManager.CreateAsync(adminUser, "Admin@123");
                    if (result.Succeeded)
                    {
                        logger.LogInformation("Assigning Admin role to the admin user.");
                        await userManager.AddToRoleAsync(adminUser, "Admin");
                    }
                    else
                    {
                        logger.LogError("Failed to create admin user: {Errors}", string.Join(", ", result.Errors.Select(e => e.Description)));
                    }
                }

                // Add customer user
                logger.LogInformation("Seeding customer user.");
                var customerEmail = "customer@fahasa.com";
                if (await userManager.FindByEmailAsync(customerEmail) == null)
                {
                    var customerUser = new ApplicationUser
                    {
                        FullName = "Nguyễn Văn A",
                        UserName = customerEmail,
                        NormalizedUserName = customerEmail.ToUpper(),
                        Email = customerEmail,
                        NormalizedEmail = customerEmail.ToUpper(),
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString()
                    };

                    var result = await userManager.CreateAsync(customerUser, "Customer123!");
                    if (result.Succeeded)
                    {
                        logger.LogInformation("Assigning Customer role to the customer user.");
                        await userManager.AddToRoleAsync(customerUser, "Customer");
                    }
                    else
                    {
                        logger.LogError("Failed to create customer user: {Errors}", string.Join(", ", result.Errors.Select(e => e.Description)));
                    }
                }

                // Add shipper user
                logger.LogInformation("Seeding shipper user.");
                var shipperEmail = "shipper@gmail.com";
                if (await userManager.FindByEmailAsync(shipperEmail) == null)
                {
                    var shipperUser = new ApplicationUser
                    {
                        FullName = "Shipper",
                        UserName = shipperEmail,
                        NormalizedUserName = shipperEmail.ToUpper(),
                        Email = shipperEmail,
                        NormalizedEmail = shipperEmail.ToUpper(),
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString()
                    };

                    var result = await userManager.CreateAsync(shipperUser, "Shipper@123");
                    if (result.Succeeded)
                    {
                        logger.LogInformation("Assigning Shipper role to the shipper user.");
                        await userManager.AddToRoleAsync(shipperUser, "Shipper");
                    }
                    else
                    {
                        logger.LogError("Failed to create shipper user: {Errors}", string.Join(", ", result.Errors.Select(e => e.Description)));
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while seeding the database.");

            }

        }

        private static async Task AddRoleAsync(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                var result = await roleManager.CreateAsync(new IdentityRole(roleName));
                if (!result.Succeeded)
                {
                    throw new Exception($"Failed to create role '{roleName}': {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }
        }
    }
}

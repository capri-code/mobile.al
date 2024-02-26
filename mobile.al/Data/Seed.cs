using Microsoft.AspNetCore.Identity;
using mobile.al.Models;
using mobile.al.Data.Enum;
using mobile.al.Data.Static;

namespace mobile.al.Data
{
    public class Seed
	{
		public static void SeedData(IApplicationBuilder applicationBuilder)
		{
			using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

				context.Database.EnsureCreated();

				if (!context.Cars.Any())
				{
					context.Cars.AddRange(new List<Car>()
					{
						new Car()
						{
                            Description = "Mercedes-Benz E-Class ne gjendje shume te mire",
							Price = 100000,
							Mileage = 100000,
                            Category = Category.Coupe,
							HorsePower = 360,
                            GearBoxCategory = GearBox.Automatic,
                            FuelTypeCategory = FuelType.Diesel,
							Make = Make.MercedesBenz,
							Color = "Grey",
							Extras = Extras.Panoramic_Roof,
							Address = new Address()
							{
								Street = "Rruga Muhamet Gjollesha",
								City = "Tirane",
								State = "Albania"
							}
						 },
                        new Car()
                        {
                            Description = "Mercedes-Benz E-Class ne gjendje shume te mire",
                            Price = 100000,
                            Mileage = 100000,
                            Category = Category.Cabriolet,
                            HorsePower = 360,
                            FuelTypeCategory = FuelType.Diesel,
                            GearBoxCategory = GearBox.Automatic,
                            Make = Make.MercedesBenz,
                            Color = "Grey",
                            Extras = Extras.Panoramic_Roof,
                            Address = new Address()
                            {
                                Street = "Rruga Muhamet Gjollesha",
                                City = "Tirane",
                                State = "Albania"
                            }
                         },
                        new Car()
                        {
                            Description = "Mercedes-Benz E-Class ne gjendje shume te mire",
                            Price = 100000,
                            Mileage = 100000,
                            Category = Category.Estate,
                            HorsePower = 360,
                            FuelTypeCategory = FuelType.Diesel,
                            GearBoxCategory = GearBox.Automatic,
                            Make = Make.MercedesBenz, 
							Color = "Grey", 
							Extras = Extras.Panoramic_Roof,
                            Address = new Address()
                            {
                                Street = "Rruga Muhamet Gjollesha",
                                City = "Tirane",
                                State = "Albania"
                            }
                         }
                    });
					context.SaveChanges();
				}
			}
		}

		public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
		{
			using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
			{
				//Roles
				var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

				if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
					await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
				if (!await roleManager.RoleExistsAsync(UserRoles.User))
					await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

				//Users
				var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
				string adminUserEmail = "iljazkapri@gmail.com";

				var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
				if (adminUser == null)
				{
					var newAdminUser = new AppUser()
					{
						UserName = "iljazkapri",
						Email = adminUserEmail,
						EmailConfirmed = true,
						Address = new Address()
						{
							Street = "Rruga Jordan Misja",
							City = "Tirane",
							State = "Albania"
						}
					};
					await userManager.CreateAsync(newAdminUser, "Coding@1234?");
					await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
				}

				string appUserEmail = "user@gmail.com";

				var appUser = await userManager.FindByEmailAsync(appUserEmail);
				if (appUser == null)
				{
					var newAppUser = new AppUser()
					{
						UserName = "app-user",
						Email = appUserEmail,
						EmailConfirmed = true,
						Address = new Address()
						{
							Street = "Rruga Muhamet Gjollesha",
							City = "Tirane",
							State = "Albania"
						}
					};
					await userManager.CreateAsync(newAppUser, "Coding@1234?");
					await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
				}
			}
		}
	}
}

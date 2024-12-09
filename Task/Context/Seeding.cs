using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tasks.Constants;
using Tasks.Domains;

namespace Tasks.Context
{
    public static class Seeding
    {
        public async static void Initialize(IServiceProvider service)
        {
            var dbContext = service.GetRequiredService<TaskDbContext>();

            var userManager = service.GetRequiredService<UserManager<Customer>>();
            var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();

            var appliedMigrations = dbContext.Database.GetAppliedMigrations();

            if (appliedMigrations.Count() == 0)
            {
                await roleManager.CreateAsync(new IdentityRole("Customer"));

                var user = new Customer()
                {
                    Code = "123",
                    Email = "omar@gmail.com",
                    Name = "Omar",
                    PhoneNumber = "01123232333",
                    UserName = "OmarAlaa"
                };

                await userManager.CreateAsync(user, "123@Abc");
                await userManager.AddToRoleAsync(user, Constant.CustomerRole);
            }
        }
    }
}

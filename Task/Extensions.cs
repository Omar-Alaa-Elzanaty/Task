using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Task.Context;
using Task.Domains;

namespace Task
{
    public static class Extensions
    {
        public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextConfig(configuration);

            // Identity Entities Configuration
            services.AddIdentity<Customer, IdentityRole<int>>()
                    .AddUserManager<UserManager<Customer>>()
                    .AddRoleManager<RoleManager<IdentityRole<int>>>()
                    .AddEntityFrameworkStores<TaskDbContext>()
                    .AddDefaultTokenProviders();

            return services;
        }

        private static IServiceCollection AddDbContextConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ??
                                       throw new InvalidOperationException("Connection string 'DefaultConnection' is missing.");

            services.AddDbContext<TaskDbContext>(options =>
            {
                options.UseLazyLoadingProxies()
                       .UseSqlServer(connectionString, builder =>
                       {
                           builder.MigrationsAssembly(typeof(TaskDbContext).Assembly.FullName);
                       });
            });

            return services;
        }
    }
}

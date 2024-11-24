using EFCore_Join_ManyToMany.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Join_ManyToMany
{
    public static class ServiceRegistration
    {
        
        public static void AddProjectServices(this IServiceCollection services)
        {
            services.AddDbContext<JoinDbContext>(options =>
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), optional: true)
                .Build();

                options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
            });
        }
    }
}

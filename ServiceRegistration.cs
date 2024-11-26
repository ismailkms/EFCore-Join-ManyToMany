using EFCore_Join_ManyToMany.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Join_ManyToMany
{
    public static class ServiceRegistration
    {
        
        public static void AddProjectServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<JoinDbContext>(options =>
            {
                //IConfigurationRoot configuration = new ConfigurationBuilder()
                //.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), optional: true)
                //.Build();

                //configuration'ı yukarıdaki gibi çekebilirsin ya da IConfiguration configuration'ı parametre olarak alıp, Program.cs'de parametreyi göndererekte çekebilirsin. (builder.Services.AddProjectServices(builder.Configuration);)

                options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
            });
        }
    }
}

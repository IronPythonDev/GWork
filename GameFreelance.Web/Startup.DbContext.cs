using GameFreelance.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GameFreelance.Web
{
    public partial class Startup
    {
        public void InitDbContext(IServiceCollection services , IConfiguration configuration , IWebHostEnvironment environment)
        {
            const string assemblyName = "GameFreelance.Infrastructure.Data";
            services.AddDbContext<ResumeContext>(builder => {
                if (environment.IsDevelopment())
                {
                    builder.EnableSensitiveDataLogging();
                }
                builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection") , options => options.MigrationsAssembly(assemblyName))
                    .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryPossibleExceptionWithAggregateOperatorWarning)); 
                
            });

            services.AddDbContext<UserContext>(builder => {
                if (environment.IsDevelopment())
                {
                    builder.EnableSensitiveDataLogging();
                }
                builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), options => options.MigrationsAssembly(assemblyName))
                    .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryPossibleExceptionWithAggregateOperatorWarning));
            });

            services.AddDbContext<VacancyContext>(builder => {
                if (environment.IsDevelopment())
                {
                    builder.EnableSensitiveDataLogging();
                }
                builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), options => options.MigrationsAssembly(assemblyName))
                    .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryPossibleExceptionWithAggregateOperatorWarning));
            });
        }
    }
}

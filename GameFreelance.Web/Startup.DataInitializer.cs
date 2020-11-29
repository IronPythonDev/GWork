using GameFreelance.Infrastructure.Data.Context;
using GameFreelance.Web.Utils.AsyncInitialization;
using Microsoft.Extensions.DependencyInjection;

namespace GameFreelance.Web
{
    public partial class Startup
    {
        public void DataBaseAsyncInitialize(IServiceCollection services)
        {
            services.AddAsyncInitializer<MigrationsInitializer<UserContext>>();
            services.AddAsyncInitializer<MigrationsInitializer<ResumeContext>>();
            services.AddAsyncInitializer<MigrationsInitializer<VacancyContext>>();
            services.AddAsyncInitializer<UserInitializer>();
            services.AddAsyncInitializer<ResumeInitializer>();
            services.AddAsyncInitializer<VacancyInitializer>();
        }
    }
}

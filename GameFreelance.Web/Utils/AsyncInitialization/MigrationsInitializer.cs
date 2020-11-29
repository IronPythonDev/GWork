using GameFreelance.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GameFreelance.Web.Utils.AsyncInitialization
{
    public class MigrationsInitializer<TDbContext> : DataInitializerBase<TDbContext>
        where TDbContext : DbContextEx
    {
        public MigrationsInitializer(IServiceProvider service) : base(service) { }

        protected override async Task InitializeAsync(TDbContext dbContext)
        {
            await dbContext.Database.MigrateAsync();
        }
    }
}

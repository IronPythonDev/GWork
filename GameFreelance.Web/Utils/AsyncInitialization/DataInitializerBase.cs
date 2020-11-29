using System;
using System.Threading.Tasks;
using Extensions.Hosting.AsyncInitialization;
using GameFreelance.Infrastructure.Data.Context;
using Microsoft.Extensions.DependencyInjection;
// ReSharper disable All
namespace GameFreelance.Web.Utils.AsyncInitialization
{
    public abstract class DataInitializerBase<TDbContext> : IAsyncInitializer
        where TDbContext : DbContextEx
    {
        private readonly IServiceProvider _serviceProvider;

        protected DataInitializerBase(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task InitializeAsync()
        {
            using var scope = _serviceProvider.CreateScope();
            await using var context = scope.ServiceProvider.GetRequiredService<TDbContext>();
            await InitializeAsync(context);
            await context.SaveChangesAsync();
        }
        protected abstract Task InitializeAsync(TDbContext dbContext);
    }
}

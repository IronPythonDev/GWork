using GameFreelance.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using GameFreelance.Domain.Core.Entity;
// ReSharper disable All

namespace GameFreelance.Web.Utils.AsyncInitialization
{
    public class VacancyInitializer : DataInitializerBase<VacancyContext>
    {
        public VacancyInitializer(IServiceProvider serviceProvider) : base(serviceProvider) { }

        protected override async Task InitializeAsync(VacancyContext dbContext)
        {
            var count = await dbContext.Vacancies.CountAsync();

            if (count > 0) return;

            await dbContext.AddAsync(new VacancyModel { Category = 2, Experience = 1, OwnerId = 2, VacancyName = "C# Developer For GlovalLogic" });
            await dbContext.SaveChangesAsync();
        }
    }
}

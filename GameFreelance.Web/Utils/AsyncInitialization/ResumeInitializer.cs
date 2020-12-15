using GameFreelance.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using GameFreelance.Domain.Core.Entity;
// ReSharper disable All
namespace GameFreelance.Web.Utils.AsyncInitialization
{
    public class ResumeInitializer : DataInitializerBase<ResumeContext>
    {
        public ResumeInitializer(IServiceProvider serviceProvider) : base(serviceProvider) { }

        protected override async Task InitializeAsync(ResumeContext dbContext)
        {
            var count = await dbContext.Resumes.CountAsync();

            if (count > 0) return;

            //await dbContext.AddAsync(new ResumeModel { OwnerId = 1 , Category = 2 , Attainment = "NodeJS , C# , Angular2+ , ASP.NET Core" , Experience = 2 , ExperienceText = "Worked in top 5 Ukraine IT Company"  , Position = "C# Developer" , Salary = 2000});
            //await dbContext.SaveChangesAsync();
        }
    }
}

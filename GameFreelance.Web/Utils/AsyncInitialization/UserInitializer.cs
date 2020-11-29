using GameFreelance.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using GameFreelance.Domain.Core.Entity;
// ReSharper disable All

namespace GameFreelance.Web.Utils.AsyncInitialization
{
    public class UserInitializer : DataInitializerBase<UserContext>
    {
        public UserInitializer(IServiceProvider serviceProvider) : base(serviceProvider) { }

        protected override async Task InitializeAsync(UserContext dbContext)
        {
            var count = await dbContext.Users.CountAsync();

            if (count > 0) return;

            await dbContext.AddAsync(new UserModel { Login = "testinit", FirstName = "Vlad" , LastName = "Kovalchuk" , Password = PasswordUtils.GetHashPassword("VLAD1234") , VKontakteId = "vkovalchuk2018" });
            await dbContext.SaveChangesAsync();
        }
    }
}

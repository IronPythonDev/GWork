using GameFreelance.Domain.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace GameFreelance.Infrastructure.Data.Context
{
    public class UserContext : DbContextEx
    {
        public DbSet<UserModel> Users { get; set; }
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserModel>()
                .HasIndex(user => user.Id)
                .IsUnique();

            base.OnModelCreating(builder);
        }

    }
}

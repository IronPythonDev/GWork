using GameFreelance.Domain.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace GameFreelance.Infrastructure.Data.Context
{
    public class VacancyContext : DbContextEx
    {
        public DbSet<VacancyModel> Vacancies { get; set; }
        public VacancyContext(DbContextOptions<VacancyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<VacancyModel>()
                .HasIndex(vacancy => vacancy.Id)
                .IsUnique();

            base.OnModelCreating(builder);
        }
    }
}

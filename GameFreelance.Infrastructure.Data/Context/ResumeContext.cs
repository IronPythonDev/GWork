using GameFreelance.Domain.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace GameFreelance.Infrastructure.Data.Context
{
    public class ResumeContext : DbContextEx
    {
        public DbSet<ResumeModel> Resumes { get; set; }
        public ResumeContext(DbContextOptions<ResumeContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ResumeModel>()
                .HasIndex(resume => resume.Id)
                .IsUnique();

            base.OnModelCreating(builder);
        }
    }
}

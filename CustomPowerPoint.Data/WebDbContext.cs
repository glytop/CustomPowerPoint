using CustomPowerPoint.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomPowerPoint.Data
{
    public class WebDbContext : DbContext
    {
        public WebDbContext(DbContextOptions<WebDbContext> contextOptions)
            : base(contextOptions) { }

        public DbSet<PresentationData> Presentations { get; set; }
        public DbSet<SlideData> Slides { get; set; }
        public DbSet<SlideElementData> SlideElements { get; set; }
        public DbSet<UserData> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PresentationData>()
                .HasMany(p => p.Users)
                .WithMany()
                .UsingEntity(j => j.ToTable("PresentationUsers"));

            base.OnModelCreating(modelBuilder);
        }
    }
}

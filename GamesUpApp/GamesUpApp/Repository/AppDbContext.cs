using GamesUpApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace GamesUpApp.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<GameBase> Games { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameBase>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<GameBase>()
                .Property(a => a.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            modelBuilder.Entity<GameBase>()
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<GameBase>()
                .Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(300);

            modelBuilder.Entity<GameBase>()
                .Property(a => a.Platform)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<GameBase>()
                .Property(a => a.TotalHours)
                .IsRequired();

            modelBuilder.Entity<GameBase>()
                .Property(a => a.Finished)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}

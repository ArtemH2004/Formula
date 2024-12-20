using Formula.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Formula.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Driver> Drivers { get; set; } = null!;
        public DbSet<Manager> Managers { get; set; } = null!;
        public DbSet<Race> Races { get; set; } = null!;
        public DbSet<Staff> Staffs { get; set; } = null!;
        public DbSet<Team> Teams { get; set; } = null!;
        public DbSet<Track> Tracks { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Race - Track: One to One
            modelBuilder.Entity<Race>()
                .HasOne(t => t.Track)
                .WithOne(r => r.Race)
                .HasForeignKey<Track>(r => r.RaceId)
                .OnDelete(DeleteBehavior.Restrict);

            // Race - Team: One to Many
            modelBuilder.Entity<Race>()
                .HasMany(t => t.Teams)
                .WithOne(r => r.Race)
                .HasForeignKey(r => r.RaceId)
                .OnDelete(DeleteBehavior.Restrict);

            // Team - Driver: One to Many
            modelBuilder.Entity<Team>()
                .HasMany(d => d.Drivers)
                .WithOne(t => t.Team)
                .HasForeignKey(t => t.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            // Team - Staff: One to Many
            modelBuilder.Entity<Team>()
                .HasMany(d => d.Staffs)
                .WithOne(t => t.Team)
                .HasForeignKey(t => t.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            // Team - Manager: One to Many
            modelBuilder.Entity<Team>()
                .HasMany(d => d.Managers)
                .WithOne(t => t.Team)
                .HasForeignKey(t => t.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

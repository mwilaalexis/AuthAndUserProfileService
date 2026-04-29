using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using UserProject.DataAccess.Entities;

namespace UserProject.DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<Profile>(p => p.UserId);
             builder.Entity<Profile>()
                .Property(p => p.HeightCm)
                .HasPrecision(5, 2); // ex: 999.99

             builder.Entity<Profile>()
                .Property(p => p.WeightKg)
                .HasPrecision(5, 2);


        }
    }
}

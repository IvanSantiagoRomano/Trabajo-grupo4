using Domain.Entities.Concrete.Privileges;
using Domain.Entities.Concrete.Privileges.RefreshTokens;
using Domain.Entities.Concrete.Users;
using Domain.Entities.Concrete.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Privilege> Privileges { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Users
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Username).HasColumnName("UserName").IsRequired();
                entity.Property(u => u.Salt).IsRequired();
                entity.Property(u => u.HashedPassword).IsRequired();
            });

            // Privileges
            modelBuilder.Entity<Privilege>(entity =>
            {
                entity.ToTable("Privileges");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Description).IsRequired();
            });

            // UsersPrivileges (tabla intermedia Many-to-Many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Privileges)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "UsersPrivileges",
                    j => j.HasOne<Privilege>().WithMany().HasForeignKey("PrivilegeId"),
                    j => j.HasOne<User>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "PrivilegeId");
                        j.ToTable("UsersPrivileges");
                        j.Property<Guid>("Id");
                    }
                );

            // RefreshToken
            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.ToTable("RefreshToken");
                entity.HasKey(r => r.Id);
                entity.Property(r => r.Token).IsRequired();
                entity.Property(r => r.Expires).IsRequired();
                entity.HasOne<User>()
                      .WithMany()
                      .HasForeignKey(r => r.UserId);
            });
        }
    }
}

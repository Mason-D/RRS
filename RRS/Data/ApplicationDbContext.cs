using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RRS.Data;

namespace RRS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        private IdentityUser NewUser(string id, string username, string password = "Abc123!@#")
        {
            PasswordHasher<IdentityUser> hasher = new();

            IdentityUser user = new()
            {
                Id = id,
                ConcurrencyStamp = id,
                Email = username,
                NormalizedEmail = username.Trim().ToUpper(),
                UserName = username,
                NormalizedUserName = username.Trim().ToUpper(),
                EmailConfirmed = true
            };

            user.PasswordHash = hasher.HashPassword(user, password);
            return user;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            new ModelConfiguration(builder);
            new ModelDataSeeder(builder);     

            builder.Entity<Table>()
                .HasMany(t => t.Reservations)
                .WithMany(r => r.Tables)
                .UsingEntity<ReservationTable>();

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "1337x1",
                    ConcurrencyStamp = "1337x1",
                    Name = "God",
                    NormalizedName = "GOD"
                },
                new IdentityRole
                {
                    Id = "1337x2",
                    ConcurrencyStamp = "1337x2",
                    Name = "Manager",
                    NormalizedName = "MANAGER"
                },
                new IdentityRole
                {
                    Id = "1337x3",
                    ConcurrencyStamp = "1337x3",
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                },
                new IdentityRole
                {
                    Id = "1337x4",
                    ConcurrencyStamp = "1337x4",
                    Name = "Member",
                    NormalizedName = "MEMBER"
                }
            );

            builder.Entity<IdentityUser>().HasData(
                NewUser("1337x1", "god@e.com"),
                NewUser("1337x2", "man@e.com"),
                NewUser("1337x3", "emp@e.com"),
                NewUser("1337x4", "Seed@Person1.com")
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "1337x1",
                    UserId = "1337x1"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "1337x2",
                    UserId = "1337x2"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "1337x3",
                    UserId = "1337x2"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "1337x3",
                    UserId = "1337x3"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "1337x4",
                    UserId = "1337x4"
                }
            );
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Sitting> Sittings { get; set; }
        public DbSet<SittingType> SittingTypes { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationStatus> ReservationStatuses { get; set; }
        public DbSet<ReservationOrigin> ReservationOrigins { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ReservationTable> ReservationTables { get; set; }
        public DbSet<RRS.Data.Employee>? Employee { get; set; }
    }
}
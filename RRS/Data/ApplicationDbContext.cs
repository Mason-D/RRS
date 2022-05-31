using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "1337x1",
                    ConcurrencyStamp = "1337x1",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "1337x2",
                    ConcurrencyStamp = "1337x2",
                    Name = "Member",
                    NormalizedName = "Member"
                }
            );

            builder.Entity<IdentityUser>().HasData(
                NewUser("1337x1", "a@e.com"),
                NewUser("1337x2", "g@e.com")
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
    }
}
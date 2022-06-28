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
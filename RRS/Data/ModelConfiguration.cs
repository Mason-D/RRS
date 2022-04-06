using Microsoft.EntityFrameworkCore;

namespace RRS.Data
{
    public class ModelConfiguration
    {
        private readonly ModelBuilder _builder;

        public ModelConfiguration(ModelBuilder builder)
        {
            _builder = builder;
            hasBaseType();
            tablePerType();
            onDeleteRestrict();
        }

        private void hasBaseType()
        {
            _builder.Entity<Employee>().HasBaseType<Person>();
            _builder.Entity<Customer>().HasBaseType<Person>();
        }

        private void tablePerType()
        {
            _builder.Entity<Person>().ToTable("People");
            _builder.Entity<Customer>().ToTable("Customers");
            _builder.Entity<Employee>().ToTable("Employees");
        }

        private void onDeleteRestrict()
        {
            _builder.Entity<Restaurant>().HasMany(r => r.Sittings).WithOne(s => s.Restaurant).OnDelete(DeleteBehavior.Restrict);
            _builder.Entity<Restaurant>().HasMany(r => r.Areas).WithOne(s => s.Restaurant).OnDelete(DeleteBehavior.Restrict);
            _builder.Entity<Restaurant>().HasMany(r => r.People).WithOne(p => p.Restaurant).OnDelete(DeleteBehavior.Restrict);
            _builder.Entity<Sitting>().HasOne(s => s.SittingType).WithMany(st => st.Sittings).OnDelete(DeleteBehavior.Restrict);
            _builder.Entity<Sitting>().HasMany(s => s.Reservations).WithOne(r => r.Sitting).OnDelete(DeleteBehavior.Restrict);
            _builder.Entity<Reservation>().HasOne(r => r.Customer).WithMany(c => c.Reservations).OnDelete(DeleteBehavior.Restrict);
            _builder.Entity<Reservation>().HasOne(r => r.ReservationOrigin).WithMany(ro => ro.Reservations).OnDelete(DeleteBehavior.Restrict);
            _builder.Entity<Reservation>().HasOne(r => r.ReservationStatus).WithMany(rs => rs.Reservations).OnDelete(DeleteBehavior.Restrict);
            _builder.Entity<Area>().HasOne(a => a.Restaurant).WithMany(r => r.Areas).OnDelete(DeleteBehavior.Restrict);
            _builder.Entity<Table>().HasOne(t => t.Area).WithMany(a => a.Tables).OnDelete(DeleteBehavior.Restrict);
        }
    }
}

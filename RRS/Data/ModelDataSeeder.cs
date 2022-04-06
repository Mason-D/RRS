using Microsoft.EntityFrameworkCore;

namespace RRS.Data
{
    public class ModelDataSeeder
    {
        private readonly ModelBuilder _builder;
        public ModelDataSeeder(ModelBuilder builder)
        {
            _builder = builder;
            seed();
        }

        private void seed()
        {
            _builder.Entity<Restaurant>().HasData(
                new Restaurant { Id = 1, Name = "Bean Scene" }
            );

            _builder.Entity<SittingType>().HasData(
                new SittingType { Id = 1, Description = "Breakfast" },
                new SittingType { Id = 2, Description = "Lunch" },
                new SittingType { Id = 3, Description = "Dinner" }
            );

            //_builder.Entity<Sitting>().HasData(
            //    new Sitting { Id = 1, SittingTypeId = 1, RestaurantId = 1, Capacity = 50, IsClosed = false, Duration = 180 }
            //); ;

        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace RRS.Data
{
    public class ModelDataSeeder
    {
        private readonly ModelBuilder _builder;
        public ModelDataSeeder(ModelBuilder builder)
        {
            _builder = builder;
            seedRestaurant();
            seedAreas();
            seedTables();
            seedSittingType();
            seedSittings();
            seedReservationStatuses();
            seedReservationOrigins();
            seedPeople();
            seedReservation();
        }


        private void seedRestaurant()
        {
            _builder.Entity<Restaurant>().HasData(
                new Restaurant { Id = 1, Name = "Bean Scene", Email = "Bean@Scene.com", Address="123 Bean St, Sydney", PhoneNumber="123-456-789" }
            );
        }

        private void seedAreas()
        {
            _builder.Entity<Area>().HasData(
                new Area { Id = 1, Description = "Main", RestaurantId = 1 },
                new Area { Id = 2, Description = "Outside", RestaurantId = 1 },
                new Area { Id = 3, Description = "Balcony", RestaurantId = 1 }
            );
        }

        private async void seedTables()
        {
           
            List<Table> tables = new List<Table>();
            string[] areas = { "Main", "Outside", "Balcony" };
            Random random = new Random();
            int id = 1; 
            
            for (int areaIndex = 0; areaIndex < areas.Length; areaIndex++)
            {
                for (int tableIndex = 1; tableIndex < 11; tableIndex++)
                {
                    tables.Add(new Table { Id = id, Description = $"{areas[areaIndex][0]}{tableIndex}", AreaId = areaIndex + 1, Seats = random.Next(2, 10) });
                    id++;
                }
            }

            _builder.Entity<Table>().HasData(tables);
                                    
        }

        private void seedSittingType()
        {
            _builder.Entity<SittingType>().HasData(
                new SittingType { Id = 1, Description = "Breakfast" },
                new SittingType { Id = 2, Description = "Lunch" },
                new SittingType { Id = 3, Description = "Dinner" }
            );
        }

        private void seedSittings()
        {
            int sittingsForDays = 90;

            //new Sitting { Interval=15, Cutoff=30, Id = 1, SittingTypeId = 1, RestaurantId = 1, Capacity = 40, IsOpen = true, Start = new DateTime(2022, 4, 6, 7, 0, 0), Duration = 240 },
            List<Sitting> sittings = new List<Sitting>();
            int id = 1;
            int resturantId = 1;
            int cutoff = 30;
            int interval = 15;
            int[] capacityRange = {60,75,100};
            int[] DurationRange = { 120, 210, 300 };
            DateTime currentDate = DateTime.Now;

            DateTime[] startTimes = {
                new DateTime(currentDate.Year,currentDate.Month, currentDate.Day,7,0,0),
                new DateTime(currentDate.Year,currentDate.Month, currentDate.Day,12,0,0),
                new DateTime(currentDate.Year,currentDate.Month, currentDate.Day,18,0,0),
            };

            for (int i = 0; i < sittingsForDays; i++)
            {
                for (int sittingIndex = 0; sittingIndex < 3; sittingIndex++)
                {
                    sittings.Add(new Sitting
                    {
                        Id = id,
                        RestaurantId = resturantId,
                        SittingTypeId = sittingIndex + 1,
                        Interval = interval,
                        Cutoff = cutoff,
                        IsOpen = true,
                        Start = startTimes[sittingIndex].AddDays(i + 1),
                        Capacity = capacityRange[sittingIndex],
                        Duration = DurationRange[sittingIndex],
                    });
                    id++;
                }
            }
            _builder.Entity<Sitting>().HasData(sittings);
        }

        private void seedReservationStatuses()
        {
            _builder.Entity<ReservationStatus>().HasData(
                new ReservationStatus { Id = 1, Description = "Pending" },
                new ReservationStatus { Id = 2, Description = "Confirmed" },
                new ReservationStatus { Id = 3, Description = "Cancelled" },
                new ReservationStatus { Id = 4, Description = "Seated" },
                new ReservationStatus { Id = 5, Description = "Completed" }
            );
        }

        private void seedReservationOrigins()
        {
            _builder.Entity<ReservationOrigin>().HasData(
                new ReservationOrigin { Id = 1, Description = "In-person" },
                new ReservationOrigin { Id = 2, Description = "Email" },
                new ReservationOrigin { Id = 3, Description = "Phone" },
                new ReservationOrigin { Id = 4, Description = "Online" }
            );
        }

        private void seedPeople()
        {
            for (int i = 1; i <= 3; i++)
            {
                _builder.Entity<Customer>().HasData(new Customer
                {
                    Id = i,
                    FirstName = $"SeedPersonFN{i}",
                    LastName = $"SeedPersonLN{i}",
                    PhoneNumber = $"04{i}00{i}00",
                    Email = $"Seed@Person{i}.com",
                    IsVIP = true,
                    RestaurantId = 1,
                    UserId = i == 1 ? "1337x4" : null
                });
            }
        }

        private void seedReservation()
        {
            _builder.Entity<Reservation>().HasData(new Reservation
            {
                SittingId = 1,
                StartTime = new DateTime(2022, 6, 12, 9, 30, 0),
                CustomerId = 1,
                NoOfGuests = 2,
                ReservationOriginId = 4,
                Id = 10000,
                ReservationStatusId = 1
            });        
        }
    }
}

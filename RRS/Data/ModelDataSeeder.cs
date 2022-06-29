using Microsoft.EntityFrameworkCore;

namespace RRS.Data
{
    public class ModelDataSeeder
    {
        private readonly ModelBuilder _builder;
        private readonly DbContext _context;
        private readonly int _DaysOfSittings = 30;


        public ModelDataSeeder(ModelBuilder builder)
        {
            _builder = builder;
            SeedRestaurant();
            SeedAreas();
            SeedTables();
            SeedSittingType();
            SeedSittings();
            SeedReservationStatuses();
            SeedReservationOrigins();
            SeedPeople();
            SeedReservation();
        }


        private void SeedRestaurant()
        {
            _builder.Entity<Restaurant>().HasData(
                new Restaurant { Id = 1, Name = "Bean Scene", Email = "Bean@Scene.com", Address="123 Bean St, Sydney", PhoneNumber="123-456-789" }
            );
        }

        private void SeedAreas()
        {
            _builder.Entity<Area>().HasData(
                new Area { Id = 1, Description = "Main", RestaurantId = 1 },
                new Area { Id = 2, Description = "Outside", RestaurantId = 1 },
                new Area { Id = 3, Description = "Balcony", RestaurantId = 1 }
            );
        }

        private async void SeedTables()
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

        private void SeedSittingType()
        {
            _builder.Entity<SittingType>().HasData(
                new SittingType { Id = 1, Description = "Breakfast" },
                new SittingType { Id = 2, Description = "Lunch" },
                new SittingType { Id = 3, Description = "Dinner" }
            );
        }

        private void SeedSittings()
        {
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

            for (int i = 0; i < _DaysOfSittings; i++)
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

        private void SeedReservationStatuses()
        {
            _builder.Entity<ReservationStatus>().HasData(
                new ReservationStatus { Id = 1, Description = "Pending" },
                new ReservationStatus { Id = 2, Description = "Confirmed" },
                new ReservationStatus { Id = 3, Description = "Cancelled" },
                new ReservationStatus { Id = 4, Description = "Seated" },
                new ReservationStatus { Id = 5, Description = "Completed" }
            );
        }

        private void SeedReservationOrigins()
        {
            _builder.Entity<ReservationOrigin>().HasData(
                new ReservationOrigin { Id = 1, Description = "In-person" },
                new ReservationOrigin { Id = 2, Description = "Email" },
                new ReservationOrigin { Id = 3, Description = "Phone" },
                new ReservationOrigin { Id = 4, Description = "Online" }
            );
        }

        private void SeedPeople()
        {
            string[] firstNames = {"Aaliyah" ,"Rosemarie" ,"Kush" ,"Hendrix" , "Rose" ,"Christina" ,"Aiza" , "Neave" ,"Diesel" ,"Eleanor"};
            string[] lastNames ={"Phillips" ,"Lam" ,"Craig" ,"Vu" ,"Bates" ,"East" ,"East" ,"Hart" ,"Jefferson" ,"Farley" ,"Mcdonnell"};
            List<Customer> customers = new List<Customer>();

            for (int i = 0; i < firstNames.Length; i++)
            {
                customers.Add(new Customer 
                {
                    Id = i + 1,
                    FirstName = firstNames[i],
                    LastName = lastNames[i],
                    IsVIP = true,
                    Email = $"{firstNames[i]}.{lastNames[i]}@gmail.com",
                    PhoneNumber = $"0425{i}234{i}2",
                    RestaurantId = 1,
                });
            }

            _builder.Entity<Customer>().HasData(customers);
        }

        private void SeedReservation()
        {
            int len = _DaysOfSittings * 3;
            int[] DurationRange = { 120, 210, 300 };
            int cutOff = 30;
            int id = 1;
            DateTime currentDate = DateTime.Now;
            DateTime[] startTimes = {
                new DateTime(currentDate.Year,currentDate.Month, currentDate.Day,7,0,0),
                new DateTime(currentDate.Year,currentDate.Month, currentDate.Day,12,0,0),
                new DateTime(currentDate.Year,currentDate.Month, currentDate.Day,18,0,0),
            };
            List<List<int>> reservationIntervals = new List<List<int>>();

            foreach(var dr in DurationRange)
            {
                List<int> ints = new List<int>();
                for (int i = 0; i < (dr - cutOff / 15) ; i += 15)
                {
                    ints.Add(i);
                }
                reservationIntervals.Add(ints);
            }
            List<Reservation> reservations = new List<Reservation>();
            Random random = new Random();

            for (int i = 1; i < len + 1; i++)
            {
                for (int idIndex = 1; idIndex < 11; idIndex++)
                {
                    DateTime startTime;

                    if (i % 3 == 0)
                    {
                        startTime = startTimes[2].AddMinutes(reservationIntervals[2][random.Next(0, reservationIntervals[2].Count)]);
                    }
                    else if (i % 2 == 0)
                    {
                        startTime = startTimes[1].AddMinutes(reservationIntervals[1][random.Next(0, reservationIntervals[1].Count)]);
                    }
                    else
                    {
                        startTime = startTimes[0].AddMinutes(reservationIntervals[0][random.Next(0, reservationIntervals[0].Count)]);
                    }
                    reservations.Add(new Reservation
                    {
                        Id = id,
                        ReservationOriginId  = random.Next(1,4),
                        NoOfGuests = random.Next(2, 10),
                        ReservationStatusId = 1,
                        SittingId = i,
                        CustomerId = idIndex,
                        StartTime = startTime,
                    }
                    ) ;
                    id++;
                }
            }
            _builder.Entity<Reservation>().HasData(reservations);
        }
    }
}

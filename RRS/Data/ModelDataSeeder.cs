﻿using Microsoft.EntityFrameworkCore;

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
            // All data excluding reservations are seeded
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

        private void seedTables()
        {
            _builder.Entity<Table>().HasData(
                // Main Area
                new Table { Id = 1, Description = "M1", AreaId = 1 },
                new Table { Id = 2, Description = "M2", AreaId = 1 },
                new Table { Id = 3, Description = "M3", AreaId = 1 },
                new Table { Id = 4, Description = "M4", AreaId = 1 },
                new Table { Id = 5, Description = "M5", AreaId = 1 },
                new Table { Id = 6, Description = "M6", AreaId = 1 },
                new Table { Id = 7, Description = "M7", AreaId = 1 },
                new Table { Id = 8, Description = "M8", AreaId = 1 },
                new Table { Id = 9, Description = "M9", AreaId = 1 },
                new Table { Id = 10, Description = "M10", AreaId = 1 },
                // Outside Area
                new Table { Id = 11, Description = "O1", AreaId = 2 },
                new Table { Id = 12, Description = "O2", AreaId = 2 },
                new Table { Id = 13, Description = "O3", AreaId = 2 },
                new Table { Id = 14, Description = "O4", AreaId = 2 },
                new Table { Id = 15, Description = "O5", AreaId = 2 },
                new Table { Id = 16, Description = "O6", AreaId = 2 },
                new Table { Id = 17, Description = "O7", AreaId = 2 },
                new Table { Id = 18, Description = "O8", AreaId = 2 },
                new Table { Id = 19, Description = "O9", AreaId = 2 },
                new Table { Id = 20, Description = "O10", AreaId = 2 },
                // Balcony Area
                new Table { Id = 21, Description = "B1", AreaId = 3 },
                new Table { Id = 22, Description = "B2", AreaId = 3 },
                new Table { Id = 23, Description = "B3", AreaId = 3 },
                new Table { Id = 24, Description = "B4", AreaId = 3 },
                new Table { Id = 25, Description = "B5", AreaId = 3 },
                new Table { Id = 26, Description = "B6", AreaId = 3 },
                new Table { Id = 27, Description = "B7", AreaId = 3 },
                new Table { Id = 28, Description = "B8", AreaId = 3 },
                new Table { Id = 29, Description = "B9", AreaId = 3 },
                new Table { Id = 30, Description = "B10", AreaId = 3 }
            );
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
            _builder.Entity<Sitting>().HasData( // Currently one month of seeding data. Accurrate simulation requires three months.
                // April
                new Sitting { Id = 1, SittingTypeId = 1, RestaurantId = 1, Capacity = 40, IsOpen = true, Start = new DateTime(2022, 4, 6, 7, 0, 0), Duration = 240 },
                new Sitting { Id = 2, SittingTypeId = 2, RestaurantId = 1, Capacity = 60, IsOpen = true, Start = new DateTime(2022, 4, 6, 13, 0, 0), Duration = 180 },
                new Sitting { Id = 3, SittingTypeId = 3, RestaurantId = 1, Capacity = 80, IsOpen = true, Start = new DateTime(2022, 4, 6, 18, 0, 0), Duration = 300 },
                new Sitting { Id = 4, SittingTypeId = 1, RestaurantId = 1, Capacity = 40, IsOpen = true, Start = new DateTime(2022, 4, 7, 7, 0, 0), Duration = 240 },
                new Sitting { Id = 5, SittingTypeId = 2, RestaurantId = 1, Capacity = 60, IsOpen = true, Start = new DateTime(2022, 4, 7, 13, 0, 0), Duration = 180 },
                new Sitting { Id = 6, SittingTypeId = 3, RestaurantId = 1, Capacity = 80, IsOpen = true, Start = new DateTime(2022, 4, 7, 18, 0, 0), Duration = 300 },
                new Sitting { Id = 7, SittingTypeId = 1, RestaurantId = 1, Capacity = 40, IsOpen = true, Start = new DateTime(2022, 4, 8, 7, 0, 0), Duration = 240 },
                new Sitting { Id = 8, SittingTypeId = 2, RestaurantId = 1, Capacity = 60, IsOpen = true, Start = new DateTime(2022, 4, 8, 13, 0, 0), Duration = 180 },
                new Sitting { Id = 9, SittingTypeId = 3, RestaurantId = 1, Capacity = 80, IsOpen = true, Start = new DateTime(2022, 4, 8, 18, 0, 0), Duration = 300 },
                new Sitting { Id = 10, SittingTypeId = 1, RestaurantId = 1, Capacity = 40, IsOpen = true, Start = new DateTime(2022, 4, 9, 7, 0, 0), Duration = 240 },
                new Sitting { Id = 11, SittingTypeId = 2, RestaurantId = 1, Capacity = 60, IsOpen = true, Start = new DateTime(2022, 4, 9, 13, 0, 0), Duration = 180 },
                new Sitting { Id = 12, SittingTypeId = 3, RestaurantId = 1, Capacity = 80, IsOpen = true, Start = new DateTime(2022, 4, 9, 18, 0, 0), Duration = 300 },
                new Sitting { Id = 13, SittingTypeId = 1, RestaurantId = 1, Capacity = 40, IsOpen = true, Start = new DateTime(2022, 4, 10, 7, 0, 0), Duration = 240 },
                new Sitting { Id = 14, SittingTypeId = 2, RestaurantId = 1, Capacity = 60, IsOpen = true, Start = new DateTime(2022, 4, 10, 13, 0, 0), Duration = 180 },
                new Sitting { Id = 15, SittingTypeId = 3, RestaurantId = 1, Capacity = 80, IsOpen = true, Start = new DateTime(2022, 4, 10, 18, 0, 0), Duration = 300 },
                new Sitting { Id = 16, SittingTypeId = 1, RestaurantId = 1, Capacity = 40, IsOpen = true, Start = new DateTime(2022, 4, 11, 7, 0, 0), Duration = 240 },
                new Sitting { Id = 17, SittingTypeId = 2, RestaurantId = 1, Capacity = 60, IsOpen = true, Start = new DateTime(2022, 4, 11, 13, 0, 0), Duration = 180 },
                new Sitting { Id = 18, SittingTypeId = 3, RestaurantId = 1, Capacity = 80, IsOpen = true, Start = new DateTime(2022, 4, 11, 18, 0, 0), Duration = 300 },
                new Sitting { Id = 19, SittingTypeId = 1, RestaurantId = 1, Capacity = 40, IsOpen = true, Start = new DateTime(2022, 4, 12, 7, 0, 0), Duration = 240 },
                new Sitting { Id = 20, SittingTypeId = 2, RestaurantId = 1, Capacity = 60, IsOpen = true, Start = new DateTime(2022, 4, 12, 13, 0, 0), Duration = 180 },
                new Sitting { Id = 21, SittingTypeId = 3, RestaurantId = 1, Capacity = 80, IsOpen = true, Start = new DateTime(2022, 4, 12, 18, 0, 0), Duration = 300 },
                new Sitting { Id = 22, SittingTypeId = 1, RestaurantId = 1, Capacity = 40, IsOpen = true, Start = new DateTime(2022, 4, 13, 7, 0, 0), Duration = 240 },
                new Sitting { Id = 23, SittingTypeId = 2, RestaurantId = 1, Capacity = 60, IsOpen = true, Start = new DateTime(2022, 4, 13, 13, 0, 0), Duration = 180 },
                new Sitting { Id = 24, SittingTypeId = 3, RestaurantId = 1, Capacity = 80, IsOpen = true, Start = new DateTime(2022, 4, 13, 18, 0, 0), Duration = 300 },
                new Sitting { Id = 25, SittingTypeId = 1, RestaurantId = 1, Capacity = 40, IsOpen = true, Start = new DateTime(2022, 4, 14, 7, 0, 0), Duration = 240 },
                new Sitting { Id = 26, SittingTypeId = 2, RestaurantId = 1, Capacity = 60, IsOpen = true, Start = new DateTime(2022, 4, 14, 13, 0, 0), Duration = 180 },
                new Sitting { Id = 27, SittingTypeId = 3, RestaurantId = 1, Capacity = 80, IsOpen = true, Start = new DateTime(2022, 4, 14, 18, 0, 0), Duration = 300 },
                new Sitting { Id = 28, SittingTypeId = 1, RestaurantId = 1, Capacity = 40, IsOpen = true, Start = new DateTime(2022, 4, 15, 7, 0, 0), Duration = 240 },
                new Sitting { Id = 29, SittingTypeId = 2, RestaurantId = 1, Capacity = 60, IsOpen = true, Start = new DateTime(2022, 4, 15, 13, 0, 0), Duration = 180 },
                new Sitting { Id = 30, SittingTypeId = 3, RestaurantId = 1, Capacity = 80, IsOpen = true, Start = new DateTime(2022, 4, 15, 18, 0, 0), Duration = 300 },
                new Sitting { Id = 31, SittingTypeId = 1, RestaurantId = 1, Capacity = 40, IsOpen = true, Start = new DateTime(2022, 4, 16, 7, 0, 0), Duration = 240 },
                new Sitting { Id = 32, SittingTypeId = 2, RestaurantId = 1, Capacity = 60, IsOpen = true, Start = new DateTime(2022, 4, 16, 13, 0, 0), Duration = 180 },
                new Sitting { Id = 33, SittingTypeId = 3, RestaurantId = 1, Capacity = 80, IsOpen = true, Start = new DateTime(2022, 4, 16, 18, 0, 0), Duration = 300 },
                new Sitting { Id = 34, SittingTypeId = 1, RestaurantId = 1, Capacity = 40, IsOpen = true, Start = new DateTime(2022, 4, 17, 7, 0, 0), Duration = 240 },
                new Sitting { Id = 35, SittingTypeId = 2, RestaurantId = 1, Capacity = 60, IsOpen = true, Start = new DateTime(2022, 4, 17, 13, 0, 0), Duration = 180 },
                new Sitting { Id = 36, SittingTypeId = 3, RestaurantId = 1, Capacity = 80, IsOpen = true, Start = new DateTime(2022, 4, 17, 18, 0, 0), Duration = 300 },
                new Sitting { Id = 37, SittingTypeId = 1, RestaurantId = 1, Capacity = 40, IsOpen = true, Start = new DateTime(2022, 4, 18, 7, 0, 0), Duration = 240 },
                new Sitting { Id = 38, SittingTypeId = 2, RestaurantId = 1, Capacity = 60, IsOpen = true, Start = new DateTime(2022, 4, 18, 13, 0, 0), Duration = 180 },
                new Sitting { Id = 39, SittingTypeId = 3, RestaurantId = 1, Capacity = 80, IsOpen = true, Start = new DateTime(2022, 4, 18, 18, 0, 0), Duration = 300 },
                new Sitting { Id = 40, SittingTypeId = 1, RestaurantId = 1, Capacity = 40, IsOpen = true, Start = new DateTime(2022, 4, 19, 7, 0, 0), Duration = 240 },
                new Sitting { Id = 41, SittingTypeId = 2, RestaurantId = 1, Capacity = 60, IsOpen = true, Start = new DateTime(2022, 4, 19, 13, 0, 0), Duration = 180 },
                new Sitting { Id = 42, SittingTypeId = 3, RestaurantId = 1, Capacity = 80, IsOpen = true, Start = new DateTime(2022, 4, 19, 18, 0, 0), Duration = 300 },
                new Sitting { Id = 43, SittingTypeId = 1, RestaurantId = 1, Capacity = 40, IsOpen = true, Start = new DateTime(2022, 4, 20, 7, 0, 0), Duration = 240 },
                new Sitting { Id = 44, SittingTypeId = 2, RestaurantId = 1, Capacity = 60, IsOpen = true, Start = new DateTime(2022, 4, 20, 13, 0, 0), Duration = 180 },
                new Sitting { Id = 45, SittingTypeId = 3, RestaurantId = 1, Capacity = 80, IsOpen = true, Start = new DateTime(2022, 4, 20, 18, 0, 0), Duration = 300 },
                new Sitting { Id = 46, SittingTypeId = 1, RestaurantId = 1, Capacity = 40, IsOpen = true, Start = new DateTime(2022, 4, 21, 7, 0, 0), Duration = 240 },
                new Sitting { Id = 47, SittingTypeId = 2, RestaurantId = 1, Capacity = 60, IsOpen = true, Start = new DateTime(2022, 4, 21, 13, 0, 0), Duration = 180 },
                new Sitting { Id = 48, SittingTypeId = 3, RestaurantId = 1, Capacity = 80, IsOpen = true, Start = new DateTime(2022, 4, 21, 18, 0, 0), Duration = 300 },
                new Sitting { Id = 49, SittingTypeId = 1, RestaurantId = 1, Capacity = 40, IsOpen = true, Start = new DateTime(2022, 4, 22, 7, 0, 0), Duration = 240 },
                new Sitting { Id = 50, SittingTypeId = 2, RestaurantId = 1, Capacity = 60, IsOpen = true, Start = new DateTime(2022, 4, 22, 13, 0, 0), Duration = 180 },
                new Sitting { Id = 51, SittingTypeId = 3, RestaurantId = 1, Capacity = 80, IsOpen = true, Start = new DateTime(2022, 4, 22, 18, 0, 0), Duration = 300 },
                new Sitting { Id = 52, SittingTypeId = 1, RestaurantId = 1, Capacity = 40, IsOpen = true, Start = new DateTime(2022, 4, 23, 7, 0, 0), Duration = 240 },
                new Sitting { Id = 53, SittingTypeId = 2, RestaurantId = 1, Capacity = 60, IsOpen = true, Start = new DateTime(2022, 4, 23, 13, 0, 0), Duration = 180 },
                new Sitting { Id = 54, SittingTypeId = 3, RestaurantId = 1, Capacity = 80, IsOpen = true, Start = new DateTime(2022, 4, 23, 18, 0, 0), Duration = 300 },
                new Sitting { Id = 55, SittingTypeId = 1, RestaurantId = 1, Capacity = 40, IsOpen = true, Start = new DateTime(2022, 4, 24, 7, 0, 0), Duration = 240 },
                new Sitting { Id = 56, SittingTypeId = 2, RestaurantId = 1, Capacity = 60, IsOpen = true, Start = new DateTime(2022, 4, 24, 13, 0, 0), Duration = 180 },
                new Sitting { Id = 57, SittingTypeId = 3, RestaurantId = 1, Capacity = 80, IsOpen = true, Start = new DateTime(2022, 4, 24, 18, 0, 0), Duration = 300 },
                new Sitting { Id = 58, SittingTypeId = 1, RestaurantId = 1, Capacity = 40, IsOpen = true, Start = new DateTime(2022, 4, 25, 7, 0, 0), Duration = 240 },
                new Sitting { Id = 59, SittingTypeId = 2, RestaurantId = 1, Capacity = 60, IsOpen = true, Start = new DateTime(2022, 4, 25, 13, 0, 0), Duration = 180 },
                new Sitting { Id = 60, SittingTypeId = 3, RestaurantId = 1, Capacity = 80, IsOpen = true, Start = new DateTime(2022, 4, 25, 18, 0, 0), Duration = 300 },
                new Sitting { Id = 61, SittingTypeId = 1, RestaurantId = 1, Capacity = 40, IsOpen = true, Start = new DateTime(2022, 4, 26, 7, 0, 0), Duration = 240 },
                new Sitting { Id = 62, SittingTypeId = 2, RestaurantId = 1, Capacity = 60, IsOpen = true, Start = new DateTime(2022, 4, 26, 13, 0, 0), Duration = 180 },
                new Sitting { Id = 63, SittingTypeId = 3, RestaurantId = 1, Capacity = 80, IsOpen = true, Start = new DateTime(2022, 4, 26, 18, 0, 0), Duration = 300 },
                new Sitting { Id = 64, SittingTypeId = 1, RestaurantId = 1, Capacity = 40, IsOpen = true, Start = new DateTime(2022, 4, 27, 7, 0, 0), Duration = 240 },
                new Sitting { Id = 65, SittingTypeId = 2, RestaurantId = 1, Capacity = 60, IsOpen = true, Start = new DateTime(2022, 4, 27, 13, 0, 0), Duration = 180 },
                new Sitting { Id = 66, SittingTypeId = 3, RestaurantId = 1, Capacity = 80, IsOpen = true, Start = new DateTime(2022, 4, 27, 18, 0, 0), Duration = 300 },
                new Sitting { Id = 67, SittingTypeId = 1, RestaurantId = 1, Capacity = 40, IsOpen = true, Start = new DateTime(2022, 4, 28, 7, 0, 0), Duration = 240 },
                new Sitting { Id = 68, SittingTypeId = 2, RestaurantId = 1, Capacity = 60, IsOpen = true, Start = new DateTime(2022, 4, 28, 13, 0, 0), Duration = 180 },
                new Sitting { Id = 69, SittingTypeId = 3, RestaurantId = 1, Capacity = 80, IsOpen = true, Start = new DateTime(2022, 4, 28, 18, 0, 0), Duration = 300 },
                new Sitting { Id = 70, SittingTypeId = 1, RestaurantId = 1, Capacity = 40, IsOpen = true, Start = new DateTime(2022, 4, 29, 7, 0, 0), Duration = 240 },
                new Sitting { Id = 71, SittingTypeId = 2, RestaurantId = 1, Capacity = 60, IsOpen = true, Start = new DateTime(2022, 4, 29, 13, 0, 0), Duration = 180 },
                new Sitting { Id = 72, SittingTypeId = 3, RestaurantId = 1, Capacity = 80, IsOpen = true, Start = new DateTime(2022, 4, 29, 18, 0, 0), Duration = 300 },
                new Sitting { Id = 73, SittingTypeId = 1, RestaurantId = 1, Capacity = 40, IsOpen = true, Start = new DateTime(2022, 4, 30, 7, 0, 0), Duration = 240 },
                new Sitting { Id = 74, SittingTypeId = 2, RestaurantId = 1, Capacity = 60, IsOpen = true, Start = new DateTime(2022, 4, 30, 13, 0, 0), Duration = 180 },
                new Sitting { Id = 75, SittingTypeId = 3, RestaurantId = 1, Capacity = 80, IsOpen = true, Start = new DateTime(2022, 4, 30, 18, 0, 0), Duration = 300 },
                // May
                new Sitting { Id = 76, SittingTypeId = 1, RestaurantId = 1, Capacity = 40, IsOpen = true, Start = new DateTime(2022, 5, 1, 7, 0, 0), Duration = 240 },
                new Sitting { Id = 77, SittingTypeId = 2, RestaurantId = 1, Capacity = 60, IsOpen = true, Start = new DateTime(2022, 5, 1, 13, 0, 0), Duration = 180 },
                new Sitting { Id = 78, SittingTypeId = 3, RestaurantId = 1, Capacity = 80, IsOpen = true, Start = new DateTime(2022, 5, 1, 18, 0, 0), Duration = 300 },
                new Sitting { Id = 79, SittingTypeId = 1, RestaurantId = 1, Capacity = 40, IsOpen = true, Start = new DateTime(2022, 5, 2, 7, 0, 0), Duration = 240 },
                new Sitting { Id = 80, SittingTypeId = 2, RestaurantId = 1, Capacity = 60, IsOpen = true, Start = new DateTime(2022, 5, 2, 13, 0, 0), Duration = 180 },
                new Sitting { Id = 81, SittingTypeId = 3, RestaurantId = 1, Capacity = 80, IsOpen = true, Start = new DateTime(2022, 5, 2, 18, 0, 0), Duration = 300 },
                new Sitting { Id = 82, SittingTypeId = 1, RestaurantId = 1, Capacity = 40, IsOpen = true, Start = new DateTime(2022, 5, 3, 7, 0, 0), Duration = 240 },
                new Sitting { Id = 83, SittingTypeId = 2, RestaurantId = 1, Capacity = 60, IsOpen = true, Start = new DateTime(2022, 5, 3, 13, 0, 0), Duration = 180 },
                new Sitting { Id = 84, SittingTypeId = 3, RestaurantId = 1, Capacity = 80, IsOpen = true, Start = new DateTime(2022, 5, 3, 18, 0, 0), Duration = 300 }
                );
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
    }
}

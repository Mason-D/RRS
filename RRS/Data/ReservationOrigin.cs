﻿namespace RRS.Data
{
    public class ReservationOrigin
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}

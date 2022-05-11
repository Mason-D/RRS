﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RRS.Data;
using RRS.Models;

namespace RRS.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SittingsController : ControllerBase        
    {
        private readonly ApplicationDbContext _context;

        public SittingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("available/{start}/{end?}")]
        public ActionResult<IEnumerable<SittingDto>> Available(DateTime start, DateTime end = new DateTime())
        {
            var startLocal = start.ToLocalTime();
            var endLocal = end == new DateTime() ? startLocal.AddDays(28 * 3) : end.ToLocalTime();

                return _context.Sittings
                            .Where(s => s.IsOpen && s.Start.Date >= startLocal.Date && s.Start.Date <= endLocal.Date)
                            .Select(s => new SittingDto
                            {
                                Id = s.Id,
                                Start = s.Start,
                                Duration = s.Duration,
                                Capacity = s.Capacity,
                                IsOpen = s.IsOpen,
                                SittingTypeDescription = s.SittingType.Description
                            })
                            .ToList();
        }

        [HttpGet]
        [Route("any/{start}/{end?}")]
        public ActionResult<IEnumerable<SittingDto>> Any(DateTime start, DateTime end = new DateTime())
        {
            var startLocal = start.ToLocalTime();
            var endLocal = end == new DateTime() ? startLocal.AddDays(28 * 3) : end.ToLocalTime();

            return _context.Sittings
                        .Where(s => s.Start.Date >= startLocal.Date && s.Start.Date <= endLocal.Date)
                        .Select(s => new SittingDto
                        {
                            Id = s.Id,
                            Start = s.Start,
                            Duration = s.Duration,
                            Capacity = s.Capacity,
                            IsOpen = s.IsOpen,
                            SittingTypeDescription = s.SittingType.Description
                        })
                        .ToList();
        }

        [HttpGet]
        [Route("distinct-available/{start}/{end?}")]
        public ActionResult<Dictionary<int, Dictionary<int, IEnumerable<int>>>> DistinctAvailable(DateTime start, DateTime end = new DateTime())
        {          
            var startLocal = start.ToLocalTime();
            var endLocal = end == new DateTime() ? startLocal.AddDays(28 * 3) : end.ToLocalTime();

            var sittings = _context.Sittings.Where(s => s.IsOpen && s.Start.Date >= startLocal.Date && s.Start.Date <= endLocal.Date)
                .Select( s => new { Start = s.Start})
                .ToArray();

            return sittings.GroupBy(s => s.Start.Year).ToDictionary(x => x.Key, 
                        x => x.GroupBy(s => s.Start.Month).ToDictionary(x => x.Key, 
                            x => x.GroupBy(s => s.Start.Day).Select(x => x.Key)));
        }

        [HttpGet]
        [Route("day-types/{year}/{month}/{day}")]
        public ActionResult<IEnumerable<SittingByDayDto>> DayTypes(int year, int month, int day )
        {


            DateTime reservationDate = new DateTime(year, month, day);
            //var dateLocal = reservationDate.ToLocalTime();

            return _context.Sittings
                        
                        .Where(s => s.IsOpen
                                && s.Start.Date == reservationDate.Date)
                        .Select(s => new SittingByDayDto { Id = s.Id, Type = s.SittingType.Description, Duration = s.Duration, Start = s.Start.ToString("HH:mm") })
                        .ToList();
        }

        // Returns all sittings in day
        //[HttpGet]
        //[Route("available-by-day/{date}")]
        //public ActionResult<IEnumerable<Sitting>> AvailableByDay(DateTime date)
        //{
        //    return _context.Sittings
        //        .Where(s => s.IsOpen && s.Start == date)
        //        .ToList();
        //}
    }
}

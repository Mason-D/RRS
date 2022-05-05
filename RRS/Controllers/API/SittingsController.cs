using Microsoft.AspNetCore.Http;
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
                            .Where(s => s.IsOpen
                                        && s.Start >= startLocal
                                        && s.Start < endLocal)
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
        public ActionResult<Dictionary<int, List<Dictionary<int, List<int>>>>> DistinctAvailable(DateTime start, DateTime end = new DateTime())
        {          
            var startLocal = start.ToLocalTime();
            var endLocal = end == new DateTime() ? startLocal.AddDays(28 * 3) : end.ToLocalTime();
            var yearMonthDict = new Dictionary<int, List<int>>();
            var monthDayDict = new Dictionary<int, List<int>>();

            var sittings = _context.Sittings
                        .Where(s => s.IsOpen
                                    && s.Start >= startLocal
                                    && s.Start < endLocal)
                        .Select(s => new { Year = s.Start.Year, Month = s.Start.Month, Day = s.Start.Day })
                        .ToList();

            foreach (var sitting in sittings)
            {

                if (yearMonthDict.ContainsKey(sitting.Year))
                {
                    if (!yearMonthDict[sitting.Year].Contains(sitting.Month))
                    {
                        yearMonthDict[sitting.Year].Add(sitting.Month);
                    }
                }
                else
                {
                    yearMonthDict.Add(sitting.Year, new List<int>());
                    yearMonthDict[sitting.Year].Add(sitting.Month);
                }
            }

            foreach (var sitting in sittings)
            {
                if (monthDayDict.ContainsKey(sitting.Month))
                {
                    if (!monthDayDict[sitting.Month].Contains(sitting.Day))
                    {
                        monthDayDict[sitting.Month].Add(sitting.Day);
                    }
                }
                else
                {
                    monthDayDict.Add(sitting.Month, new List<int>());
                    monthDayDict[sitting.Month].Add(sitting.Day);
                }
            }

            var fusedDict = new Dictionary<int, List<Dictionary<int, List<int>>>>();

            foreach (var yearMonth in yearMonthDict)
            {
                foreach (var monthDay in monthDayDict)
                {
                    if (fusedDict.TryGetValue(yearMonth.Key, out var oldMonthDayDict))
                    {
                        var temp = new Dictionary<int, List<int>>();
                        temp.Add(monthDay.Key, monthDay.Value);

                        fusedDict[yearMonth.Key].Add(temp);
                    }
                    else
                    {
                        var temp1 = new List<Dictionary<int, List<int>>>();
                        var temp2 = new Dictionary<int, List<int>>();
                        temp2.Add(monthDay.Key, monthDay.Value);
                        fusedDict.Add(yearMonth.Key, temp1);
                    }
                }
            }

            return fusedDict;
        }

        [HttpGet]
        [Route("day-types/{date}")]
        public ActionResult<IEnumerable<SittingByDayDto>> DayTypes(DateTime date)
        {
            var dateLocal = date.ToLocalTime();

            return _context.Sittings
                        
                        .Where(s => s.IsOpen
                                && s.Start.Date == date.Date)
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

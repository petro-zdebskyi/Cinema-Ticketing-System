using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Entities
{
    /// <summary>
    /// Represents an entry in the schedule, which containts additional information besides showtime
    /// </summary>
    public class ScheduleEntry
    {
        public int Id { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Name { get; set; }
        public int RunningTime { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}

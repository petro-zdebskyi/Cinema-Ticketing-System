using System;
using System.Collections.Generic;
using Cinema.Entities;

namespace Cinema.Repositories
{
    /// <summary>
    /// Represents a number of methods to work with a database of Showtime objects
    /// </summary>
    public interface ISqlShowtimeRepository
    {
        IEnumerable<Showtime> SelectByStartDate(DateTime startDate);
        IEnumerable<ScheduleEntry> SelectSchedule(DateTime startDate);
        int AddShowtime(Showtime showtime);
        int DeleteShowtime(int id);
        int ModifyShowtime(Showtime showtime);       
    }
}
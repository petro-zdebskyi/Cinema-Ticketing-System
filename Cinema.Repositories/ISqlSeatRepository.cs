using System.Collections.Generic;
using Cinema.Entities;

namespace Cinema.Repositories
{
    /// <summary>
    /// Exposes a method for retrieving a collection of Seat objects marked as free from the database
    /// </summary>
    public interface ISqlSeatRepository
    {
        IEnumerable<Seat> GetFreeSeats(int showtimeId);
    }
}
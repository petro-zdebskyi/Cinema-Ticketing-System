using System;

namespace Cinema.Entities
{
    /// <summary>
    /// Represents a showtime in a cinema
    /// </summary>
    public class Showtime
    {
        public int Id { get; set; }
        public DateTime DateAndTime { get; set; }
        public int MovieId { get; set; }
        public decimal Price { get; set; }
    }
}

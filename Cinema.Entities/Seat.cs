using System;

namespace Cinema.Entities
{
    /// <summary>
    /// Represents a seat in a cinema hall
    /// </summary>
    public class Seat
    {
        public int Id { get; set; }
        public string Row { get; set; }
        public int SeatNumber { get; set; }
        public int Section { get; set; }
    }
}

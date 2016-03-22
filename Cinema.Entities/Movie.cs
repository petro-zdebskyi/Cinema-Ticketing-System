using System;

namespace Cinema.Entities
{
    /// <summary>
    /// Represents a movie in the cinema
    /// </summary>
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RunningTime { get; set; }
        public int Deleted { get; set; }

    }
}

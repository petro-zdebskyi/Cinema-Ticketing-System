using System;

namespace Cinema.Entities
{
    /// <summary>
    /// Represents a user of the cinema ticketing system
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Disabled { get; set; }
    }
}

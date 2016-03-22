using System;

namespace Cinema.Entities
{
    /// <summary>
    /// Represents a customer of the cinema
    /// </summary>
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CardNumber { get; set; }
        public decimal Discount { get; set; }
        public int TicketsPurchased { get; set; }
    }
}

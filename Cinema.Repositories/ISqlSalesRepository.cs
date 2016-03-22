namespace Cinema.Repositories
{
    /// <summary>
    /// Represents a class for performing common sale operations
    /// </summary>
    public interface ISqlSalesRepository
    {
        int BuyTicketImpersonal(int showtimeId, int seatId);
        int BuyTicketByCustomer(int showtimeId, int seatId, int customerId);
        decimal GetPrice(int showtimeId, int seatId);
        decimal GetDiscountedPrice(int showtimeId, int seatId, int customerId);
    }
}
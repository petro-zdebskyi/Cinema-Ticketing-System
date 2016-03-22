using System;
using System.Data;
using System.Data.SqlClient;

namespace Cinema.Repositories
{
    /// <summary>
    /// Represents a class for performing with common sales operations using a database
    /// </summary>
    public class SqlSalesRepository : ISqlSalesRepository
    {
        #region Private fields
        private readonly string _connectionString;
        private const string GetPriceQuery = "SELECT dbo.GetPrice(@showtimeId, @seatId)";
        private const string GetDiscountedPriceQuery = "SELECT dbo.GetDiscountedPrice(@showtimeId, @seatId, @customerId)";
        #endregion

        #region Constructors
        public SqlSalesRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        #endregion

        #region Public methods

        /// <summary>
        /// Conducts ticket sale without using customer account
        /// </summary>
        /// <param name="showtimeId">Showtime id</param>
        /// <param name="seatId">Seat id</param>
        /// <returns>Integer that represents the result of the operation (0 - success)</returns>
        public int BuyTicketImpersonal(int showtimeId, int seatId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spBuyTicketImpersonal";
                    command.Parameters.AddWithValue("@showtimeId", showtimeId);
                    command.Parameters.AddWithValue("@seatId", seatId);
                    command.Parameters.Add(new SqlParameter("@transactionId", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    });

                    command.ExecuteNonQuery();

                    return (int)command.Parameters["@transactionId"].Value;
                }
            }
        }

        /// <summary>
        /// Conducts ticket sale using customer account
        /// </summary>
        /// <param name="showtimeId">Showtime id</param>
        /// <param name="seatId">Seat id</param>
        /// <param name="customerId">Customer id</param>
        /// <returns>Integer that represents the result of the operation (0 - success)</returns>
        public int BuyTicketByCustomer(int showtimeId, int seatId, int customerId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spBuyTicketByCustomer";
                    command.Parameters.AddWithValue("@showtimeId", showtimeId);
                    command.Parameters.AddWithValue("@seatId", seatId);
                    command.Parameters.AddWithValue("@customerId", customerId);
                    command.Parameters.Add(new SqlParameter("@transactionId", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    });

                    command.ExecuteNonQuery();

                    return (int)command.Parameters["@transactionId"].Value;
                }
            }
        }

        /// <summary>
        /// Gets ticket price for impersonal ticket sale
        /// </summary>
        /// <param name="showtimeId"></param>
        /// <param name="seatId"></param>
        /// <returns>Decimal that represents price</returns>
        public decimal GetPrice(int showtimeId, int seatId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = GetPriceQuery;
                    command.Parameters.AddWithValue("@showtimeId", showtimeId);
                    command.Parameters.AddWithValue("@seatId", seatId);
                    return Convert.ToDecimal(command.ExecuteScalar());
                }
            }
        }

        /// <summary>
        /// Gets ticket price for a specified customer 
        /// </summary>
        /// <param name="showtimeId"></param>
        /// <param name="seatId"></param>
        /// <param name="customerId"></param>
        /// <returns>Decimal that represents price</returns>
        public decimal GetDiscountedPrice(int showtimeId, int seatId, int customerId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = GetDiscountedPriceQuery;
                    command.Parameters.AddWithValue("@showtimeId", showtimeId);
                    command.Parameters.AddWithValue("@seatId", seatId);
                    command.Parameters.AddWithValue("@customerId", customerId);
                    return Convert.ToDecimal(command.ExecuteScalar());
                }
            }
        }
        #endregion
    }
}

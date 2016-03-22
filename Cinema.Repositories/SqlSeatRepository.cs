using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Cinema.Entities;

namespace Cinema.Repositories
{
    /// <summary>
    /// Represents a class for working with a remote database of Customer entities
    /// </summary>
    public class SqlSeatRepository : ISqlSeatRepository
    {
        #region Private fields
        private readonly string _connectionString;
        private List<Seat> _seatList;
        #endregion

        #region Constructors
        public SqlSeatRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Selects all seats marked as free for a specified showtime from the database
        /// </summary>
        /// <param name="showtimeId">Showtime id</param>
        /// <returns>IEnumerable collection of Seat objects</returns>
        public IEnumerable<Seat> GetFreeSeats(int showtimeId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spGetFreeSeats";
                    command.Parameters.AddWithValue("@showtimeId", showtimeId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        _seatList = new List<Seat>();
                        while(reader.Read())
                        {
                            _seatList.Add(new Seat()
                            {
                                Id = (int)reader["Id"],
                                Row = (string)reader["Row"],
                                SeatNumber = (int)reader["Seat"],
                                Section = (int)reader["Section"]
                            });
                        }

                        return _seatList;
                    }
                }
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Cinema.Entities;

namespace Cinema.Repositories
{
    /// <summary>
    /// Represents a class for working with a remote database of Showtime entities
    /// </summary>
    public class SqlShowtimeRepository : ISqlShowtimeRepository
    {
        //Petro Zdebsky Review: upercase of const variables
        #region Private fields
        private readonly string _connectionString;
        private const string showtimeQuery = @"SELECT * FROM tblShowtimes WHERE DateAndTime >= @startDate AND Deleted = 0";
        private const string scheduleEntryQuery = @"SELECT * FROM MovieScheduleView WHERE DateAndTime >= @startDate";
        private List<Showtime> _showtimeList;
        private List<ScheduleEntry> _scheduleEntryList;
        #endregion

        #region Constructors
        public SqlShowtimeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Selects all showtimes from a specified date
        /// </summary>
        /// <param name="startDate">DateTime object that specifies date</param>
        /// <returns>IEnumerable collection of Showtime object</returns>
        public IEnumerable<Showtime> SelectByStartDate(DateTime startDate)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = showtimeQuery;
                    command.Parameters.AddWithValue("@startDate", startDate);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        _showtimeList = new List<Showtime>();
                        while (reader.Read())
                        {
                            _showtimeList.Add(new Showtime()
                            {
                                Id = (int)reader["Id"],
                                DateAndTime = (DateTime)reader["DateAndTime"],
                                MovieId = (int)reader["MovieId"],
                                Price = (decimal)reader["Price"]
                            });
                        }

                        return _showtimeList;
                    }
                }
            }
        }

        /// <summary>
        /// Selects all schedule entries from a specified date
        /// </summary>
        /// <param name="startDate">DateTime object that specifies date</param>
        /// <returns>IEnumerable collection of ScheduleEntry object</returns>
        public IEnumerable<ScheduleEntry> SelectSchedule(DateTime startDate)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = scheduleEntryQuery;
                    command.Parameters.AddWithValue("@startDate", startDate);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        _scheduleEntryList = new List<ScheduleEntry>();
                        while (reader.Read())
                        {
                            _scheduleEntryList.Add(new ScheduleEntry()
                            {
                                Id = (int)reader["Id"],
                                DateAndTime = (DateTime)reader["DateAndTime"],
                                RunningTime = (int)reader["RunningTime"],
                                Name = (string)reader["Name"],
                                Description = (string)reader["Description"],
                                Price = (decimal)reader["Price"]
                            });
                        }

                        return _scheduleEntryList;
                    }
                }
            }
        }

        /// <summary>
        /// Adds specified showtime to the database
        /// </summary>
        /// <param name="showtime">Showtime object</param>
        /// <returns>Integer that represents the result of the operation (0 - success)</returns>
        public int AddShowtime(Showtime showtime)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spAddShowtime";
                    command.Parameters.AddWithValue("@dateAndTime", showtime.DateAndTime);
                    command.Parameters.AddWithValue("@movieId", showtime.MovieId);
                    command.Parameters.AddWithValue("@price", showtime.Price);
                    command.Parameters.Add(new SqlParameter("@result", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    });
                    command.ExecuteNonQuery();

                    return Convert.ToInt32(command.Parameters["@result"].Value);
                }
            }
        }

        /// <summary>
        /// Deletes movie by the specified id
        /// </summary>
        /// <param name="id">Showtime id</param>
        /// <returns>Integer that represents the result of the operation (0 - success)</returns>
        public int DeleteShowtime(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spDeleteShowtime";
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.Add(new SqlParameter("@result", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    });
                    command.ExecuteNonQuery();

                    return Convert.ToInt32(command.Parameters["@result"].Value);
                }
            }
        }

        /// <summary>
        /// Modifies specified showtime in the database
        /// </summary>
        /// <param name="showtime">Showtime object</param>
        /// <returns>Integer that represents the result of the operation (0 - success)</returns>
        public int ModifyShowtime(Showtime showtime)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spModifyShowtime";
                    command.Parameters.AddWithValue("@id", showtime.Id);
                    command.Parameters.AddWithValue("@dateAndTime", showtime.DateAndTime);
                    command.Parameters.AddWithValue("@movieId", showtime.MovieId);
                    command.Parameters.AddWithValue("@price", showtime.Price);
                    command.Parameters.Add(new SqlParameter("@result", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    });
                    command.ExecuteNonQuery();

                    return Convert.ToInt32(command.Parameters["@result"].Value);
                }
            }
        }
        #endregion
    }
}

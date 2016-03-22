using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Cinema.Entities;

namespace Cinema.Repositories
{
    /// <summary>
    /// Represents a class for working with a remote database of Movie entities
    /// </summary>
    public class SqlMovieRepository : ISqlMovieRepository
    {
        #region Private fields
        private readonly string _connectionString;
        private const string Query = "SELECT * FROM tblMovies WHERE Deleted = 0";
        private List<Movie> _movieList;
        #endregion

        #region Constructors
        public SqlMovieRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Selects all movies from the database and puts them into a collection of Movie instances 
        /// </summary>
        /// <returns>IEnumberable collection of Movie objects</returns>
        public IEnumerable<Movie> SelectAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = Query;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        _movieList = new List<Movie>();
                        while (reader.Read())
                        {
                            _movieList.Add(new Movie()
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"],
                                Description = (string)reader["Description"],
                                RunningTime = (int)reader["RunningTime"],
                                Deleted = (int)reader["Deleted"]
                            });
                        }

                        return _movieList;
                    }
                }
            }
        }

        /// <summary>
        /// Adds new movie to the database
        /// </summary>
        /// <param name="movie">A Movie object to be added</param>
        /// <returns>Integer that represents the result of the operation (0 - success)</returns>
        public int AddMovie(Movie movie)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spAddMovie";
                    command.Parameters.AddWithValue("@name", movie.Name);
                    command.Parameters.AddWithValue("@runningTime", movie.RunningTime);
                    command.Parameters.AddWithValue("@description", movie.Description);
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
        /// Deletes a movie from the database by specified id
        /// </summary>
        /// <param name="id">Id of the movie to be deleted</param>
        /// <returns>Integer that represents the result of the operation (0 - success)</returns>
        public int DeleteMovie(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spDeleteMovie";
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
        /// Modifies movie in the database
        /// </summary>
        /// <param name="movie">Movie to be modified</param>
        /// <returns>Integer that represents the result of the operation (0 - success)</returns>
        public int ModifyMovie(Movie movie)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spModifyMovie";
                    command.Parameters.AddWithValue("@id", movie.Id);
                    command.Parameters.AddWithValue("@name", movie.Name);
                    command.Parameters.AddWithValue("@runningTime", movie.RunningTime);
                    command.Parameters.AddWithValue("@description", movie.Description);
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

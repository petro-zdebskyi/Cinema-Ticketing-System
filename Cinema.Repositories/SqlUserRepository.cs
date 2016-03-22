using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Cinema.Entities;

namespace Cinema.Repositories
{
    /// <summary>
    /// Represents a class for working with a remote database of User entities
    /// </summary>
    public class SqlUserRepository : IUserRepository
    {
        #region Private fields
        private const string spGetUserByLoginQuery = "spGetUserByLogin";
        private readonly string _connectionString;
        #endregion

        #region Constructors
        public SqlUserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        #endregion

        #region Public methods

        /// <summary>
        /// Gets user by specified login and password
        /// </summary>
        /// <param name="login">User login</param>
        /// <param name="password">User password</param>
        /// <returns>User object</returns>
        public User GetUserByLogin(string login, string password)
        {
            string passwordHash = Encryptor.MD5Hash(password);
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = spGetUserByLoginQuery;
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", passwordHash);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        User user = null;
                        if (reader.Read())
                        {
                            user = new User();
                            user.Id = (int)reader["Id"];
                            user.FirstName = (string)reader["FirstName"];
                            user.LastName = (string)reader["LastName"];
                            user.Login = (string)reader["Login"];
                            user.Disabled = (bool)reader["Disabled"];
                        }
                        return user;
                    }
                }
            }
        }
        #endregion
    }
}

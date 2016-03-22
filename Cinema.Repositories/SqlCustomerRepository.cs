using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Cinema.Entities;

namespace Cinema.Repositories
{
    /// <summary>
    /// Represents a class for working with a remote database of Customer entities
    /// </summary>
    public class SqlCustomerRepository : ISqlCustomerRepository
    {
        #region Private fields
        private readonly string _connectionString;
        private const string Query = @"SELECT * FROM tblCustomers;";
        private List<Customer> _customerList;
        #endregion

        #region Constructors
        public SqlCustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Selects all customers from the database and puts them into a collection of Customer instances 
        /// </summary>
        public IEnumerable<Customer> SelectAll()
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
                        _customerList = new List<Customer>();
                        while (reader.Read())
                        {
                            _customerList.Add(new Customer()
                            {
                                Id = (int)reader["Id"],
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"],
                                CardNumber = (int)reader["CardNumber"],
                                Discount = (decimal)reader["Discount"],
                                TicketsPurchased = (int)reader["TicketsPurchased"]
                            });
                        }

                        return _customerList;
                    }
                }
            }
        }

        /// <summary>
        /// Selects all customers with specified first name, last name and card number from the database 
        /// </summary>
        /// <param name="firstName">Customer's first name</param>
        /// <param name="lastName">Customer's last name</param>
        /// <param name="cardNumber">Customer's card number</param>
        /// <returns>IEnumerable collection of Customer objects</returns>
        public IEnumerable<Customer> SelectByName(string firstName, string lastName, int cardNumber)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = @"spGetCustomerByName";
                    command.Parameters.AddWithValue("@firstName", firstName);
                    command.Parameters.AddWithValue("@lastName", lastName);
                    command.Parameters.AddWithValue("@cardNumber", cardNumber);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        _customerList = new List<Customer>();

                        while (reader.Read())
                        {
                            _customerList.Add(new Customer()
                            {
                                Id = (int)reader["Id"],
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"],
                                CardNumber = (int)reader["CardNumber"],
                                Discount = (decimal)reader["Discount"],
                                TicketsPurchased = (int)reader["TicketsPurchased"]
                            });
                        }

                        return _customerList;
                    }
                }
            }
        }

        /// <summary>
        /// Adds new customer with specified first name, last name and card number to the database
        /// </summary>
        /// <param name="firstName">Customer's first name</param>
        /// <param name="lastName">Customer's last name</param>
        /// <param name="cardNumber">Customer's card number</param>
        /// <returns>Integer that represents the result of the operation (0 - success)<returns>
        public int AddCustomer(string firstName, string lastName, int cardNumber)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = @"spAddCustomer";
                    command.Parameters.AddWithValue("@firstName", firstName);
                    command.Parameters.AddWithValue("@lastName", lastName);
                    command.Parameters.AddWithValue("@cardNumber", cardNumber);
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
   


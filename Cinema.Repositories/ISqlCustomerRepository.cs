using System;
using System.Collections.Generic;
using Cinema.Entities;

namespace Cinema.Repositories
{
    /// <summary>
    /// Represents Represents a number of methods to work with a database of Customer entities
    /// </summary>
    public interface ISqlCustomerRepository
    {
        IEnumerable<Customer> SelectAll();
        IEnumerable<Customer> SelectByName(string firstName, string lastName, int cardNumber);
        int AddCustomer(string firstName, string lastName, int cardNumber); 
    }
}
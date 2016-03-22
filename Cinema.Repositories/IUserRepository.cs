using System;
using Cinema.Entities;

namespace Cinema.Repositories
{
    /// <summary>
    /// Exposes a method to retrieve a User entity from the database
    /// </summary>
    public interface IUserRepository
    {
        User GetUserByLogin(string login, string password);
    }
}

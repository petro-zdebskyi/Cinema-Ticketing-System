using System;
using Cinema.Entities;

namespace Cinema_Ticketing_System.Code
{
    /// <summary>
    /// Represents a class implementing singleton behaviour that holds current user instance 
    /// </summary>
    public static class CurrentUser
    {
        #region Private fields
        private static User currentUser;
        #endregion

        #region Initializer
        public static void Initialize(User user)
        {
            if (currentUser != null)
            {
                throw new InvalidOperationException("Current user has already been specified");
            }
            currentUser = user;
        }
        #endregion

        #region Properties
        public static int Id
        {
            get
            {
                return currentUser.Id;
            }
        }

        public static string FirstName
        {
            get
            {
                return currentUser.FirstName;
            }
        }

        public static string Surname
        {
            get
            {
                return currentUser.LastName;
            }
        }

        public static string Login
        {
            get
            {
                return currentUser.Login;
            }
        }
        #endregion
    }
}

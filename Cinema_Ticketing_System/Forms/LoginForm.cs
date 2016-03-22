using System;
using System.Windows.Forms;
using Cinema.Entities;
using Cinema.Repositories;
using System.Configuration;
using Cinema_Ticketing_System.Code;

namespace Cinema_Ticketing_System.Forms
{
    public partial class LoginForm : Form
    {
        #region Private fields
        private readonly IUserRepository _userRepository;
        #endregion

        #region Constructors
        public LoginForm()
        {
            _userRepository = new SqlUserRepository(ConfigurationManager.ConnectionStrings["CinemaTicketingSystem_ConnectionString"].ConnectionString);
            InitializeComponent();
        }
        #endregion

        #region Event handlers
        private void enterCredentialsButton_Click(object sender, EventArgs e)
        {
            string login = userNameTextBox.Text;
            string password = passwordTextBox.Text;

            User user = _userRepository.GetUserByLogin(login, password);
            if (user == null)
            {
                MessageBox.Show(this, "Invalid user name or password", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                CurrentUser.Initialize(user);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        #endregion
    }
}

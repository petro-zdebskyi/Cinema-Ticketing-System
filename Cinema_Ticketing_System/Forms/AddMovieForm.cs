using System;
using System.Windows.Forms;
using Cinema.Entities;

namespace Cinema_Ticketing_System
{
    /// <summary>
    /// Represents a form for adding instances of Movie class to the database 
    /// </summary>
    public partial class AddMovieForm : Form
    {
        #region Private fields
        private Movie _movie;
        #endregion

        #region Constructors
        public AddMovieForm(Movie movie)
        {
            InitializeComponent();
            _movie = movie;
        }
        #endregion

        #region Event handlers
        private void addMovieButton_Click(object sender, EventArgs e)
        {
            _movie.Name = movieNameTextBox.Text;
            _movie.RunningTime = Convert.ToInt32(runningLengthTextBox.Text);
            _movie.Description = descriptionTextBox.Text;
            DialogResult = DialogResult.OK;
        }
        #endregion
    }
}

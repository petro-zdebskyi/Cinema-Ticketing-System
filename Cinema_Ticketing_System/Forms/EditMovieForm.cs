using System;
using System.Windows.Forms;
using Cinema.Entities;

namespace Cinema.Repositories
{
    /// <summary>
    /// Represents a form for modifying instances of Movie class in the database 
    /// </summary>
    public partial class EditMovieForm : Form
    {
        #region Private fields
        private Movie _movie;
        #endregion

        #region Constructors
        public EditMovieForm(Movie movie)
        {
            InitializeComponent();
            _movie = movie;
            InitializeFormFileds();
        }
        #endregion

        #region Event handlers
        private void saveMovieButton_Click(object sender, EventArgs e)
        {
            _movie.Name = movieNameTextBox.Text;
            _movie.RunningTime = Convert.ToInt32(runningLengthTextBox.Text);
            _movie.Description = descriptionTextBox.Text;
            DialogResult = DialogResult.OK;
        }
        #endregion

        #region Helper methods
        /// <summary>
        /// Initializes the fields on the form, loading parameters of chosen movie
        /// </summary>
        private void InitializeFormFileds()
        {
            movieNameTextBox.Text = _movie.Name;
            runningLengthTextBox.Text = Convert.ToString(_movie.RunningTime);
            descriptionTextBox.Text = _movie.Description;
        }
        #endregion
    }
}

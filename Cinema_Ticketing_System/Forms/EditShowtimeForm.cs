using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Cinema.Entities;

namespace Cinema_Ticketing_System
{
    /// <summary>
    /// Represents a form for modifying instances of Showtime class in the database 
    /// </summary>
    public partial class EditShowtimeForm : Form
    {
        #region Private fields
        private Showtime _showtime;
        private List<Movie> _movies;
        #endregion

        #region Constructors
        public EditShowtimeForm(Showtime showtime, List<Movie> movies)
        {
            _movies = movies;
            _showtime = showtime;
            InitializeComponent();
            InitializeFormFileds();  
        }
        #endregion

        #region Event handlers
        private void saveShowtimeButton_Click(object sender, EventArgs e)
        {
            _showtime.Price = Convert.ToDecimal(priceTextBox.Text);
            _showtime.DateAndTime = dateAndTimePicker.Value;
            // Petro Zdebsky Review: use Int32.TryParse() instead Convert.ToInt32() 
            _showtime.MovieId = Convert.ToInt32((from m in _movies where m.Name == movieBox.SelectedItem.ToString() select m.Id).First()); // Get the Id of the movie by its name
            DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion

        #region Helper methods
        /// <summary>
        /// Initializes the fields on the form, loading parameters of chosen showtime
        /// </summary>
        private void InitializeFormFileds()
        {
            foreach (var mov in _movies)
            {
                movieBox.Items.Add(mov.Name);
            }
            priceTextBox.Text = Convert.ToString(_showtime.Price);
            dateAndTimePicker.Value = _showtime.DateAndTime;
            var selected = (Movie)(from m in _movies where m.Id == _showtime.Id select m).First();
            movieBox.SelectedItem = selected.Name;
        }
        #endregion
    }
}

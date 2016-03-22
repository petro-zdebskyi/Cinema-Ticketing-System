using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Cinema.Entities;

namespace Cinema_Ticketing_System
{
    /// <summary>
    /// Represents a form for adding instances of Showtime class to the database 
    /// </summary>
    public partial class AddShowtimeForm : Form
    {
        #region Private fields
        private Showtime _newShowtime;
        private List<Movie> _movies;
        #endregion

        #region Constructors
        public AddShowtimeForm(Showtime newShowtime, List<Movie> movies)
        {
            _movies = movies;
            _newShowtime = newShowtime;
            InitializeComponent();
            InitializeFormFields();
        }
        #endregion

        #region Event handlers
        private void addShowtimeButton_Click(object sender, EventArgs e)
        {
            _newShowtime.DateAndTime = dateAndTimePicker.Value;
            _newShowtime.Price = Convert.ToInt32(priceTextBox.Text);
            _newShowtime.MovieId = Convert.ToInt32((from m in _movies where m.Name == movieBox.SelectedItem.ToString() select m.Id).First());
            DialogResult = DialogResult.OK;
        }
        #endregion

        #region Helper methods
        /// <summary>
        /// Initializes the form with a list of films available
        /// </summary>
        private void InitializeFormFields()
        {
            foreach (var mov in _movies)
            {
                movieBox.Items.Add(mov.Name);
            }

            var selected = ((Movie)(from m in _movies select m).First()).Name; // Selects first movie from the list in moviesBox element
            movieBox.SelectedItem = selected;
        }
        #endregion
    }
}

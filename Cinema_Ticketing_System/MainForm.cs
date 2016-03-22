using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using Cinema.Entities;
using Cinema.Repositories;
using System.Configuration;

namespace Cinema_Ticketing_System
{
    public partial class MainForm : Form
    {
        #region Private fields
        private readonly string _connectionString;
        private readonly SqlShowtimeRepository _showtimeRepository;
        private readonly SqlMovieRepository _movieRepository;
        private List<ScheduleEntry> _scheduleEntryList;
        private List<Movie> _movieList;
        private List<Showtime> _showtimeList;
        #endregion

        #region Constructors
        public MainForm()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["CinemaTicketingSystem_ConnectionString"].ConnectionString;
            _showtimeRepository = new SqlShowtimeRepository(_connectionString);
            _movieRepository = new SqlMovieRepository(_connectionString);
            InitializeComponent();
        }
        #endregion

        #region Event handlers
        private void MainWindow_Load(object sender, EventArgs e)
        {
            RefreshTables();
        }

        private void chooseSeatButton_Click(object sender, EventArgs e)
        {
            if (scheduleGridView.RowCount == 0)
            {
                MessageBox.Show("There is no showtimes in the database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int showtimeId = (int)scheduleGridView.SelectedRows[0].Cells["showtimeId"].Value; // Get the Id of the movie in dataGridView
            string filmName = (string)scheduleGridView.SelectedRows[0].Cells["filmName"].Value; // Get the name of the chosen movie
            BuyTicketForm buyTicketForm = new BuyTicketForm(showtimeId, filmName);
            buyTicketForm.ShowDialog();
        }

        private void addMovieButton_Click(object sender, EventArgs e)
        {
            Movie newMovie = new Movie();
            AddMovieForm addMovieWindow = new AddMovieForm(newMovie);

            DialogResult result = addMovieWindow.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (_movieRepository.AddMovie(newMovie) == 0)
                {
                    MessageBox.Show("Movie was successfully added to the database", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    RefreshTables();
                    return;
                }
                    MessageBox.Show("Error occured when adding the movie. Movie was not added");
            }
        }

        private void editMovieButton_Click(object sender, EventArgs e)
        {
            if (movieGridView.RowCount == 0)
            {
                MessageBox.Show("There is no movies in the database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int chosenMovieId = (int)movieGridView.SelectedRows[0].Cells["id"].Value; // Get the Id of the movie chosen for modifying
            Movie chosendMovie = _movieList.FindAll(x => x.Id == chosenMovieId)[0]; // Get the Movie object by chosen Id
            EditMovieForm editMovieWindow = new EditMovieForm(chosendMovie);

            editMovieWindow.ShowDialog();
            if (editMovieWindow.DialogResult == DialogResult.OK)
            {
                _movieRepository.ModifyMovie(chosendMovie);
                MessageBox.Show("Movie was successfuly modified!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                RefreshTables();
            }
        }

        private void deleteMovieButton_Click(object sender, EventArgs e)
        {
            if(movieGridView.RowCount == 0)
            {
                MessageBox.Show("There is no movies in the database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int chosenMovieId = (int)movieGridView.SelectedRows[0].Cells["id"].Value; // Get the Id of the movie chosen in dataGridView

            DialogResult result = MessageBox.Show("Do you really want to delete movie?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                if (_movieRepository.DeleteMovie(chosenMovieId) == 0)
                {
                    MessageBox.Show("Movie was successfully deleted from the database", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    RefreshTables();
                    return;
                }
                    MessageBox.Show("Error occured when deleting the movie. Movie was not deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void addShowtimeButton_Click(object sender, EventArgs e)
        {
            if (_movieList.Count == 0)
            {
                MessageBox.Show("There is no movies in the database. You should add a movie first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Showtime newShowtime = new Showtime();
            AddShowtimeForm addWindow = new AddShowtimeForm(newShowtime, _movieList);

            DialogResult result = addWindow.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (_showtimeRepository.AddShowtime(newShowtime) == 0)
                {
                    MessageBox.Show("Showtime was successfully added to the database", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    RefreshTables();
                    return;
                }
                    MessageBox.Show("The time entered overlaps with existitng time. Please, choose another time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editShowtimeButton_Click(object sender, EventArgs e)
        {
            if (showtimeGridView.RowCount == 0)
            {
                MessageBox.Show("There is no showtimes in the database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int chosenShowtimeId = (int)showtimeGridView.SelectedRows[0].Cells["_showtimeId"].Value; // Get the Id of the showtime chosen in dataGridView
            Showtime chosenShowtime = _showtimeList.FindAll(x => x.Id == chosenShowtimeId)[0]; // Get the Showtime object by Id
            EditShowtimeForm editWindow = new EditShowtimeForm(chosenShowtime, _movieList);

            editWindow.ShowDialog();
            if (editWindow.DialogResult == DialogResult.OK)
            {
                if (_showtimeRepository.ModifyShowtime(chosenShowtime) == 0)
                {
                    MessageBox.Show("Showtime was successfuly modified!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    RefreshTables();
                    return;
                }
                MessageBox.Show("The time entered overlaps with existitng time. Please, choose another time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteShowtimeButton_Click(object sender, EventArgs e)
        {
            if (showtimeGridView.RowCount == 0)
            {
                MessageBox.Show("There is no showtimes in the database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int chosenShowtimeId = (int)showtimeGridView.SelectedRows[0].Cells["_showtimeId"].Value; // Get the Id of the showtime chosen by user

            DialogResult result = MessageBox.Show("Do you really want to delete showtime?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                if (_showtimeRepository.DeleteShowtime(chosenShowtimeId) == 0)
                {
                    MessageBox.Show("Showtime was successfully deleted from the database", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    RefreshTables();
                    return;
                }
                    MessageBox.Show("Error occured when deleting the showtime. Showtime was not deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Helper methods
        /// <summary>
        /// Refreshes all the tables on the form, loading new values from the database
        /// </summary>
        private void RefreshTables()
        {
            _scheduleEntryList = (List<ScheduleEntry>)_showtimeRepository.SelectSchedule(DateTime.Now);
            _movieList = (List<Movie>)_movieRepository.SelectAll();
            _showtimeList = (List<Showtime>)_showtimeRepository.SelectByStartDate(DateTime.Now);

            scheduleGridView.Rows.Clear();
            foreach (var entry in _scheduleEntryList)
            {
                scheduleGridView.Rows.Add(entry.Id, entry.DateAndTime, entry.Name, entry.RunningTime, entry.Price);
            }

            movieGridView.Rows.Clear();
            foreach (var entry in _movieList)
            {
                movieGridView.Rows.Add(entry.Id, entry.Name, entry.RunningTime, entry.Description);
            }

            showtimeGridView.Rows.Clear();
            foreach (var entry in _showtimeList)
            {
                string movieName = (from m in _movieList where m.Id == entry.MovieId select m.Name).First();
                showtimeGridView.Rows.Add(entry.Id, entry.DateAndTime, movieName, entry.Price);
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using Cinema.Entities;

namespace Cinema.Repositories
{
    /// <summary>
    /// Represents a number of methods to work with a database of Movie objects
    /// </summary>
    public interface ISqlMovieRepository
    {
        IEnumerable<Movie> SelectAll();
        int AddMovie(Movie movie);
        int DeleteMovie(int id);
        int ModifyMovie(Movie movie);
    }
}
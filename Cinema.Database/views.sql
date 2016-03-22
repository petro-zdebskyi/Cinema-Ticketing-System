USE CinemaTicketingSystemDb;
GO

CREATE VIEW MovieScheduleView
AS
	SELECT shows.Id, shows.DateAndTime, movies.Name, movies.[Description], movies.RunningTime, shows.Price FROM tblShowtimes shows INNER JOIN tblMovies movies ON shows.MovieId = movies.Id WHERE shows.Deleted = 0 AND movies.Deleted = 0;
GO
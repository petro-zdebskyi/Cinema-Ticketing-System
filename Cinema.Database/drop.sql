USE CinemaTicketingSystemDb;

		DROP FUNCTION dbo.GetPrice;
		DROP FUNCTION dbo.GetDiscountedPrice;
		DROP TABLE dbo.tblSales;
		DROP TABLE dbo.tblShowtimes;
		DROP TABLE dbo.tblCustomers;
		DROP TABLE dbo.tblSeats;
		DROP TABLE dbo.tblMovies;
		DROP TABLE dbo.tblSectionRates;
		DROP TABLE dbo.tblUsers;
		DROP VIEW dbo.MovieScheduleView;
		DROP PROCEDURE dbo.spBuyTicketImpersonal;
		DROP PROCEDURE dbo.spBuyTicketByCustomer;
		DROP PROCEDURE dbo.spGetCustomerByName;
		DROP PROCEDURE dbo.spGetFreeSeats;
		DROP PROCEDURE dbo.spAddCustomer;
		DROP PROCEDURE dbo.spAddMovie;
		DROP PROCEDURE dbo.spModifyMovie;
		DROP PROCEDURE dbo.spDeleteMovie;
		DROP PROCEDURE dbo.spAddShowtime;
		DROP PROCEDURE dbo.spModifyShowtime;
		DROP PROCEDURE dbo.spDeleteShowtime;
		DROP PROCEDURE spGetUserByLogin;
GO
CREATE DATABASE CinemaTicketingSystemDb
GO
USE CinemaTicketingSystemDb;

		CREATE TABLE tblSectionRates
		(
			Id INT NOT NULL IDENTITY(1, 1),
			Rate NUMERIC(18, 2) NOT NULL,
			CONSTRAINT PK_tblSectionRates_Id PRIMARY KEY(Id),
		);		
		GO

		CREATE TABLE tblCustomers
		(
			Id INT NOT NULL IDENTITY(1, 1),
			FirstName VARCHAR(50) NOT NULL,
			LastName VARCHAR(50) NOT NULL,
			CardNumber INT NOT NULL,
			Discount NUMERIC(18, 2) NOT NULL,
			TicketsPurchased INT NOT NULL,
			CONSTRAINT PK_tblCustomers_Id PRIMARY KEY(Id),
			CONSTRAINT UQ_tblCustomers_CardNumber UNIQUE(CardNumber)
		);
		GO

		CREATE TABLE tblSeats
		(
			Id INT NOT NULL IDENTITY(1, 1),
			[Row] CHAR(1) NOT NULL,
			Seat INT NOT NULL,
			Section INT NOT NULL,
			CONSTRAINT PK_tblSeats_Id PRIMARY KEY(Id),
			CONSTRAINT FK_tblSeats_Section_tblSectionRates FOREIGN KEY(Section) REFERENCES tblSectionRates(Id),
		);		
		GO

		CREATE TABLE tblMovies
		(
			Id INT NOT NULL IDENTITY(1, 1),
			Name VARCHAR(100) NOT NULL,
			[Description] VARCHAR(500) NOT NULL,
			RunningTime INT NOT NULL,
			Deleted INT NOT NULL,
			CONSTRAINT PK_tblMovies_Id PRIMARY KEY(Id)
		);
		GO

		CREATE TABLE tblShowtimes
		(
			Id INT NOT NULL IDENTITY(1, 1),
			DateAndTime SMALLDATETIME NOT NULL,
			MovieId INT NOT NULL,
			Price NUMERIC(18, 2) NOT NULL,
			Deleted INT NOT NULL,
			CONSTRAINT PK_tblShowtimes_Id PRIMARY KEY(Id),
			CONSTRAINT FK_tblShowtimes_MovieId_tblMovies FOREIGN KEY(MovieId) REFERENCES tblMovies(Id),
		);
		GO

		CREATE TABLE tblSales
		(
			Id INT NOT NULL IDENTITY(1, 1),
			ShowtimeId INT NOT NULL,
			SeatId INT NOT NULL,
			Cost NUMERIC(18, 2) NOT NULL,
			CustomerId INT NULL,
			PurchaseDate SMALLDATETIME NOT NULL,
			CONSTRAINT PK_tblSales_Id PRIMARY KEY(Id),
			CONSTRAINT FK_tblSales_ShowtimeId_tblShowtimes FOREIGN KEY(ShowtimeId) REFERENCES tblShowtimes(Id),
			CONSTRAINT FK_tblSales_SeatId_tblSeats FOREIGN KEY(SeatId) REFERENCES tblSeats(Id),
			CONSTRAINT FK_tblSales_CustomerId_tblCustomers FOREIGN KEY(CustomerId) REFERENCES tblCustomers(Id),
		);
		GO

		CREATE TABLE tblUsers
		(
			Id INT NOT NULL IDENTITY(1, 1),
			FirstName VARCHAR(50) NOT NULL,
			LastName VARCHAR(50) NOT NULL,
			[Login] VARCHAR(50) NOT NULL,
			[Password] VARCHAR(50) NOT NULL,
			[Disabled] BIT NOT NULL
			CONSTRAINT PK_tblUsers_Id PRIMARY KEY(Id), 
			CONSTRAINT UQ_tblUsers_Login UNIQUE([Login])
		);
		GO

USE CinemaTicketingSystemDb;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE spBuyTicketImpersonal
	@seatId INT,
	@showtimeId INT,
	@transactionId INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	BEGIN
		INSERT INTO tblSales(ShowtimeId, SeatId, Cost, CustomerId, PurchaseDate) VALUES
		(@showtimeId, @seatId, dbo.GetPrice(@showtimeId, @seatId), NULL, GETDATE());
		SET @transactionId = @@IDENTITY;
	END
END
GO

CREATE PROCEDURE spGetCustomerByName
	@firstName VARCHAR(50),
	@lastName VARCHAR(50),
	@cardNumber INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM tblCustomers WHERE FirstName = @firstName AND LastName = @lastName AND CardNumber = @cardNumber;
END
GO

CREATE PROCEDURE spBuyTicketByCustomer
	@seatId INT,
	@showtimeId INT,
	@customerId INT,
	@transactionId INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ticketsPurchased INT;
	SELECT @ticketsPurchased = TicketsPurchased FROM tblCustomers WHERE Id = @customerId;
	
	INSERT INTO tblSales(ShowtimeId, SeatId, Cost, CustomerId, PurchaseDate) VALUES 
	(@showtimeId, @seatId, dbo.GetDiscountedPrice(@showtimeId, @seatId, @customerId), @customerId, GETDATE());
	
	UPDATE tblCustomers
	SET TicketsPurchased = TicketsPurchased + 1
	WHERE Id = @customerId;
	
	IF ((SELECT TicketsPurchased FROM tblCustomers WHERE Id = @customerId) > 100)
	BEGIN
		UPDATE tblCustomers
		SET Discount = 5
		WHERE Id = @customerId;
	END
	ELSE IF ((SELECT TicketsPurchased FROM tblCustomers WHERE Id = @customerId) > 200)
	BEGIN
		UPDATE tblCustomers
		SET Discount = 10
		WHERE Id = @customerId;
	END
	ELSE IF ((SELECT TicketsPurchased FROM tblCustomers WHERE Id = @customerId) > 300)
	BEGIN
		UPDATE tblCustomers
		SET Discount = 15
		WHERE Id = @customerId;
	END
	SET @transactionId = @@IDENTITY;
END
GO


CREATE PROCEDURE spGetFreeSeats
	@showtimeId INT
AS
BEGIN
	SELECT * FROM tblSeats seats WHERE seats.Id NOT IN (SELECT SeatId FROM tblSales WHERE ShowtimeId = @showtimeId);
END
GO

CREATE FUNCTION GetDiscountedPrice
(
	@showtimeId INT,
	@seatId INT,
	@customerId INT
)
RETURNS NUMERIC(18, 2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @price NUMERIC(18, 2)

	DECLARE @sectionRate INT; 
	DECLARE @showtimePrice NUMERIC(18, 2);
	DECLARE @discount NUMERIC(18, 2);

	SELECT @sectionRate = Rate FROM tblSectionRates WHERE Id = (SELECT Section FROM tblSeats WHERE Id = @seatId);
	SELECT @showtimePrice = Price FROM tblShowtimes WHERE Id = @showtimeId;
	SELECT @discount = Discount FROM tblCustomers WHERE Id = @customerId;
	SELECT @price = @sectionRate * @showtimePrice * (1 - @discount * 0.01);

	-- Return the result of the function
	RETURN @price;
END
GO

CREATE FUNCTION GetPrice
(
	@showtimeId INT,
	@seatId INT
)
RETURNS NUMERIC(18, 2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @price NUMERIC(18, 2)

	DECLARE @sectionRate INT; 
	DECLARE @showtimePrice NUMERIC(18, 2);

	SELECT @sectionRate = Rate FROM tblSectionRates WHERE Id = (SELECT Section FROM tblSeats WHERE Id = @seatId);
	SELECT @showtimePrice = Price FROM tblShowtimes WHERE Id = @showtimeId;
	SELECT @price = @sectionRate * @showtimePrice;

	-- Return the result of the function
	RETURN @price;
END
GO

CREATE PROCEDURE spAddCustomer
	@firstName VARCHAR(50),
	@lastName VARCHAR(50),
	@cardNumber INT,
	@result INT OUTPUT
AS
BEGIN
	IF EXISTS(SELECT * FROM tblCustomers WHERE CardNumber = @cardNumber)
	BEGIN
		SET @result = 1;
		RETURN;
	END
	INSERT INTO tblCustomers(FirstName, LastName, CardNumber, Discount, TicketsPurchased) VALUES (@firstName, @lastName, @cardNumber, 0, 0); 
	SET @result = 0;
END
GO

CREATE PROCEDURE spAddMovie
	@name VARCHAR(100),
	@runningTime INT,
	@description VARCHAR(500),
	@result INT OUTPUT
AS
BEGIN
	INSERT INTO tblMovies(Name, [Description], RunningTime, Deleted) VALUES (@name, @description, @runningTime, 0);
	SET @result = 0;
END
GO

CREATE PROCEDURE spDeleteMovie
	@id INT,
	@result INT OUTPUT
AS
BEGIN
	UPDATE tblMovies 
	SET Deleted = 1
	WHERE Id = @id;
	SET @result = 0;
END
GO

CREATE PROCEDURE spModifyMovie
	@id INT,
	@name VARCHAR(100),
	@runningTime INT,
	@description VARCHAR(500),
	@result INT OUTPUT
AS
BEGIN
	UPDATE tblMovies 
	SET Name = @name,
	RunningTime = @runningTime,
	[Description] = @description
	WHERE Id = @id;
	SET @result = 0; 
END
GO

CREATE PROCEDURE spAddShowtime
	@dateAndTime SMALLDATETIME,
	@movieId INT,
	@price NUMERIC(18, 2),
	@result INT OUTPUT
AS
BEGIN
	DECLARE @dateAndTimeBegin SMALLDATETIME;
	DECLARE @dateAndTimeEnd SMALLDATETIME;
	DECLARE @runningTime INT;
	SELECT @runningTime = RunningTime FROM tblMovies WHERE Id = @movieId; 
	SET @dateAndTimeBegin = @dateAndTime;
	SET @dateAndTimeEnd = DATEADD(MINUTE, @runningTime, @dateAndTimeBegin);
	IF (NOT EXISTS (SELECT * FROM tblShowtimes show INNER JOIN tblMovies mov ON show.MovieId = mov.Id WHERE @dateAndTimeBegin BETWEEN show.DateAndTime AND DATEADD(MINUTE, mov.RunningTime, DateAndTime) AND mov.Deleted = 0 AND show.Deleted = 0)) AND
	(NOT EXISTS (SELECT * FROM tblShowtimes show INNER JOIN tblMovies mov ON show.MovieId = mov.Id WHERE @dateAndTimeEnd BETWEEN show.DateAndTime AND DATEADD(MINUTE, mov.RunningTime, DateAndTime) AND mov.Deleted = 0 AND show.Deleted = 0))
	BEGIN
		INSERT INTO tblShowtimes(DateAndTime, MovieId, Price, Deleted) VALUES (@dateAndTime, @movieId, @price, 0);
		SET @result = 0;
		RETURN;
	END
	SET @result = 1;
END
GO

CREATE PROCEDURE spDeleteShowtime
	@id INT,
	@result INT OUTPUT
AS
BEGIN
	UPDATE tblShowtimes 
	SET Deleted = 1
	WHERE Id = @id;
	SET @result = 0;
END
GO

CREATE PROCEDURE spModifyShowtime
	@id INT,
	@dateAndTime SMALLDATETIME,
	@movieId INT,
	@price NUMERIC(18, 2),
	@result INT OUTPUT
AS
BEGIN
	DECLARE @dateAndTimeBegin SMALLDATETIME;
	DECLARE @dateAndTimeEnd SMALLDATETIME;
	DECLARE @runningTime INT;
	SELECT @runningTime = RunningTime FROM tblMovies WHERE Id = @movieId; 
	SET @dateAndTimeBegin = @dateAndTime;
	SET @dateAndTimeEnd = DATEADD(MINUTE, @runningTime, @dateAndTimeBegin);
	IF (NOT EXISTS (SELECT * FROM tblShowtimes show INNER JOIN tblMovies mov ON show.MovieId = mov.Id WHERE @dateAndTimeBegin BETWEEN show.DateAndTime AND DATEADD(MINUTE, mov.RunningTime, DateAndTime) AND mov.Deleted = 0 AND show.Deleted = 0 AND show.Id <> @id)) AND
	(NOT EXISTS (SELECT * FROM tblShowtimes show INNER JOIN tblMovies mov ON show.MovieId = mov.Id WHERE @dateAndTimeEnd BETWEEN show.DateAndTime AND DATEADD(MINUTE, mov.RunningTime, DateAndTime) AND mov.Deleted = 0 AND show.Deleted = 0 AND show.Id <> @id))
	BEGIN
	UPDATE tblShowtimes 
	SET DateAndTime = @dateAndTime,
	MovieId = @movieId,
	Price = @price
	WHERE Id = @id;
	SET @result = 0;
	RETURN
	END
	SET @result = 1; 
END
GO

CREATE PROCEDURE spGetUserByLogin
	@login VARCHAR(50),
	@password VARCHAR(50)
AS
BEGIN
	SELECT * FROM tblUsers WHERE [Login] = @login AND [Password] = @password;
END
GO
USE CinemaTicketingSystemDb;

		SET IDENTITY_INSERT tblMovies ON;
		INSERT INTO tblMovies (Id,  Name, [Description], RunningTime, Deleted) VALUES
				(1, 'Kung Fu Panda 3', 'Continuing his "legendary adventures of awesomeness", Po must face two hugely epic, but different threats:  one supernatural and the other a little closer to his home.', 95, 0),
				(2, 'London Has Fallen', 'In London for the Prime Minister''s funeral, Mike Banning discovers a plot to assassinate all the attending world leaders.', 88, 0),
				(3, 'Zootropolis', 'In a city of anthropomorphic animals, a rookie bunny cop  and a cynical con artist fox must work together to uncover a conspiracy.', 108, 0),
				(4, 'Alvin and the Chipmunks: The Road Chip', 'Through a series of misunderstandings, Alvin, Simon and Theodore come to believe that Dave is going to propose to his new girlfriend  in Miami...and dump them. ', 86, 0),
				(5, 'The Divergent Series: Allegiant', 'Prior and Tobias Eaton venture into the world outside  of the fence and are taken into protective custody by a mysterious  agency known as the Bureau of Genetic Welfare.', 121, 0),
				(6, 'How To Be Single', 'New York City is full of lonely hearts seeking the  right match, and what Alice, Robin, Lucy, Meg, Tom  and David all have in common is the need to learn how  to be single in a world filled with ever-evolving definitions of love.', 93, 0),
				(7, 'Youth', 'A retired orchestra conductor is on holiday with his daughter and his film  director best friend in the Alps when he receives an invitation from Queen Elizabeth II to perform for Prince Philip''s birthday.', 124, 0);

		SET IDENTITY_INSERT tblMovies OFF;

		SET IDENTITY_INSERT tblShowtimes ON;
		INSERT INTO tblShowtimes(Id, DateAndTime, MovieId, Price, Deleted) VALUES
				(1, '03-21-2016 10:00 AM', 1, 100, 0),
				(2, '03-21-2016 12:10 PM', 2, 100, 0),
				(3, '03-21-2016 14:00 PM', 3, 80, 0),
				(4, '03-22-2016 10:00 AM', 1, 100, 0),
				(5, '03-22-2016 12:10 PM', 3, 80, 0),
				(6, '03-22-2016 14:00 PM', 5, 110, 0),
				(7, '03-23-2016 10:00 AM', 2, 100, 0),
				(8, '03-23-2016 12:10 PM', 4, 110, 0),
				(9, '03-23-2016 14:00 PM', 6, 90, 0) ,
				(10, '03-24-2016 10:00 AM', 7, 90, 0),
				(11, '03-24-2016 12:10 PM', 2, 100, 0),
				(12, '03-24-2016 14:00 PM', 5, 110, 0),
				(13, '03-25-2016 10:00 AM', 6, 90, 0),
				(14, '03-25-2016 12:10 PM', 4, 110, 0),
				(15, '03-25-2016 14:00 PM', 2, 100, 0),
				(16, '03-26-2016 10:00 AM', 3, 80, 0),
				(17, '03-26-2016 12:10 PM', 7, 90, 0),
				(18, '03-26-2016 14:00 PM', 6, 90, 0),
				(19, '03-27-2016 10:00 AM', 2, 100, 0),
				(20, '03-27-2016 12:10 PM', 5, 110, 0),
				(21, '03-27-2016 14:00 PM', 4, 110, 0);

		SET IDENTITY_INSERT tblShowtimes OFF;

		INSERT INTO tblCustomers(FirstName, LastName, CardNumber, Discount, TicketsPurchased) VALUES
		('John', 'Smith', 10, 10.0, 10);
		INSERT INTO tblCustomers(FirstName, LastName, CardNumber, Discount, TicketsPurchased) VALUES
		('Carl', 'Williams', 11, 10.0, 10);
		INSERT INTO tblCustomers(FirstName, LastName, CardNumber, Discount, TicketsPurchased) VALUES
		('Peter', 'McGregor', 12, 10.0, 10);


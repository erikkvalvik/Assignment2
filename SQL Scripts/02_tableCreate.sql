CREATE TABLE Superhero (
	Id int NOT NULL IDENTITY PRIMARY KEY,
	Name varchar(150) NOT NULL,
	Alias varchar(150),
	Origin varchar(max)
);
CREATE TABLE Assistant (
	Id int NOT NULL IDENTITY PRIMARY KEY,
	Name varchar(150) NOT NULL
);
CREATE TABLE Superpower (
	Id int NOT NULL IDENTITY PRIMARY KEY,
	Name varchar(150) NOT NULL,
	Description varchar(max)
); 
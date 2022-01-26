CREATE TABLE SuperheroPower (
	SuperheroId int NOT NULL,
	PowerId int NOT NULL,
);

ALTER TABLE SuperheroPower
ADD FOREIGN KEY (SuperheroId) REFERENCES Superhero(Id);

ALTER TABLE SuperheroPower
ADD FOREIGN KEY (PowerId) REFERENCES Superpower(Id);
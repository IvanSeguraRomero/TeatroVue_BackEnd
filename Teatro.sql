-- Crear la Base de datos de Teatro
CREATE DATABASE Teatro;

USE Teatro;

-- id autoincrement,director added table,¿genre?

CREATE TABLE Play(
	Id INT PRIMARY KEY,
	Title NVARCHAR(80),
    DescriptionPlay NVARCHAR(300),
	Synopsis NVARCHAR(400),
	Director NVARCHAR(300),
	Genre NVARCHAR(30)
);


CREATE TABLE User(
	Id INT PRIMARY KEY,
	Username NVARCHAR(30),
	Surname NVARCHAR(80),
	Passwd NVARCHAR(30),
    Direction NVARCHAR(100),
	Email NVARCHAR(100),
    Notes NVARCHAR(100),
	Tlf INT,
    Payment NVARCHAR(100)
);

CREATE TABLE Tickets(
	Id INT PRIMARY KEY,
    TicketRow INT,
    TicketColumn INT,
    Price DECIMAL(6,2),
    ScheduleTicket DATETIME
);

CREATE TABLE PlayTickets (
    PlayId INT,
    TicketId INT,
    PRIMARY KEY (PlayId, TicketId),
    FOREIGN KEY (PlayId) REFERENCES Play(Id),
    FOREIGN KEY (TicketId) REFERENCES Tickets(Id)
);

CREATE TABLE UserTickets (
    UserId INT,
    TicketId INT,
    PRIMARY KEY (UserId, TicketId),
    FOREIGN KEY (UserId) REFERENCES User(Id),
    FOREIGN KEY (TicketId) REFERENCES Tickets(Id)
);




CREATE TABLE PizzaIngredients
(
    Pizza_Id INT,
    Ingredient_Name NVARCHAR(80),
    FOREIGN KEY (Pizza_Id) REFERENCES Pizza(Id),
    FOREIGN KEY (Ingredient_Name) REFERENCES Ingredients(Name),
    PRIMARY KEY (Pizza_Id, Ingredient_Name)
);


INSERT INTO Ingredients(Name, Calories, Origin, isGlutenFree)
  VALUES ('Tomato Sauce', 29.00, 'Spain', 0),
			('Basil', 22.00,'Italy', 0),
			('Cheese', 402.00, 'France', 1),
			('Flour', 358.00, 'Italy', 1);
			
SELECT * FROM Ingredients;


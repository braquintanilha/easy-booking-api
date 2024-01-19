-- Use o banco de dados EasyBooking
USE EasyBooking;

-- Criação da tabela User
CREATE TABLE [User] (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Email NVARCHAR(255) NOT NULL,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL
);

-- Criação da tabela Hotel
CREATE TABLE Hotel (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    TotalRooms INT NOT NULL,
    AvailableRooms INT NOT NULL
);

-- Criação da tabela Booking
CREATE TABLE Booking (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CheckInDt DATETIME NOT NULL,
    CheckOutDt DATETIME NOT NULL,
    NumberOfGuests INT NOT NULL,
    TotalPrice DECIMAL(18,2) NOT NULL,
    StatusId SMALLINT NOT NULL,
    HotelId INT NOT NULL,
    UserId INT NOT NULL,
    FOREIGN KEY (HotelId) REFERENCES Hotel(Id),
    FOREIGN KEY (UserId) REFERENCES [User](Id)
);

-- Início da transação
BEGIN TRANSACTION;

-- Inserir registros na tabela User
INSERT INTO [User] ([Email], [FirstName], [LastName])
VALUES
    ('iron.man@avengers.com', 'Tony', 'Stark'),
    ('spider.man@avengers.com', 'Peter', 'Parker'),
    ('captain.america@avengers.com', 'Steve', 'Rogers'),
    ('super.man@justiceleague.com', 'Clark', 'Kent'),
    ('batman@justiceleague.com', 'Bruce', 'Wayne'),
    ('wonder.woman@justiceleague.com', 'Diana', 'Prince');

-- Inserir registros na tabela Hotel
INSERT INTO Hotel ([Name], [TotalRooms], [AvailableRooms])
VALUES
    ('Stark Tower Hotel', 200, 150),
    ('Parker Inn', 100, 75),
    ('Avengers Resort', 300, 200),
    ('Wayne Manor Hotel', 50, 25),
    ('Batcave Lodge', 20, 10),
    ('Themyscira Resort', 150, 100);

-- Inserir registros na tabela Booking
INSERT INTO Booking ([CheckInDt], [CheckOutDt], [NumberOfGuests], [TotalPrice], [StatusId], [HotelId], [UserId])
VALUES
    ('2023-10-01', '2023-10-10', 2, 500.00, 1, 1, 6),
    ('2023-11-15', '2023-11-20', 3, 800.00, 2, 2, 5),
    ('2023-12-05', '2023-12-15', 4, 1200.00, 1, 3, 4),
    ('2023-09-15', '2023-09-20', 2, 400.00, 1, 4, 3),
    ('2023-10-20', '2023-10-25', 1, 300.00, 1, 5, 2),
    ('2023-11-10', '2023-11-15', 2, 600.00, 1, 6, 1);

-- Commit da transação
COMMIT;

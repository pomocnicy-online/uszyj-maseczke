CREATE DATABASE UszyjMaseczke;

USE UszyjMaseczke;

CREATE TABLE MedicalCentres(
	Id int NOT NULL PRIMARY KEY IDENTITY ,
	LegalName varchar(255) NOT NULL,
	City varchar(100) NOT NULL,
	Street varchar(100) NOT NULL,
	BuildingNumber varchar(10) NULL,
	ApartmentNumber varchar(10) NULL,
	Email varchar(100) NOT NULL,
	PhoneNumber varchar(20) NOT NULL)

CREATE TABLE Requests(
	Id int NOT NULL PRIMARY KEY IDENTITY,
	MedicalCentreId int NULL)


ALTER TABLE Requests
ADD CONSTRAINT FK_MedicalCentres
FOREIGN KEY (MedicalCentreId) REFERENCES MedicalCentres(Id);



CREATE TABLE GroceryRequests(
	Id INT NOT NULL PRIMARY KEY IDENTITY ,
	GroceryType INT NOT NULL,
	Quantity INT NOT NULL,
	RequestId INT NULL)

ALTER TABLE GroceryRequests
ADD CONSTRAINT FK_Request
FOREIGN KEY (RequestId) REFERENCES Requests(Id);


GO
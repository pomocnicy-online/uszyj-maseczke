CREATE DATABASE UszyjMaseczke;

USE UszyjMaseczke;

CREATE TABLE MedicalCentres(
	Id int NOT NULL PRIMARY KEY IDENTITY ,
	LegalName nvarchar(255) NOT NULL,
	City nvarchar(100) NOT NULL,
	Street nvarchar(100) NOT NULL,
	BuildingNumber nvarchar(10) NULL,
	ApartmentNumber nvarchar(10) NULL,
	Email nvarchar(100) NOT NULL,
	PhoneNumber nvarchar(20) NOT NULL)

CREATE TABLE Requests(
	Id int NOT NULL PRIMARY KEY IDENTITY,
	MedicalCentreId int NULL
	)

CREATE TABLE MaskRequests(
	Id int NOT NULL PRIMARY KEY IDENTITY,
	MaskType int NOT NULL,
	Quantity int NOT NULL,
	Description nvarchar(255),
	RequestId int NULL)

CREATE TABLE GloveRequests(
	Id int NOT NULL PRIMARY KEY IDENTITY,
	GloveType int NOT NULL,
	Quantity int NOT NULL,
	Description nvarchar(255),
	RequestId int NULL)


ALTER TABLE Requests
ADD CONSTRAINT FK_Requests_MedicalCentres
FOREIGN KEY (MedicalCentreId) REFERENCES MedicalCentres(Id);

ALTER TABLE MaskRequests
ADD CONSTRAINT FK_MaskRequests_Request
FOREIGN KEY (RequestId) REFERENCES Requests(Id);

ALTER TABLE GloveRequests
ADD CONSTRAINT FK_GloveRequests_Request
FOREIGN KEY (RequestId) REFERENCES Requests(Id);

GO
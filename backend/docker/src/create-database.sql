CREATE DATABASE Claranet
GO

USE Claranet
GO

CREATE TABLE dbo.NewsLetter(
	Id int IDENTITY,
	Email varchar(255) NOT NULL,
	HeardAboutUs int NOT NULL,
    ReasonForSigningUp varchar(255) NULL,
	CONSTRAINT PK_Id PRIMARY KEY (Id),
	CONSTRAINT AK_Email UNIQUE(Email)
)
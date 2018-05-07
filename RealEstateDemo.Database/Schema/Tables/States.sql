CREATE TABLE [dbo].[States]
(
	[StateId] INT NOT NULL PRIMARY KEY, 
    [CountryId] INT NOT NULL, 
    [Name] VARCHAR(50) NOT NULL, 
    [Abbreviation] NVARCHAR(10) NOT NULL, 
    CONSTRAINT [FK_States_Countries] FOREIGN KEY ([CountryId]) REFERENCES [Countries]([CountryId])
)

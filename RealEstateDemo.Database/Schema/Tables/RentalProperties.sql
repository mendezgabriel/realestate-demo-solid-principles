CREATE TABLE [dbo].[RentalProperties]
(
	[PropertyId] INT NOT NULL PRIMARY KEY, 
    [Bond] DECIMAL(18, 2) NOT NULL, 
    [AvailabilityDate] DATE NOT NULL, 
    CONSTRAINT [FK_RentalProperties_Properties] FOREIGN KEY ([PropertyId]) REFERENCES [Properties]([PropertyId])
)

CREATE TABLE [dbo].[Addresses]
(
	[AddressId] INT NOT NULL PRIMARY KEY, 
    [SuburbId] INT NOT NULL, 
    [StreetAddress] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT [FK_Addresses_Suburbs] FOREIGN KEY ([SuburbId]) REFERENCES [Suburbs]([SuburbId])
)

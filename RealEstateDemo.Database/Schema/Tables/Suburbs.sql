CREATE TABLE [dbo].[Suburbs]
(
	[SuburbId] INT NOT NULL PRIMARY KEY, 
    [CityId] INT NOT NULL, 
    [PostCode] NVARCHAR(20) NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Suburbs_Cities] FOREIGN KEY ([CityId]) REFERENCES [Cities]([CityId]) 
)

GO

CREATE UNIQUE INDEX [IX_Suburbs_UniqueSuburb] ON [dbo].[Suburbs] ([CityId], [PostCode], [Name])

GO

CREATE INDEX [IX_Suburbs_PostCode] ON [dbo].[Suburbs] ([PostCode])

GO

CREATE INDEX [IX_Suburbs_Name] ON [dbo].[Suburbs] ([Name])

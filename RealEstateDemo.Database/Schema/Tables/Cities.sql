CREATE TABLE [dbo].[Cities]
(
	[CityId] INT NOT NULL PRIMARY KEY, 
    [StateId] INT NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Cities_States] FOREIGN KEY ([StateId]) REFERENCES [States]([StateId])
)

CREATE TABLE [dbo].[SellableProperties]
(
	[PropertyId] INT NOT NULL PRIMARY KEY, 
    [AuctionDate] DATETIME NULL, 
    CONSTRAINT [FK_SellableProperties_Properties] FOREIGN KEY ([PropertyId]) REFERENCES [Properties]([PropertyId])
)

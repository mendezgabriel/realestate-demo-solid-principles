CREATE TABLE [dbo].[PropertyPhotos]
(
	[PhotoId] INT NOT NULL PRIMARY KEY, 
	[PropertyId] INT NOT NULL,
    [Url] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT [FK_PropertyPhotos_Property] FOREIGN KEY ([PropertyId]) REFERENCES [Properties]([PropertyId])
)


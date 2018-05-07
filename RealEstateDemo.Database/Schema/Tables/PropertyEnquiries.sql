CREATE TABLE [dbo].[PropertyEnquiries]
(
	[EnquiryId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PropertyId] INT NOT NULL, 
    [ContactEmail] NVARCHAR(200) NOT NULL, 
    [Body] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT [FK_PropertyEnquiries_Properties] FOREIGN KEY ([PropertyId]) REFERENCES [Properties]([PropertyId])
)

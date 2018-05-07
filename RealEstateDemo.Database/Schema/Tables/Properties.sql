CREATE TABLE [dbo].[Properties]
(
	[PropertyId] INT NOT NULL PRIMARY KEY, 
    [AddressId] INT NOT NULL, 
    [AgentId] INT NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [Price] DECIMAL(18, 2) NOT NULL, 
    CONSTRAINT [FK_Properties_Addresses] FOREIGN KEY ([AddressId]) REFERENCES [Addresses]([AddressId]), 
    CONSTRAINT [FK_Properties_Agents] FOREIGN KEY ([AgentId]) REFERENCES [Agents]([AgentId])
)

CREATE TABLE [dbo].[Agents]
(
	[AgentId] INT NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(150) NOT NULL, 
    [Phone] NVARCHAR(50) NOT NULL
)

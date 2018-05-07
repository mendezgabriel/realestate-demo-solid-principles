CREATE VIEW [dbo].[ViewLocationsInformation]
	AS 

	SELECT TOP 100 PERCENT	Countries.CountryId, Countries.Name AS Country, States.StateId, States.Name AS State,
							States.Abbreviation AS StateAbbreviation, Cities.CityId, Cities.Name AS City, Suburbs.SuburbId,
							Suburbs.PostCode, Suburbs.Name AS Suburb

	FROM					States INNER JOIN
							Countries ON States.CountryId = Countries.CountryId INNER JOIN
							Cities ON States.StateId = Cities.StateId INNER JOIN
							Suburbs ON Cities.CityId = Suburbs.CityId

	ORDER BY Country, State, City, Suburb, Suburbs.PostCode

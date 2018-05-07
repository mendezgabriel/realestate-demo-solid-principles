CREATE VIEW [dbo].[ViewPropertiesInformation]
	AS 

SELECT				Properties.PropertyId, 
					CASE WHEN EXISTS
                             (SELECT	PropertyId
                               FROM		RentalProperties RP
                               WHERE	RP.PropertyId = Properties.PropertyId) 
					THEN 'Rent' 
					WHEN EXISTS
                             (SELECT	PropertyId
                               FROM		SellableProperties SP
                               WHERE	SP.PropertyId = Properties.PropertyId) 
					THEN 'Sale' 
					ELSE 'Unknown' END AS Type,
					Properties.Description, Properties.Price, SellableProperties.AuctionDate, RentalProperties.Bond,
					RentalProperties.AvailabilityDate, Agents.AgentId, Agents.FirstName AS AgentFirstName,
					Agents.LastName AS AgentLastName, Agents.Email AS AgentEmail, Agents.Phone AS AgentPhone, 
					VLI.CountryId, VLI.Country, VLI.StateId, VLI.State, VLI.StateAbbreviation, VLI.CityId, VLI.City,
					VLI.SuburbId, VLI.PostCode, VLI.Suburb, Addresses.AddressId, Addresses.StreetAddress

FROM				Properties	INNER JOIN
					Agents ON Properties.AgentId = Agents.AgentId INNER JOIN
					Addresses ON Properties.AddressId = Addresses.AddressId INNER JOIN
					ViewLocationsInformation AS VLI ON Addresses.SuburbId = VLI.SuburbId LEFT OUTER JOIN
					SellableProperties ON Properties.PropertyId = SellableProperties.PropertyId LEFT OUTER JOIN
					RentalProperties ON Properties.PropertyId = RentalProperties.PropertyId
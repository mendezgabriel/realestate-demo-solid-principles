/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

MERGE [Countries] AS Target
	USING
	(
		VALUES
		(1, 'Australia')
	)
	AS Source ([CountryId], [Name])
	ON Target.[CountryId] = Source.[CountryId]
WHEN NOT MATCHED BY Target THEN
	INSERT ([CountryId], [Name])
	VALUES ([CountryId], [Name]);

--------------------------------------------------------------------------------------

	MERGE [States] AS Target
	USING
	(
		VALUES
		(1, 1, 'Australian Capital Territory', 'ACT'),
		(2, 1, 'New South Wales', 'NSW'),
		(3, 1, 'Northern Territory', 'NT'),
		(4, 1, 'South Australia', 'SA'),
		(5, 1, 'Tasmania', 'TAS'),
		(6, 1, 'Victoria', 'VIC'),
		(7, 1, 'Western Australia', 'WA')
	)
	AS Source ([StateId], [CountryId], [Name], [Abbreviation])
	ON Target.[StateId] = Source.[StateId]
WHEN NOT MATCHED BY Target THEN
	INSERT ([StateId], [CountryId], [Name], [Abbreviation])
	VALUES ([StateId], [CountryId], [Name], [Abbreviation]);

--------------------------------------------------------------------------------------

	MERGE [Cities] AS Target
	USING
	(
		VALUES
		(1, 6, 'Melbourne'),
		(2, 6, 'Bendigo')
	)
	AS Source ([CityId], [StateId], [Name])
	ON Target.[CityId] = Source.[CityId]
WHEN NOT MATCHED BY Target THEN
	INSERT ([CityId], [StateId], [Name])
	VALUES ([CityId], [StateId], [Name]);

--------------------------------------------------------------------------------------

	MERGE [Suburbs] AS Target
	USING
	(
		VALUES
		(1, 1, '3000', 'Melbourne'),
		(2, 1, '3006', 'Southbank'),
		(3, 1, '3008', 'Docklands'),
		(4, 2, '3550', 'Bendigo'),
		(5, 2, '3551', 'Epsom'),
		(6, 2, '3555', 'Kangaroo Flat')
	)
	AS Source ([SuburbId], [CityId], [PostCode], [Name])
	ON Target.[SuburbId] = Source.[SuburbId]
WHEN NOT MATCHED BY Target THEN
	INSERT ([SuburbId], [CityId], [PostCode], [Name])
	VALUES ([SuburbId], [CityId], [PostCode], [Name]);

--------------------------------------------------------------------------------------

	MERGE [Addresses] AS Target
	USING
	(
		VALUES
		(1, 1, '268 Flinders Street'),
		(2, 2, '7 Riverside Quay'),
		(3, 3, '390 Docklands Drive'),
		(4, 4, '259 Hargreaves Street'),
		(5, 5, '146 Midland Hwy'),
		(6, 6, '267 High Street')
	)
	AS Source ([AddressId], [SuburbId], [StreetAddress])
	ON Target.[AddressId] = Source.[AddressId]
WHEN NOT MATCHED BY Target THEN
	INSERT ([AddressId], [SuburbId], [StreetAddress])
	VALUES ([AddressId], [SuburbId], [StreetAddress]);

--------------------------------------------------------------------------------------

	MERGE [Agents] AS Target
	USING
	(
		VALUES
		(1, 'Julia', 'Roberts', 'julia.roberts@fakedomain.com.au', '(03)544XXYY'),
		(2, 'Angelina', 'Jolie', 'angelina.jolie@fakedomain.com.au', '(03)540XXYY'),
		(3, 'Jack', 'Nicholson', 'jack.nicholson@fakedomain.com.au', '041544XXYY')
	)
	AS Source ([AgentId], [FirstName], [LastName], [Email], [Phone])
	ON Target.[AgentId] = Source.[AgentId]
WHEN NOT MATCHED BY Target THEN
	INSERT ([AgentId], [FirstName], [LastName], [Email], [Phone])
	VALUES ([AgentId], [FirstName], [LastName], [Email], [Phone]);

--------------------------------------------------------------------------------------

	MERGE [Properties] AS Target
	USING
	(
		VALUES
		(1, 1, 1, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec ac magna placerat odio pellentesque laoreet. Nullam rhoncus quam ut odio viverra pharetra. Suspendisse ut turpis consequat, sagittis ipsum et, feugiat sapien. Integer adipiscing elementum dui, feugiat viverra orci venenatis ut. Maecenas quis vestibulum ligula. Donec sit amet elit dolor. Aenean porttitor pulvinar metus in imperdiet. Interdum et malesuada fames ac ante ipsum primis in faucibus. Aliquam porta, diam eget pretium gravida, purus massa vestibulum odio, eget tincidunt orci eros ut elit. Praesent nunc eros, fermentum in nibh id, porttitor dictum leo.', 500),
		(2, 2, 1, 'Sed eget urna semper, gravida mauris id, mattis mauris. Sed porttitor mi sit amet elit suscipit aliquam. Proin elementum ornare pulvinar. Suspendisse porttitor nisi nisl, sed tempor augue accumsan eget. Nullam posuere, lectus eu posuere dignissim, lectus justo ultrices dui, at dictum eros ligula sit amet magna. Donec in pulvinar lectus. Pellentesque bibendum elementum sapien et condimentum.', 2000000),
		(3, 3, 2, 'Suspendisse eu pharetra ante. Aliquam sollicitudin et lectus in molestie. Duis sodales dui at felis feugiat, ac egestas arcu convallis. Aenean vel scelerisque odio. Donec at massa purus. Integer vitae lacinia dui, non faucibus augue. Maecenas et ipsum sed augue scelerisque euismod eu posuere nulla.', 750),
		(4, 4, 2, 'Vestibulum id metus convallis, ornare nisi ut, tincidunt odio. Phasellus mauris quam, iaculis ultricies nibh ac, adipiscing tristique sem. In interdum lacus id enim volutpat, sed tincidunt quam mattis. Sed ac turpis quis nulla vehicula ultrices. Phasellus nec mattis dolor. Aenean vitae convallis nisi, quis vulputate sapien. Quisque eu nibh vitae lectus faucibus placerat vitae ut mauris. Sed est eros, adipiscing vel ligula vitae, convallis vulputate tortor. Sed vitae interdum augue. Duis condimentum tellus et erat laoreet, non viverra odio laoreet. Cras ut adipiscing nibh. Proin odio diam, commodo sed mollis vel, fringilla eget nisl.', 400000),
		(5, 5, 3, 'Nulla eget neque quis eros blandit semper eu vitae urna. Cras eu sagittis odio. Vestibulum molestie ac nisl id feugiat. Nulla sed leo egestas, tincidunt nisl sed, lacinia sem. Ut diam elit, lacinia vel odio eu, tincidunt malesuada nisi. Quisque volutpat lacus ac dui blandit ornare. Proin laoreet aliquet mi. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Integer consectetur, urna vel gravida auctor, quam nulla bibendum risus, quis lacinia libero ipsum fringilla nisi. Cras suscipit quam aliquet velit imperdiet, quis pellentesque velit fringilla. Proin ut elit et quam dapibus laoreet eget a urna. Vivamus dapibus vel nibh nec imperdiet. Sed ac iaculis libero, ac molestie quam. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed pellentesque dui id nulla porta, ut dictum risus congue. Nulla nibh elit, semper sit amet tempor iaculis, pretium non erat.', 300),
		(6, 6, 3, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut suscipit, tortor eget sodales tincidunt, justo lorem semper magna, sit amet luctus metus metus eget elit. Nunc et tortor libero. Quisque sit amet erat neque. Aliquam ullamcorper tincidunt velit, eu facilisis nibh vehicula sit amet. Vestibulum eget justo quis leo hendrerit pellentesque id porttitor tortor. Sed nec lorem scelerisque, porta tortor sed, sagittis lorem. Morbi condimentum quam a mattis semper. Aliquam placerat sem id lacus pulvinar aliquam. Duis congue consectetur mi, id bibendum neque sollicitudin eu. Quisque magna dui, pulvinar ac nisl et, tempus rutrum lorem. Duis ac blandit dolor, at placerat diam. Quisque suscipit dui augue, fermentum porttitor nunc facilisis in.', 385000)
	)
	AS Source ([PropertyId], [AddressId], [AgentId], [Description], [Price])
	ON Target.[PropertyId] = Source.[PropertyId]
WHEN NOT MATCHED BY Target THEN
	INSERT ([PropertyId], [AddressId], [AgentId], [Description], [Price])
	VALUES ([PropertyId], [AddressId], [AgentId], [Description], [Price]);

--------------------------------------------------------------------------------------

	MERGE [RentalProperties] AS Target
	USING
	(
		VALUES
		(1, 2000, '2014-07-01'),
		(3, 3000, '2014-06-30'),
		(5, 1260, '2014-08-16')
	)
	AS Source ([PropertyId], [Bond], [AvailabilityDate])
	ON Target.[PropertyId] = Source.[PropertyId]
WHEN NOT MATCHED BY Target THEN
	INSERT ([PropertyId], [Bond], [AvailabilityDate])
	VALUES ([PropertyId], [Bond], [AvailabilityDate]);

--------------------------------------------------------------------------------------

	MERGE [SellableProperties] AS Target
	USING
	(
		VALUES
		(2, '2014-08-03 09:30:00'),
		(4, NULL),
		(6, '2014-07-23 14:20:00')
	)
	AS Source ([PropertyId], [AuctionDate])
	ON Target.[PropertyId] = Source.[PropertyId]
WHEN NOT MATCHED BY Target THEN
	INSERT ([PropertyId], [AuctionDate])
	VALUES ([PropertyId], [AuctionDate]);

--------------------------------------------------------------------------------------

	MERGE [PropertyPhotos] AS Target
	USING
	(
		VALUES
		(1, 1, '/Content/images/properties/image2.jpg'),
		(2, 1, '/Content/images/properties/image5.jpg'),
		(3, 1, '/Content/images/properties/main.jpg'),
		(4, 2, '/Content/images/properties/main (1).jpg'),
		(5, 2, '/Content/images/properties/main (2).jpg'),
		(6, 2, '/Content/images/properties/image5 (1).jpg'),
		(7, 3, '/Content/images/properties/image8.jpg'),
		(8, 3, '/Content/images/properties/main (3).jpg'),
		(9, 4, '/Content/images/properties/image5 (2).jpg'),
		(10, 4, '/Content/images/properties/image4.jpg'),
		(11, 4, '/Content/images/properties/main (4).jpg'),
		(12, 5, '/Content/images/properties/image3.jpg'),
		(13, 5, '/Content/images/properties/image5 (3).jpg'),
		(14, 5, '/Content/images/properties/image8 (1).jpg'),
		(15, 6, '/Content/images/properties/image7.jpg'),
		(16, 6, '/Content/images/properties/image3 (1).jpg'),
		(17, 6, '/Content/images/properties/image5 (4).jpg'),
		(18, 6, '/Content/images/properties/main (5).jpg')
	)
	AS Source ([PhotoId], [PropertyId], [Url])
	ON Target.[PhotoId] = Source.[PhotoId]
WHEN NOT MATCHED BY Target THEN
	INSERT ([PhotoId], [PropertyId], [Url])
	VALUES ([PhotoId], [PropertyId], [Url]);

--------------------------------------------------------------------------------------
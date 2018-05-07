CREATE LOGIN [RealEstateDemo] WITH PASSWORD = 'R3@l3st@t3!', CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO

-- Add User to database
CREATE USER RealEstateDemo FOR LOGIN RealEstateDemo;
GO
EXEC sp_addrolemember 'db_owner', 'RealEstateDemo'
GO
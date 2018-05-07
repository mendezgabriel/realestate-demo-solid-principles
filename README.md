# realestate-demo-solid-principles
A real estate demo project with ASP.Net MVC following SOLID principles.

Notes:

This application was developed in Oct 2014 using VS2013 by Gabriel Mendez (Github user mendezgabriel) as a web application using MVC4 to demonstrate how
the data repositories can be easily switched from one implementation to another through the use of interfaces following the best practice
architecture pattern known as the "Onion Architecture" http://jeffreypalermo.com/blog/the-onion-architecture-part-1/

- It uses dependency injection to resolve all dependencies.

- It uses SQL server for the for the data store. The schema was generated using SQL Data Tools integration with VS. http://msdn.microsoft.com/en-au/data/tools.aspx
A full backup of the database can be found in the DbBackup folder of this solution in case it is needed to run the application.
The database should compatible with SQL 2014 and previous. However, there are many ways and ORMs available to get the data from a data store.
This project demonstrates just that and in order to switch from one ORM implementation to another, comment and uncomment the appropriate ORM interface
registration line found on the RegisterDataAccess method of RealEstateDemo.DependencyResolution.CompositionRoot class. Currently you can switch
between NPoco and EntityFramework.

- It makes use of regular MVC controllers to render views but also uses Ajax requests. By doing this the application becomes more responsive
to the user.

- The UI uses Bootstrap in order to make the application responsive (usable in any modern device with a web browser).

Because of scope limitations for this demo, only a sample test class was included for the common project. However, a proposed
VS project solution structure is provided for reference. Also, in a real world scenario improvements should be made to this implementation
like data validation, caching, error handling and OO client side code by using a combination of typescript and MVVM javascript frameworks such
as Angular, React, Vue or Knockout.

Requirements:
- This application requires an SQL Server LocalDB instance installed in the local development machine in order to run
successfully. It uses the default instance name of "(localdb)\MSSQLLocalDB"
- In order to Run the application from a development machine, download the source code, use VS to build it, publish
the database project RealEstateDemo.Database to the localdb instance of SQL Server and then start the project in VS
by setting up the RealEstateDemo.WebUI as the default start up project and press CTRL+F5 (or F5 if you want to debug).

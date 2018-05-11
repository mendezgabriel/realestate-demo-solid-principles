# realestate-demo-solid-principles

## Description:
A real estate demo project with ASP.Net MVC following SOLID principles.

An application developed on Oct 2014 using VS2013 by Gabriel Mendez (Github user mendezgabriel) as a web application using ASP.Net MVC4 as the UI to demonstrate how the data repositories can be easily switched from one implementation to another through the use of decoupling interfaces following the best practices architecture pattern known as the "Onion Architecture" http://jeffreypalermo.com/blog/the-onion-architecture-part-1/

## Overview:
Because there are many ways to store data (SQL, Oracle, MySQL, NoSQL, External Services or APIs, etc) and there are also many ORMs available to get the data from a particular data store, and on top of that technology keeps constantly changing more frequently than we can adapt to it, it is often found that enterprise applications have the challenge to always use the best or more efficient data store retrieval method available but if you didn't follow the best practices and didn't use DI, you will find that changing the way a system stores/access data could be a complete nightmare and this task would eventually be discarded by management or product owners, leaving the system fall behind its competitors and often letting it die completely at some point.

This project demonstrates just how to solve that problem by switching from one ORM implementation to another, letting you replace how the system access/store its data meaning that you could even replace the data store completely (from SQL to Oracle for example) without impacting the core functionality of the application. The benefit is that you only need to write and test this new component only (and of course do some sanity checking and UAT but you get the point) by making the task so much easier to handle leaving you in a good position when seeking approval/request from the managers to go ahead. The same principle can be applied to replace any external dependency to the system, which in turn will make your enterprise grade application more maintainable, testable, scalable extensible and decoupled over time.

## Details:
- It uses dependency injection to resolve all dependencies.

- It uses SQL server the for the data store. The schema was generated using SQL Data Tools integration with VS. http://msdn.microsoft.com/en-au/data/tools.aspx
A full backup of the database can be found in the DbBackup folder of this solution in case it is needed to run the application.
The database should compatible with SQL 2014 and previous. 

- In order to switch from one ORM implementation to another, just comment and uncomment the appropriate ORM interface registration line found on the `RegisterDataAccess` method of `RealEstateDemo.DependencyResolution.CompositionRoot` class. Currently you can switch between NPoco and EntityFramework wich are both communicating with the SQL Server Database.

- It makes use of regular MVC controllers to render views but also uses Ajax requests. By doing this the application becomes more responsive to the user.

- The UI uses Bootstrap in order to make the application responsive (usable in any modern device with a web browser).

## Limitations:
Because of scope limitations for this demo, only a sample test class was included for the common project. However, a proposed
VS project solution structure is provided for reference. Also, in a real world scenario improvements should be made to this implementation like data validation, caching, error handling and OO client side code by using a combination of typescript and MVVM javascript frameworks such as Angular, React, Vue or Knockout.

## Requirements:
- VS 2013 or newer for debugging.
- This application requires an SQL Server LocalDB instance installed in the local development machine in order to run
successfully. It uses the default instance name of `(localdb)\MSSQLLocalDB`
- In order to Run the application from a development machine, download the source code, use VS to build it, publish
the database project `RealEstateDemo.Database` to the localdb instance of SQL Server and then start the project in VS
by setting up the `RealEstateDemo.WebUI` as the default start up project and press CTRL+F5 (or F5 if you want to debug).

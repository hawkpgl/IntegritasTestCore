What do you need to do to work locally:

Package folder is not there!!! Enable NuGet Package Restore and build the solution.

SPA Project -> on App/Services, change the 'urlBase' on all services to your REST Project base url.
	       
RESTCore Project -> on Startup.cs, change the connection string or leave it to the default online database.

Made with:

DDD (Domain Driven Design);

Single Page Application (AngularJS + Bootstrap); 
View models validation with Data Annotations; 

Enitity Framework Core: Fluent API Mapping;

Generic Repository Pattern; 
Unity of Work Pattern; 

.NET COre Side -By-Side Execution
- The Build FOlder for Each Target .NET Core Framework for Easy Distrubution

- Microsoft.NETCore.App
	- This is the .NET Core Framework that has all Dependencies assembled in it as miniature framework for distribution

- Single  FIle Publish
	- Enjoy Experience like XCopy Deployment as like .NET Frwk
	- 	<RuntimeIdentifier></RuntimeIdentifier>
		- The Target platforms where the app is to be executed
			- win-86 / win-x664
			- linux-86 / linux-64
	-  <PublishTrimmed>true</PublishTrimmed>
		- Use only referred assemblies in build and created a compressed publused .exe file with .NET COre mandatory references


# Using DATA ACCESS with  EF Core
	- Microsoft.EntityFrameworCore,  the base package, SQL, MySQL, Postgres, Sqlite, CosmosDB 
	- Microsoft.EntityFrameworCore.SqlServer
	- Microsoft.EntityFrameworCore.Relational
	- Microsoft.EntityFrameworCore.Design Required For Migrations
	- Microsoft.EntityFrameworCore.Tools Required For Migrations
# Object Model	
	- DbContext
		- DbSet<T>
			- Default Support for Task Based Transactions
				- Connection Resiliency
	- Flexible Object Mapping
		- Private Properties of Entity Classes are mapped with tables uisng their public wrappers
		- Support For Stored Procs using Managed Functions
		- Default DI Support provided in ASP.NET Core Apps
		- Compile Queries
		- DbContext Pooling in ASP.NET Core
		- Support for Fluent APIs is by Default
# ASP.NET Core 3.1 Eco-System
	- Microsoft.AspNetCore.App
		- Container for
			- Identity
			- Request Processing
				- Middlewares
				- The RequestDelegate in HttpContext for Delegating the Request objects
					- e.g. Securty, Sessions, CORS, Static Files, etc.

			- Hosting
				- Sessions
				- Builder Class Opimization
				- ASP.NET COre uses the Builder Design Pattern
				- Reverse Proxy Management using ASP.NET Core on the top of dotnet.exe
					- Integration with
						- IIS
						- Apache
						- NGinx
			- Depednency Injection
				- Extension Framework for Managing lifecycle of Dependant Objects	
			- Views
				- Razor Imprvements
					- TagHelpers
						- Native Coiled HTML elements with Server-Side Metadata
					- ViewInjection
						- @Inject Directive
			- Controllers
				- IActionResult is a Common Contract
				- Controller as an Abstract base class for MVC Controllers
				- ControllerBase class
					- Abstract base class for MVC Controller and API Controller
				- Removal of Action Filters
					- Authentication and Authorization
				- Server Objects are avaiable through Providers
					- Session Provider using Extension
					- TempData Provider with Extension
			- API
				- ControllerBase as an abstract base class
				- HTTP Linking Method (similar with API on .NET Frwk)
				- Mandatoty HTTP Method Attributes
				- Improvements in Parameter Binders
				- APIController is an Attr9bute instead of Base class

# ASP.NET Core Programming
1. Addong a Models folder for Entity Classes
	- Generating Migration
		- dotnet ef migrations add firstMigration -c Core_WebApp.Models.SyncAppDbContext
	- Generayting Database
		- dotnet ef database update
	- Database FIrst
		- dotnet ef dbContext scaffold <Connection-String> Microsoft.EntityFrameworkCore.SqlServer -o Models	
	- How to Manage the Model Changes?
2. How to Pass data to API using
	- QueryString
	- Route
	- Form
	- Body
3. How to Manage Exceptions?
4. How to Secure The REST APIS?
5. How to Deploy API?






 


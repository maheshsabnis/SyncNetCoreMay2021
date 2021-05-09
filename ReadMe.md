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
		- dotnet ef dbcontext scaffold "Data Source=.;Initial Catalog=Company;Integrated Security=SSPI;MultipleActiveResultSets=true" Microsoft.EntityFrameworkCore.SqlServer -o Models
	- How to Manage the Model Changes?
		- If COde First approach is used then for Any Modifications 
			on Model classes w.r.t. Adding Property or Modifiyng existing property, generate new migration and 
			update database
			- If the new Validations are to be added on the Model Property perform one of the following operations
				- Create a separate Validator and Apply it as annotation on Model class
					- This is possible if the Model class source code is accessible 
				- Write an explicit Validation in the Action Method (Recommended in most of the cases) 
					- Process based Validation by using an Exception Handler
			- If the Process based Valdiations are to be implemented the use one of the following
				- IMplement the Action Filter for Exception Management
				- IMplement the Custom Middleware for Handling Exceptions

2. How to Pass data to API using
	- QueryString
		- http://localhost:5001/api/CategoryAPI?CategoryId=Cat003&CategoryName=Food&BasePrice=780
		- Using [FromQuery]
			- Read the UTL QueryString and using the Reflector map the parameters with CLR object Properties 
				- Reflector will use PropertyName and DataType
	- Route
		- http://localhost:5001/api/CategoryAPI/Cat003/Food/780
	- Form
	- Body
		- FromBody
3. How to Manage Exceptions?
	- Using Middlewares
	- The Custom Middleware Class must be Ctor injected with RequestDelegate delegate
		- RequestDelegate, a delegate that accepts the HttpContext as input parameter
		- The class must contain the Invoke / InvokeAsync(HttpCotext) method, this method contains logic for
			the Custom Middleware
		- Create another class that will be used to register the Custom Middleware class in 
			HTTP Request Context Pipeline using IAppicationBuilder interface
				- This class with contains an Extension method
4. Accessibility of The API from the CLient Application
	- CORS Policy COnfiguration
		- Use the AddCors() service method in COnfigureServices() method and define policies for
			- AllowAnyHeader
			- AllowAnyMethod
			- AllowAnyOrigin
			- WithHeaders(Array of Headers)
			- WithMethods(Array of Http Methods)
			- WithOrigins(Array of Origins)	
		-COnfigure the CORS Middleware and use then Policy defied in Service
			- app.USeCors(Policy NAme)
	- Exposing the Swagger EndPoints
		- Swashbuckle.AspNetCore.SwaggerUI install the Middleware for Exposing Swagger Endpoints

5. How to Secure The REST APIS?
6. How to Deploy API?






# Hands-On

# Date 08-05-2021
- Create ProductSrevice for CRUD Operations and Product API
- Create a API that will return App Products by category Name
- Create a API that will accept Category Adn Products Records in a Single POST request and add in Database

# Date 09-05-2021

- Create a custom Middleware that will log the following information in Database
	- Which Controller and Action Method is Invoked
	- Log the Exception caused in Action Method
	- Date and Time of the Request that has crashed
- Experience the FromForm, FromQuery and FromRoute for Various ways of Posting Data to APIn Post methods



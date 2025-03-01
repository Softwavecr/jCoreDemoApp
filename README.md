# jCoreDemoApp by Jairo Guerrero 2021

**Sample WebApi/Angular application demonstrating ASP.NET Core API features**

This is a sample **ASP.NET Core application** that *demonstrates* basic features of `ASP.NET` Core in an API backend application with an Angular frontend. The application allows browsing and editing of a list of CONTACTS and TODOS. 

This Solution follows the Clean Architecture.

More instructions at https://www.softwavecr.com/posts/creating-web-application-on-net-core-webapi/


### ASP.NET Core Features
The **ASP.NET Core** Backend demonstrates:

* Creating an API backend service
* Isolating business logic and Controller code
* Using a base Repository for business logic
* Separating code into separate projects
* Custom User Authentication
* Using ASP.NET Core as a backend to an Angular 10 front end

Version supported:  
* **.NET 5 SDK or later**
* **Visual Studio Code / Visual Studio 2019 or later**

### Angular Features
The **Angular** front end application demonstrates:

* Page based Application
* Mobile friendly, adaptive UI
* Routing
* Managing Server Urls (dev/production)
* Angular CLI Project

Version supported:  
* **Angular 10.1.0**  
* **Angular CLI 10.1.0**


#### .NET Core API Configuration
First, you will need an environment variable named ASPNETCORE_Environment with a value of Development. On Windows, run SET ASPNETCORE_Environment=Development. On Linux or macOS, run export ASPNETCORE_Environment=Development

You should just be able to clone this repo as is on either Windows or Mac (and probably Linux) and do:

```
cd <Base Solution Folder>\src\WebUI
dotnet build
dotnet run
cd <Base Solution Folder>\src\WebUI\ClientApp
npm start
```

Then navigate to [http://localhost:5000](http://localhost:5000) to start the application. First launch requires to register a user for full functionality.

If you're running the application locally through IIS or Kestrel, the application should just work as is. By default it uses a SqLite data base that is created in the Web app's content (not Web) root. 

The sample also works with SQL Server but you have to create the database for that to work and set the connection string in `appsettings.json`. 

#### To develop the ClientApp Angular example
The Angular front end sits in a separate ClientApp project folder and is built separately from the ASP.NET Core application.

Making changes to the Angular application requires transpiling of the typescript source files. In order to make changes to the Angular 10 client sample run the following from a command window:

```
cd <Base Solution Folder>\src\WebUI\ClientApp
npm install
npm start
```

then navigate to http://localhost:4200 to run the application. Note this uses the WebPack development server rather than running through IIS Express or Kestrel for the front end assets - `index.html`, all css, images etc. are served from the development server and only API requests go through Kestrel/IIS.

Depending on which port you run the ASP.NET Core application you may have to change the API server base URL which defaults to http://localhost:5000/ in the `launchSettings.json` file. The default is when running the development server that requests are routed to http://localhost:5000/ which is where Kestrel runs by default.


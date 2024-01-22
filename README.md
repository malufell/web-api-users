## REST API for User Registration

The objective of this project was to learn the initial concepts of .NET and C#.

### Dependencies:

- Evolve: Migration tool
- Pomelo: Entity Framework Core (EF Core) provider for MySQL

### How to execute this project:

Before running this project, ensure that you have the following:
- Create a MySQL Database
- Replace Connection Details to the "appsettings.json" file


1. Clone this repository: `git clone https://github.com/malufell/web-api-users.git`
2. Navigate to the directory: `cd web-api-users`
3. Run the project: `dotnet run`
  - The creation of the 'users' table in the database will be performed through migration 
5. Access the application: `http://localhost:5122/api/User`

   
### Project Layered Architecture:

```
Request > Controller > Service > Repository > Model > Database
```

- Request:
  - Represents the system's input, coming from the client.

- Controller:
  - Receives requests, handles control logic, and interacts with the service.

- Service:
  - Contains business logic, coordinates operations, and makes calls to the repository.

- Repository:
  - Abstracts data access and provides an interface to interact with the database.

- Model:
  - Represents entities or data objects used by the application.

- Database:
  - Stores the persistent data of the application.
 
### Resources:

- GET: /api/User = to display the list of users
- GET: /api/User/:federalTaxId = to display a user
- POST: /api/User = to persist a new user
- PUT: /api/User = to edit a user
- DELETE: /api/User/:federalTaxId = to delete a user

Body example:
```
{
  "name": "User Name",
  "federalTaxId": "46748437075",
  "age": 30,
  "gender": "Female",
  "placeOfBirth": "Brazil"
}
```

The `federalTaxId` (CPF) is a unique data element, must be valid for registration, and editing is not allowed.

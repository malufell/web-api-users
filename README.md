### Dependencies:

- Evolve: Migration tool
- Pomelo: Entity Framework Core (EF Core) provider for MySQL

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

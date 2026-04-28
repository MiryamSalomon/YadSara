# YadSara

A comprehensive C# .NET 6.0 Web API project demonstrating clean architecture principles with a layered approach to application design.

## Project Overview

YadSara is built using **clean architecture** with a clear separation of concerns across multiple layers:

- **YadSara.Api** - RESTful API endpoints and Swagger/OpenAPI documentation
- **YadSara.Core** - Core business logic and domain models
- **YadSara.Service** - Service layer implementing business rules
- **YadSara.Data** - Data access layer with Entity Framework Core

## Technology Stack

- **.NET 6.0** - Latest LTS framework
- **Entity Framework Core 6.0** - ORM for database operations
- **Swagger/Swashbuckle** - API documentation and testing
- **C# 10** - Modern language features with nullable reference types

## Architecture

This project follows a **layered architecture pattern**:

```
YadSara.Api
    ↓
YadSara.Service
    ↓
YadSara.Core + YadSara.Data
```

### Layer Responsibilities

- **API Layer**: Handles HTTP requests/responses and routing
- **Service Layer**: Implements business logic and orchestration
- **Core Layer**: Contains domain models and interfaces
- **Data Layer**: Manages database access and persistence

## Getting Started

### Prerequisites

- .NET 6.0 SDK or later
- Visual Studio 2022 or Visual Studio Code
- SQL Server (or configure your preferred database)

### Installation

1. Clone the repository
```bash
git clone https://github.com/MiryamSalomon/YadSara.git
cd YadSara
```

2. Open the solution
```bash
dotnet open YadSara.sln
```

3. Restore NuGet packages
```bash
dotnet restore
```

4. Configure your database connection in `appsettings.json`

5. Run migrations
```bash
dotnet ef database update
```

6. Start the application
```bash
dotnet run --project YadSara/YadSara.Api.csproj
```

## API Documentation

Once the application is running, access the Swagger UI at:
```
http://localhost:5000/swagger/index.html
```

## Configuration

Update `appsettings.json` with your environment-specific settings:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=YadSara;Trusted_Connection=true;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information"
    }
  }
}
```

## Project Structure

```
YadSara/
├── YadSara.Api/          # API Controllers and startup
├── YadSara.Core/         # Domain models and interfaces
├── YadSara.Service/      # Business logic services
├── YadSara.Data/         # DbContext and repositories
└── YadSara.sln           # Solution file
```

## Features

- RESTful API design
- Clean architecture principles
- Entity Framework Core integration
- Swagger API documentation
- Nullable reference types enabled
- Implicit using statements

## Future Improvements

- Unit and integration testing
- Authentication and authorization
- Logging framework integration
- Caching strategies
- Performance optimization

## License

This project is open source and available under the MIT License.

## Contact

For questions or suggestions about this project, please reach out via [GitHub Issues](https://github.com/MiryamSalomon/YadSara/issues).

---

**Created with ❤️ by Miryam Salomon**
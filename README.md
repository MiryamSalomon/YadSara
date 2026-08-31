# YadSara

Web API (ASP.NET Core 6) for managing equipment lending between lenders (משאילים) and borrowers (שואלים) across cities.

## Solution structure

```
YadSara/
├── YadSara.sln
├── YadSara/            # YadSara.Api - Web API project (Controllers, Program.cs)
├── YadSara.Core/       # Entities and repository/service interfaces
├── YadSara.Data/       # EF Core DbContext, migrations, repository implementations
└── YadSara.Service/    # Service layer implementations
```

Entities: `City`, `Lender`, `Borrow`, `Equipment`, `Lending`.

## Prerequisites

- .NET 6 SDK
- SQL Server or SQL Server LocalDB
- `dotnet-ef` CLI tool: `dotnet tool install --global dotnet-ef`

## Setup

1. Set your connection string in `YadSara/YadSara/appsettings.json` under `ConnectionStrings:DefaultConnection` (defaults to LocalDB).
2. Create the database:
   ```bash
   cd YadSara/YadSara
   dotnet ef database update --project ../YadSara.Data/YadSara.Data.csproj --startup-project YadSara.Api.csproj
   ```
3. Run the API:
   ```bash
   dotnet run
   ```
4. Open Swagger UI at `http://localhost:<port>/swagger`.

## API

Each entity exposes standard REST endpoints under `/api/<Entity>` (GET, GET/{id}, POST, PUT/{id}, DELETE/{id}). `Lending` additionally exposes `GET /api/Lending/by-date/{date}` and `GET /api/Lending/by-borrower-lender?borrowId=&lenderId=`.

## License
[MIT](LICENSE)

## Contact
Miryam Salomon

<div align="center">

<img src="https://capsule-render.vercel.app/api?type=waving&color=0:667eea,50:764ba2,100:f093fb&height=240&section=header&text=🛠️%20YadSara&fontSize=72&fontColor=ffffff&animation=fadeIn&fontAlignY=40&desc=Equipment%20Lending%20%26%20Tracking%20API&descAlignY=62&descSize=22&descColor=ffffff" width="100%"/>

<br/>

[![.NET](https://img.shields.io/badge/.NET_6-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com)
[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://learn.microsoft.com/dotnet/csharp)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core_Web_API-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://learn.microsoft.com/aspnet/core)
[![EF Core](https://img.shields.io/badge/EF_Core-512BD4?style=for-the-badge&logo=nuget&logoColor=white)](https://learn.microsoft.com/ef/core)
[![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)](https://www.microsoft.com/sql-server)
[![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=swagger&logoColor=black)](https://swagger.io)
[![JavaScript](https://img.shields.io/badge/Vanilla_JS-F7DF1E?style=for-the-badge&logo=javascript&logoColor=black)](https://developer.mozilla.org/docs/Web/JavaScript)

<br/>

[![Tests](https://img.shields.io/badge/✓%209%20Tests%20Passing-22c55e?style=for-the-badge)](https://github.com/MiryamSalomon/YadSara)
[![License](https://img.shields.io/badge/License-MIT-f59e0b?style=for-the-badge)](LICENSE)

<br/>

> **A REST API + lightweight web UI for managing equipment lending between lenders (*משאילים*)  
> and borrowers (*שואלים*) across cities — with full async EF Core persistence and validated CRUD on every entity.**

</div>

---

## ✨ Features

<table>
<tr>
<td width="50%">

### 📦 Entity Management
- Five core entities: `City` · `Lender` · `Borrow` · `Equipment` · `Lending`
- Full CRUD via REST endpoints on every entity
- Data-annotation validation, enforced automatically by `[ApiController]`
- Duplicate keys → `409 Conflict` · missing records → `404 Not Found`

</td>
<td width="50%">

### 🔎 Lending Queries
- `GET /api/Lending/by-date/{date}` — lendings due on a given date
- `GET /api/Lending/by-borrower-lender` — filter by borrower + lender pair
- Tracks return status (`IsReturned`) and deadlines per loan

</td>
</tr>
<tr>
<td width="50%">

### 🗄️ Persistence
- **EF Core 6** over **SQL Server**, no more in-memory reset-on-restart storage
- Code-first migrations (`YadSara.Data/Migrations`)
- Repository + Service layered architecture, fully async end-to-end

</td>
<td width="50%">

### 🧪 Testing & Reliability
- xUnit + Moq unit tests on the service layer
- Global exception-handling middleware with structured logging
- `ILogger` instrumentation on every service mutation

</td>
</tr>
<tr>
<td width="50%">

### 🖥️ Web UI
- Single-page vanilla HTML/JS frontend, served same-origin from `wwwroot` — no build step, no CORS
- One tab per entity, each with a generated form + table wired to the REST API
- Foreign keys (`lenderId` / `borrowId`) render as clickable **names**, opening a full detail popup instead of showing raw ids
- One-click status pill to mark a lending returned, no full edit form needed

</td>
<td width="50%"></td>
</tr>
</table>

---

## 🏗️ Architecture

```
YadSara/
├── YadSara.sln
│
├── YadSara/                  # YadSara.Api — Web API host
│   ├── Controllers/          # Borrow · City · Equipment · Lender · Lending
│   ├── wwwroot/index.html    # Single-page web UI (static, served same-origin)
│   ├── Program.cs            # DI, DbContext, Swagger, static files, global exception middleware
│   └── appsettings.json      # Connection strings
│
├── YadSara.Core/             # Entities + repository/service interfaces
│   ├── Entities/
│   ├── Repositories/
│   └── Services/
│
├── YadSara.Data/             # EF Core DbContext, migrations, repository implementations
│   ├── DataContext.cs
│   ├── Migrations/
│   └── Repositories/
│
├── YadSara.Service/          # Service layer implementations (business logic + logging)
│
└── YadSara.Tests/            # xUnit + Moq unit tests
```

---

## 🚀 Getting Started

### Prerequisites

| Tool | Version |
|---|---|
| .NET SDK | 6.0+ |
| SQL Server | LocalDB or full instance |
| dotnet-ef CLI | `dotnet tool install --global dotnet-ef` |

### 1 · Configure the database

Set your connection string in `YadSara/YadSara/appsettings.json` under `ConnectionStrings:DefaultConnection` (defaults to LocalDB).

### 2 · Create the database

```bash
cd YadSara/YadSara
dotnet ef database update --project ../YadSara.Data/YadSara.Data.csproj --startup-project YadSara.Api.csproj
```

### 3 · Run the API

```bash
dotnet run
```

- Web UI at **`http://localhost:<port>/`** 🖥️
- Interactive API docs at **`http://localhost:<port>/swagger`** 📖

---

## 🧪 Running Tests

```bash
cd YadSara
dotnet test YadSara.Tests/YadSara.Tests.csproj
```

```
Passed! - Failed: 0, Passed: 9, Skipped: 0, Total: 9 ✓
```

---

## 📡 API Reference

Every entity below exposes the same REST shape under `/api/<Entity>`:

| Method | Endpoint | Description |
|---|---|---|
| `GET` | `/api/{Entity}` | List all |
| `GET` | `/api/{Entity}/{id}` | Get by id → `404` if missing |
| `POST` | `/api/{Entity}` | Create → `201` or `409` on duplicate id |
| `PUT` | `/api/{Entity}/{id}` | Update → `404` if missing |
| `DELETE` | `/api/{Entity}/{id}` | Delete → `204` or `404` if missing |

`{Entity}` = `Borrow` · `City` · `Equipment` · `Lender` · `Lending`

Additional `Lending` endpoints:

| Method | Endpoint | Description |
|---|---|---|
| `GET` | `/api/Lending/by-date/{date}` | Lendings for a given date |
| `GET` | `/api/Lending/by-borrower-lender?borrowId=&lenderId=` | Lendings for a borrower/lender pair |

---

## 📄 License

[MIT](LICENSE)

## 👤 Contact

**Miryam Salomon**
[GitHub](https://github.com/MiryamSalomon)

Three-Tier ASP.NET Core Application with CQRS

This project is a sample implementation of a Three-Tier Architecture in ASP.NET Core using CQRS with MediatR, Entity Framework Core, and SQL Server.

MyApp.sln
│
├── 📂 PresentationLayer     # ASP.NET Core Web API (controllers, Program.cs)
│
├── 📂 ApplicationLayer      # Business logic, CQRS (Commands, Queries, DTOs, Handlers)
│
├── 📂 DataAccessLayer       # EF Core DbContext, Entities, Repositories, UnitOfWork
│
└── 📂 Domain (optional)     # Core entities (if separated)

⚙️ Technologies Used

ASP.NET Core 8 Web API

Entity Framework Core (SQL Server provider)

CQRS Pattern with MediatR

Repository & Unit of Work Pattern

Swagger / OpenAPI for API documentation

🚀 Getting Started
1️⃣ Clone the Repository
git clone https://github.com/amiraadawy/Three-Tier-Architecture
cd MyApp

2️⃣ Configure Database Connection

Update appsettings.json in PresentationLayer:

"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=Three_Tier_Application;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
}

3️⃣ Run Migrations

From the solution root:

dotnet ef migrations add InitialCreate -p DataAccessLayer -s PresentationLayer
dotnet ef database update -p DataAccessLayer -s PresentationLayer


This will create the database and apply schema (including Customers table with seeded data).

4️⃣ Run the Application
cd PresentationLayer
dotnet run


📌 Example API Endpoints
Customers

GET /api/ Get customers → Get all customers

GET /api/customers/{id} → Get customer by ID

POST /api/customers → Create new customer

PUT /api/customers/{id} → Update customer

DELETE /api/customers/{id} → Delete customer

🏗️ Architecture Principles

Separation of Concerns → Each layer has a single responsibility.

CQRS → Commands modify state, Queries read data.

Dependency Injection → Registered via DependencyInjection.cs in each layer.

Unit of Work + Repository Pattern → Encapsulates data access logic.

👩‍💻 Contributing

Fork the repo

Create a new branch (feature/my-feature)

Commit changes

Push branch and create a PR

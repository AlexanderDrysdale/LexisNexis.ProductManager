# Product Manager - ASP.NET Core CQRS Boilerplate

**Product Manager** is a boilerplate solution designed to demonstrate the implementation of Command Query Responsibility Segregation (CQRS) in ASP.NET Core (.NET 6) using MediatR.  
It provides a clean, extensible architecture for building modern applications with clear separation of concerns.

---

## What is CQRS?

**CQRS (Command Query Responsibility Segregation)** is an architectural design pattern that separates read operations (queries) from write operations (commands).  
By splitting responsibilities, CQRS enables:
- Clear separation of concerns
- Improved scalability
- Easier maintenance and testing
- Flexibility in handling complex business logic

---

## Technologies Used

- **ASP.NET Core (.NET 6)**
- **Entity Framework Core (EF Core 6)**
- **MediatR** for request/response handling
- **FluentValidation** for input validation
- **SQLite** for persistence
- **Angular** with Bootstrap and RxJS for the frontend

---

## About the Boilerplate

This solution is ideal for developers who want to:
- Quickly start with a CQRS‑based architecture
- Learn and understand CQRS concepts in practice
- Build scalable applications with clean separation between commands and queries

The codebase is intentionally kept simple and approachable, making it suitable for both beginners and experienced developers.

---

## Features

1. **Clean Architecture** with well‑defined layers for API, Core, Contracts, Persistence, and Migrations
2. **Unit of Work** pattern with a Generic Repository implementation  
   [Learn more](https://referbruv.com/blog/posts/understanding-and-implementing-unitofwork-pattern-in-aspnet-core)
3. Preconfigured **EF Core migrations** with SQLite
4. Segregated **Commands and Queries** with their respective handlers
5. **FluentValidation** integrated into command classes for robust input validation  
   [Reference](https://referbruv.com/blog/posts/implementing-fluent-validation-in-aspnet-core-%28net-5%29-mvc)
6. **Swagger UI** configured for API exploration and testing

---

## Getting Started

1. Install the **.NET 6 SDK**
2. Clone the repository to your local machine
3. Set both **UI** and **API** projects as startup projects
4. Run the solution

---

## Database Migrations

Run the following commands in the Package Manager Console (with `Migrations` as the default project):

```powershell
Add-Migration CreateProductsTable -StartupProject LexisNexis.ProductManager.API
Update-Database

# Product Manager - ASP.NET Core & Angular

**Product Manager** is a complete solution for managing products, categories, and related business workflows.  
Built with ASP.NET Core (.NET 6) and Angular, it demonstrates how to implement a clean CQRS architecture while delivering a fully functional product management system.

---

## Overview

Product Manager provides a robust foundation for building and extending product‑driven applications.  
It includes APIs, persistence, validation, and a modern Angular frontend for managing products and categories end‑to‑end.

---

## Key Features

- **Full Product Management**  
  Create, update, list, and delete products with attributes such as name, description, SKU, price, quantity, and category.

- **Category Management**  
  Organize products into categories with hierarchical support (parent/child relationships). Categories can be displayed as a tree in the Angular UI.

- **CQRS Architecture**  
  Commands and queries are separated with MediatR, ensuring clear separation of concerns and scalability.

- **Validation**  
  FluentValidation enforces business rules and input constraints at the command level.

- **Persistence**  
  Entity Framework Core with SQLite (or InMemory for testing) provides reliable data storage.

- **Angular Frontend**  
  A responsive UI built with Angular, Bootstrap, and RxJS for product and category management.

- **API Documentation**  
  Swagger UI is preconfigured for exploring and testing endpoints.

---

## Technologies

- ASP.NET Core (.NET 6)
- Entity Framework Core (EF Core 6)
- MediatR
- FluentValidation
- SQLite / EF InMemory
- Angular (Bootstrap + RxJS)

---

## Getting Started

1. Install the **.NET 6 SDK**
2. Clone the repository
3. Set **UI** and **API** projects as startup projects
4. Run the solution

---

## Database Migrations

Run the following commands in the Package Manager Console (with `Migrations` as the default project):

```powershell
Add-Migration CreateProductsTable -StartupProject LexisNexis.ProductManager.API
Update-Database

![banner](assets/banner.png?raw=true)

# CQRS Ninja - ASP.NET Core Boilerplate

CQRS Ninja is a boilerplate solution, built to demonstrate implementing Command Query Responsibility Segregation - CQRS in ASP.NET Core (.NET 6) via MediatR.

# What is CQRS?

CQRS stands for Command Query Responsibility Segregation. It is an Architectural Design Pattern that advocates segregating or grouping the methods based on how they impact the data and design them separately according to their requirements. CQRS helps segregate functionalities into two different models - Commands and Queries, there by creating a clear separation of concerns for each functionality.

# Technologies

* ASP.NET Core (.NET 6)
* Entity Framework Core (EFCore 6)
* MediatR for .NET 6
* Fluent Validation for .NET 6
* SQLite
* Angular - bootstrap and rxjs

# About the Boilerplate

This boilerplate is a perfect starter for developers looking to implement CQRS. It also helps beginners better understand the concept of CQRS and how its implemented, while keeping the code simple.

# What do you get?

1. Clean Architecture with well-defined layers for API, Persistence, Core, Contracts and Migrations
2. Implemented [UnitOfWork](https://referbruv.com/blog/posts/understanding-and-implementing-unitofwork-pattern-in-aspnet-core) with Generic Repository
3. Preconfigured Entity Framework Core migrations with SQLite
4. Segregated Commands and Queries with their Handlers
5. [Fluent Validation](https://referbruv.com/blog/posts/implementing-fluent-validation-in-aspnet-core-%28net-5%29-mvc) on the input model within the Command classes
6. Configured Swagger UI

# Getting Started

To get started, follow the below steps:

1. Install .NET 6 SDK
2. Clone the Solution into your Local Directory
3. Set UI and API as start up projects
4. Run the solution

# db migration
in package manager console default project: migrations run the following commands:

Add-Migration CreateProductsTable -StartupProject LexisNexis.ProductManager.API
Update-Database


# Generating client for angular

Run in api project: npx nswag openapi2tsclient /input:https://localhost:5001/swagger/v1/swagger.json /output:src/app/services/api-client.ts /template:Angular /injectionTokenType:InjectionToken /nullValue:Undefined 

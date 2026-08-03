# Solution Design: Product Manager

## Overview
Product Manager is a full solution for managing products and categories, built with ASP.NET Core (.NET 6), Entity Framework Core, MediatR, FluentValidation, and Angular.  
The design emphasizes clean separation of concerns, scalability, and developer productivity, while remaining approachable for teams who want to extend or customize functionality.

---

## Architectural Design

### CQRS with MediatR
- **Decision**: Commands and queries are separated into distinct handlers using MediatR.
- **Rationale**: This enforces clear separation of responsibilities, simplifies testing, and allows independent scaling of read and write paths.
- **Trade‑off**: Adds boilerplate and complexity compared to a simple CRUD controller, but improves maintainability in larger systems.

### Clean Architecture Layers
- **API Layer**: Exposes endpoints, handles HTTP concerns, and delegates to MediatR.
- **Core Layer**: Contains domain entities, DTOs, and business logic.
- **Persistence Layer**: Implements repositories and UnitOfWork using EF Core.
- **Contracts Layer**: Defines interfaces and DTOs shared across layers.
- **Trade‑off**: More layers mean more upfront structure, but they enforce boundaries and reduce coupling.

### Unit of Work + Repository Pattern
- **Decision**: A UnitOfWork aggregates repositories (`Products`, `Categories`, `Ninjas`).
- **Rationale**: Provides a single entry point for persistence operations, aligns with DDD principles, and simplifies transaction management.
- **Trade‑off**: Slightly redundant with EF Core’s DbContext, but improves testability and abstraction.

### EF Core with SQLite and InMemory
- **Decision**: SQLite is used for persistence in production; EF InMemory is used for testing and demos.
- **Rationale**: SQLite is lightweight and cross‑platform, while InMemory allows rapid prototyping and unit testing without migrations.
- **Trade‑off**: InMemory does not enforce relational constraints or behave exactly like a real database, so integration tests should still use SQLite.

### Validation with FluentValidation
- **Decision**: Input models are validated at the command level using FluentValidation.
- **Rationale**: Keeps validation close to business logic, ensures consistency, and avoids cluttering controllers.
- **Trade‑off**: Requires additional setup compared to simple `[DataAnnotations]`, but provides richer rules and extensibility.

### Angular Frontend
- **Decision**: Angular is used for the UI, with Bootstrap for styling and RxJS for reactive programming.
- **Rationale**: Angular provides a structured framework for building complex SPAs, integrates well with generated TypeScript clients, and supports modular development.
- **Trade‑off**: Angular has a steeper learning curve compared to lighter frameworks, but offers strong typing and scalability.

---

## Design Trade‑offs

1. **Complexity vs. Maintainability**  
   - CQRS and Clean Architecture add complexity compared to a simple CRUD app.  
   - The benefit is long‑term maintainability, scalability, and clear separation of concerns.

2. **Abstraction vs. EF Core Simplicity**  
   - Using UnitOfWork and repositories adds abstraction over EF Core’s DbContext.  
   - This makes testing easier and aligns with DDD, but duplicates some EF functionality.

3. **SQLite vs. InMemory**  
   - SQLite is closer to a real relational database, ensuring constraints and migrations.  
   - InMemory is faster and simpler for tests, but not a perfect substitute for production behavior.

4. **Angular vs. Lightweight Frontend**  
   - Angular provides a robust framework for enterprise‑scale apps.  
   - A lighter frontend (React, Vue) could reduce complexity, but Angular’s structure benefits teams already invested in TypeScript and RxJS.

---

## Conclusion
Product Manager balances **clarity, scalability, and developer experience**.  
The chosen design patterns (CQRS, Clean Architecture, UnitOfWork) introduce some overhead but provide a strong foundation for extending the system.  
SQLite and InMemory offer flexibility across environments, while Angular ensures a modern, maintainable frontend.  

This solution is not just a boilerplate — it is a **full product management system** ready for real‑world scenarios, with deliberate trade‑offs to maximize maintainability and extensibility.

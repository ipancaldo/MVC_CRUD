# MVC_CRUD

A small ASP.NET MVC 5 (.NET Framework 4.7.2) web application built as one of my **first MVC / CRUD projects**. It was written mainly as a learning exercise, to practice the classic N-layer architecture used in a lot of .NET business applications: separate projects for entities, data access, business logic and presentation.

The data model is based on the classic Microsoft **Northwind** sample database (Products, Employees, Customers).

## What it does

- **Products** – full CRUD:
  - list all products (id, name, quantity per unit, price)
  - create a new product
  - edit an existing product
  - delete a product
- **Employees** – read only:
  - list all employees, including a calculated *seniority* (years since hire date)
  - view the details of a single employee
- **Error handling** – controllers catch exceptions, show a friendly error page and write the error (with a timestamp) to a plain text log file.
- **Validation** – server-side validation with data annotations on the view models (required fields, string lengths, price range), plus the jQuery unobtrusive validation scripts on the client.

## Project structure

The solution (`MVCCRUD.sln`) is split into four projects:

| Project | Responsibility |
|---|---|
| `Entities` | POCO classes that map the Northwind tables: `Products`, `Employees`, `Customers`. |
| `Data` | Entity Framework 6 `DbContext` (`NorthwindContext`) with the model configuration and the `NorthwindConnection` connection string. |
| `Logic` | Business layer. A generic `IABMLogic<T>` interface (ABM = *Alta, Baja, Modificación*, the Spanish equivalent of CRUD) implemented by `ProductsLogic` and `EmployeesLogic`, plus `LogErrorsLogic` for error logging. |
| `MVC` | Presentation layer: controllers, view models (`ProductsView`, `EmployeesView`), Razor views and Bootstrap styling. |

The dependency flow is `MVC → Logic → Data → Entities`.

## Tech stack

- C# / .NET Framework 4.7.2
- ASP.NET MVC 5.2.7 (Razor views)
- Entity Framework 6.2 (Database First, Northwind)
- AutoMapper 10.1 (entity → view model mapping in the Employees details view)
- Bootstrap 3, jQuery 3.4, jQuery Validation / Unobtrusive Validation
- Visual Studio 2019 solution, NuGet packages committed in `packages/`

## Running it

1. Open `MVCCRUD.sln` in Visual Studio 2019 (or newer) with the *ASP.NET and web development* workload installed.
2. Build the solution (NuGet packages are already included in the repo).
3. Run the `MVC` project with IIS Express. The default route goes to `Products/Index`.

Out of the box the app runs against a small **in-memory data store** (`Logic/InMemoryDataStore.cs`) seeded with a few sample products and employees, so you can try it without installing anything else. Data lives only for as long as the application pool is alive — restarting the app resets it.

To run it against a real SQL Server Northwind database instead, point the `NorthwindConnection` connection string in `MVC/Web.config` (and `Data/App.config`) at your own server and wire the logic classes to `NorthwindContext` instead of the in-memory store.

## Notes / known limitations

This is early work and it shows — keeping it here as a reference of where I started:

- The business lay

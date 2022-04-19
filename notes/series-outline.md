# Entity Framework Core video series

> Please note: This is a rough working outline for this series. It was used to create the scripts for each part. The final videos may contain variations and adjustments.

## Part 1: Intro to EF Core (15 mins)

1. Intro
    1. EF Core makes it easy to store your objects in a database without writing much, if any, database code.
    1. It supports a lot of different database engines, like SQL Server, Postgres, and Azure Cosmos DB.

1. Walkthrough
    1. File > New Project > Console App
        1. Paste in location - C:\Src\ef-core-101\parts\1 - Getting Started
    1. Add NuGet Packages (Manage NuGet Packages dialog)
        1. `Microsoft.EntityFrameworkCore.SqlServer`
        1. `Microsoft.EntityFrameworkCore.Design`
        1. `Microsoft.EntityFrameworkCore.Tools`
    1. Build the ContosoPets domain model
        1. Explain that we're building [this database](https://docs.microsoft.com/en-us/learn/aspnetcore/persist-data-ef-core/media/4-design-domain-model/database-diagram.png)
        1. *Product.cs* (product snippet)
            - `Id` is primary key (by convention - explain equivalent to `[Key]`)
            - `[Required]` attribute on Name property -- EF Core doesn't enforce validation!
            - `[Column]` attribute on Price property
        1. *Customer.cs* (customer snippet)
            - `Orders` navigation property => One-to-many relationship
        1. *Order.cs*  (order snippet)
            - `ProductOrder` => navigation property
        1. *ProductOrder.cs*  (po snippet)
            - navigation properties => many-to-many, intersection table
            - `ProductId` and `OrderId` => shadow properties if not included
    1. Create `ContosoPetsContext` (same gist)
        1. `DbSet<T>`
        1. Mention why you shouldn't hard-code the connection string like we are.
    1. Create and run the `InitialCreate` migration. (define migration as "set of tools to evolve db") Show new tables in SQL Server Object Explorer, ending with Customer
    1. We forgot the `Email` property! Add it to *Customer.cs* and create and run the `AddEmail` migration. Show modified Customer table.
    1. addproducts snippet in *Program.cs* to add a couple products. Build & run. Show new rows in SQL Server Object Explorer
    1. displayproducts snippet in *Program.cs* to read a filtered, ordered list of products to console. 
    1. linqproducts snippet to change previous query to Linq format. Build & run. 
    1. updateproduct snippet in *Program.cs* to modify a single product (price increase). Build & run. P
    1. Replace line that  sets price with `context.Remove(veggieSpecial);` in *Program.cs* to delete a single product. Build & run.

1. Outro
    1. Check out aka.ms/learn-ef-core!

## Part 2: Working with an Existing Database (10 min)

1. Intro

    Many developers want the features of EF Core, but have to use it with an existing database. EF Core provides tools to reverse-engineer an existing database and generate an entity model.

1. Walkthrough
    1. Existing empty console application
        1) NuGet packages are already in csproj
    1. `Scaffold-DbContext` (paste full command from text file)
    1. Walk through a generated class (customer?), point out attributes, compare to table designer view

1. Outro

## Part 3: ASP.NET Core web apps with EF Core (5-10 min)

1. Intro

1. Walkthrough
    1. Start with brand new web app, start with Model and Database and everything ready to go
    1. Register `DbContext` in DI Container.
        - Don't go too deep in the weeds on DI
    1. Scaffold Razor pages (Razor Pages Using EF (CRUD))
        1. Define scaffolding (high level)
        1. *Products/Index.cshtml*
            - `ContosoPetsContext` is injected into *Index.cshtml.cs*
            - The .cshtml loops over the entire collection.
    1. Run the app. Browse to Products/Index.
    1. Browse Products/Create
        1. Show *Create.cshtml* and *Create.cshtml.cs*.
            - Validation tag helpers enforce the model's constraints.
            - `.OnPost() => .Add()`, `.SaveChanges()`
    1. Browse Products/Index. Click Edit on a product.
        1. Show *Edit.cshtml.cs*
            - `OnGet` finds the record indicated by the ID in the URL.
            - `OnPost` does the same, modifies it, and persists to database.
    1. Browse back to Products/Index. Click **Delete** on a product.
        1. Show *Delete.cshtml.cs* where the record is deleted
        1. Click the Confirm button on the page.

1. Outro

## Part 4: Database Providers (< 5 min)

1. Intro
    1. Mention something about how we've been using SQL Server so far, but EF Core supports lots of different databases

1. Walkthrough
    1. Quickly talk through [this image](https://docs.microsoft.com/en-us/learn/aspnetcore/persist-data-ef-core/media/2-setup-environment/ef-core-architecture.png) and how it relates to DB Providers
    1. SqlLite
        1. Define SqLite (x-plat, small, fast, embedded)
        1. Show working web app
        1. Show package reference: `Microsoft.EntityFrameworkCore.Sqlite`
        1. Show *Program.cs* where we call `context.Database.EnsureCreated()`
        1. Run web app, add a new product
        1. Show *ContosoPets.db* created
        1. Show new product in Sqllite GUI tool DB Browser
    1. Cosmos DB
        1. Define Cosmos (cloud, distributed, resilient, NoSQL)
        1. Show working web app
        1. Show package reference: `Microsoft.EntityFrameworkCore.Cosmos`
        1. Show  Program.cs where we call `context.Database.EnsureCreated()`
        1. Show in Product.cs where Id is a string (not int) and setting default value to NewGuid()
        1. Run web app, add a new product
        1. Show new product in Azure Portal
    1. Mention 3rd party DB providers, show [providers doc](https://docs.microsoft.com/en-us/ef/core/providers/?tabs=dotnet-core-cli)

1. Outro

## Part 5: EF Core Performance Tips (5 minutes)

1. Intro

1. Walkthrough
    1. [No-tracking Queries](https://docs.microsoft.com/ef/core/querying/tracking#no-tracking-queries)
        1. Explain change tracking (tracking a snapshot).
            - Don't need resources to track large result sets
        1. `.AsNoTracking()` on *Products\Details.cshtml.cs*
    1. [Loading related entities](https://docs.microsoft.com/ef/core/querying/related-data)
        1. *Customer\Details.cshtml*
    1. `.FromSqlInterpolated()`
        1) fromsql snippet - Replace query in *Products\Index.cshtml.cs* to filter results
    1. `.FindAsync()`
        1) Only goes to the database if a snapshot of the entity doesn't exist in memory
        2) Show in *Products\Details.cshtml.cs*
    1. `DbContext` Pooling - *Startup.cs*

1. Outro

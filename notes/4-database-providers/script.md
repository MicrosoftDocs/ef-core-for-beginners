# Part 4 Script

## Please note: This is the working script used for shooting. The final videos may contain variations and adjustments.

> Hi, friends! Welcome back to Entity Framework Core for Beginners.
>
> In previous videos, we've looked at using Entity Framework Core exclusively with SQL Server. In this video, we're going to look at using Entity Framework Core with other database providers.

The database provider is a layer in the EF Core architecture that's responsible for the communication between Entity Framework Core and the database. It's a pluggable architecture, which means EF Core can support all kinds of databases.

> The first database provider we're going to look at is Sqlite. Sqlite is an open-source cross-platform embedded database technology. In Sqlite, the entire database is stored in a single file, so it's a great choice when you don't want to take a dependency on a server-based database platform.

I'm starting with a console application preconfigured with my NuGet packages. I've already written context and model classes. The code in *Program.cs* adds some records to the Products table.

Using a different database provider with EF Core is often as simple as using a different NuGet package. To use the Sqlite provider, I'm going to install the `Microsoft.EntityFrameworkCore.Sqlite` package. I'll uninstall the SqlServer package, too. Then I'll go to the `OnConfiguring` method in `ContosoPizzaContext` and configure the context with the `UseSqlite` extension method. The connection string points to the file to be created.

Now I'll create my InitialCreate migration. After that, I'll use `Update-Database` to run the migrations. The *ContosoPizza.db* file was created. 

Before we run, since I'm using Visual Studio, there's one other thing I need to check. By default, Visual Studio wants to start the app in a different directory than the build directory. If it does that, my app won't find the database. Let's add a `<StartWorkingDirectory>` element to the *.csproj* so that doesn't happen. Now let's run the app!

It's done running. Let's see if we got data in our file. In Visual Studio, I'll right click and get the path of the file, which I'm going to use to open it in an open source tool called DB Browser. As you can see, the Product data looks as we expected.

> Now let's do that same exercise again, but this time let's use Postgres. The database provider for Postgres is provided by the Postgres developer community.

I'll add the `Npgsql.EntityFrameworkCore.PostgreSQL` package to the project and delete the Sqlite package. Now I'll replace the the call to the `.UseSqlite` method with a call to `.UseNpgsql`.

Now I'll generate and run new migrations.

Lets run the app.

The app's done running. I'llm switch over to the pgAdmin tool and query the database. As you can see, the Product table has data.

> The final database provider I'm going to show you is for Azure Cosmos DB. Cosmos DB is a fully managed NoSQL database for modern app development. This means that instead of working like a relational database management system, it works with JSON documents.

I've already created a free Cosmos DB account configured to use the Core API. I haven't added any database containers yet. It's just an empty Cosmos account. 

I'll go to the Keys tab to get my connection string, then I'll go back to Visual Studio.

I'll add the `Microsoft.EntityFrameworkCore.Cosmos` package to the project and remove the Postgres package. This time I'll call the `.UseCosmos` method. In addition to the connection string, I must also specify a database name.

Since Cosmos DB is a NoSQL database, and there aren't any database schemas to update, let's delete the Migrations folder.

Since there are no migrations to create the initial database, let's call `context.Database.EnsureCreated` in *Program.cs* to make sure the database gets created. `EnsureCreated` can cause performance issues, so avoid using it in production. 

One other difference we need to account for with Cosmos DB is with the primary keys. The other databases we used support auto-generating a primary identifier. Since Cosmos DB doesn't do that, we need to handle it ourselves.

I'll change the Product entity model so that `Id` is a string. I'll initialize it to a new globally unique identifier. Since this primary key is a foreign key on `OrderDetails`, I'll change `ProductID` to be a string as well, and I'll assign it to null along with the null-forgiving operator.

Let's run the app. Now that that's done, we'll go over to the Azure portal, where we can see the data we just added.

> In this video, we looked at how EF Core uses database providers to support a plethora of different database technologies. We looked at just three of the possible database providers you can use. Visit the Entity Framework Core documentation to see the full list of supported providers.
>
> In the next video, I'm going to show you some tips to optimize performance in your EF Core applications.
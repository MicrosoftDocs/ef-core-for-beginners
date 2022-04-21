# Part 4 Script

> Please note: This is the working script used for shooting. The final videos may contain variations and adjustments.

Hi, friends! Welcome back to Entity Framework Core for Beginners.

In previous videos, we've looked at using Entity Framework Core exclusively with SQL Server. In this video, we're going to look at using Entity Framework Core with other database providers.

The database provider is a layer in the EF Core architecture that's responsible for the communication between Entity Framework Core and the database. It's a pluggable architecture, which means EF Core can support all kinds of databases.

The first database provider we're going to look at is Sqlite. Sqlite is an open-source cross-platform embedded database technology. In Sqlite, the entire database is stored in a single file, so it's a great choice when you don't want to take a dependency on a server-based database platform.

I'm starting with console application. I've already written context and model classes. The code in *Program.cs* adds some records to the Products table.

Using a different database provider with EF Core is often as simple as using a different NuGet package. To use the Sqlite provider, I'm going to install the `Microsoft.EntityFrameworkCore.Sqlite` package. The I'll go to the `OnConfiguring` method in `ContosoPizzaContext` and configure the context with the `UseSqlite` extension method. The connection string points to the file to be created.

Now I'll create my InitialCreate migration. After that, I'll use `Update-Database` to run the migrations. The *ContosoPizza.db* file was created, so let's run the app!

It's done running. Let's see if we got data in our file. In Visual Studio, I'll right click and get the path of the file, which I'm going to use to open it in an open source tool called DB Browser. As you can see, the Product data looks as we expected.

Now let's do that same exercise again, but this time let's use Postgres. The database provider for Postgres is provided by the Postgres developer community.

I'll add the `Npgsql.EntityFrameworkCore.PostgreSQL` package to the project. Now I'll replace the the `.UseSqlite` method call with a call to `.UseNpgsql`.

We don't need to generate a new migration. We can use the one we generated last time. We do need to run `Update-Database` to run the migration, though.

Looking in my pgAdmin, I can see the database was created. Lets run the app.

The app's done running. As you can see, the Product table has data.

The final database provider I'm going to show you is for Azure Cosmos DB. Cosmos DB is a fully managed NoSQL database for modern app development. This means that instead of working like a relational database management system, it works with JSON documents.

I've already created a free Cosmos DB account configured to use the Core API. I haven't added any database containers yet. It's just an empty Cosmos account. 

I'll go to the Keys tab to get my connection string, then I'll go back to Visual Studio.

I'll add the `Microsoft.EntityFrameworkCore.Cosmos` package to the project. This time I'll call the `.UseCosmos` method. In addition to the connection string, I must also specify a database name.

Since Cosmos DB is a NoSQL database, we don't need to run any migrations. There aren't any database schemas to update. 

One difference we *do* need to account for, however, is with the primary keys. The other databases we used support auto-generating a primary identifier. Since Cosmos DB doesn't do that, we need to handle it ourselves.

I'll change the Product entity model so that `Id` is a string. I'll initialize it to a new globally unique identifier. Since this primary key is a foreign key on `OrderDetails`, I'll change `ProductID` to be a string as well, and I'll assign it to null along with the null-forgiving operator.

Let's run the app. Now that that's done, we'll go over to the Azure portal, where we can see the data we just added.
refresh my list of items in my Cosmos DB instance,
and you can see the squeaky bone I just added.
These are just two of the possible database providers
you can use with Entity Framework Core.
Visit the Entity Framework Core documentation
to see the full list of supported providers.
Some are provided by Microsoft,
and some are provided by the community.
Support includes, MySQL, Postgres,
Oracle, DB2 and others.
In this video, we looked at how EF Core uses
database providers to support
a plethora of different database technologies.
In the next video,
I'm going to show you tips to get
the most performance out of your EF Core applications.
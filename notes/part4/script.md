# Part 4 Script

> Please note: This is the working script used for shooting. The final videos may contain variations and adjustments.

Hi, friends! Welcome back to Entity Framework Core for Beginners.

In previous videos, we've looked at using Entity Framework Core exclusively with SQL Server. In this video, we're going to look at using Entity Framework Core with other database providers.

The database provider is a layer in the EF Core architecture that's
responsible for the communication between
Entity Framework Core and the database.
It's a pluggable architecture which means
we can support all kinds of databases.
The first database provider we're going to look at is SQLite.
SQLite is an open-source cross-platform
embedded database technology.
I'm starting with a web application,
where I've already got Microsoft.entityFrameworkCore.SQLite.Design
and.Tools installed.
To use the SQLite provider,
where I would previously use.U-SQL server.
I'm instead calling.USQLite, and I'm
passing in the connection string in the SQLite format.
That connection string points to a local file here on my machine.
I've created a new record.
I'm going to use a tool to read SQLite databases,
this is an open source tool
available for download on the Internet,
and we'll browse to the product's table.
As you can see, there's the rope pull toy I just added.

The next database provider we're going to look
at is a brand new database provider from
the Microsoft Entity Framework Core Team
that supports Azure Cosmos DB.
Cosmos DB is a Cloud-based distributed NoSQL database,
which means that instead of being
a relational database management system,
it works with JSON documents.
Just as in my previous example,
I have a working web application and in this web application,
I've already added
Microsoft.EntityFrameworkCore.Cosmos.Design and.Tools.
We already have a working entity model
and a working database context.
We'll use the use Cosmos method
to pass in our connection information,
and once again, I have to remind you,
don't include sensitive information in your code.
One difference with Cosmos DB,
is that it doesn't support the concept of
an auto-generated int for a primary identifier.
So I've changed the entity model so that our IDs will be strings,
and there'll be initialized to a new
GUID or globally unique identifier.
Let's run the application and add
a record to our Cosmos DB instance.
Now that I've added that record,
we'll go over to the Azure portal,
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
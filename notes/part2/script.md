# Part 2 Script

> Please note: This is the working script used for shooting. The final videos may contain variations and adjustments.

Hi, friends! Welcome back to Entity Framework Core for Beginners.

In our previous video, I showed you how easy it is to use Entity Framework Core migrations to create and work with a new database. We defined our entity model in code before we built the database. Then we used migrations to change the database as we made changes to the model. When we use that approach, we're treating the code as the authoritative "source of truth" regarding the shape of our entities.

In this video, I'm going to show you how to use Entity Framework Core to work with an existing database by reverse engineering it. This approach treats the database as the source of truth. 

Looking at Visual Studio, I have a brand new console app that doesn't have any code added to it at all. I've already added the Microsoft.EntityFrameworkCore.SqlServer, .Design, and .Tools NuGet packages.

I have an existing database. This database is already populated. Let's assume was created and maintained by my organization's Database Administrator.

To reverse engineer the database and create my entity model code, I'll start by using the Scaffold-DbContext commandlet. I'm going to pass in the connection string (which can be found in the notes). I'm going to pass in the name of the provider so it knows what type of database to execute the connection string on, and then I'm going to optionally specify output directories for the dbcontext and models.

If you're using the .NET CLI, the command is `dotnet ef dbcontext scaffold`. The parameters are similar.

Now that the Scaffold is run, we have a complete working entity model.

Looking at the product entity, it should look pretty similar to the one we created in the last video. One difference you'll note, however, is there are no data annotations describing the behavior of these properties, like the one we used previously for Price.

That's because these behaviors are contained in the OnModelCreating method of the database context. This is another way EF Core lets you control the relationship between your entities and the database.

If we'd like to generate an entity model that looks more like the one we created in the previous video, we can do that too. I'll start by deleting this entity model, and I'll run the Scaffold-DbContext command again. This time, I'll add the data annotations flag.

Here's what that looks like with the .NET CLI.

This time, the product entity has data attributes that describe the behavior of the properties. The OnModelCreating method in the database context is much more sparse.

You might be wondering, what do we do when the database schema changes? There are two strategies.

The first strategy is a manual approach. This approach requires you to manually edit your entity model to keep in sync with the database schema. The generated dbcontext and models can thought of as a starting point for ongoing development, similar to scaffolded razor pages in ASP.NET Core.

The other strategy is just rescaffolding the entity model whenever the database schema changes. Using this approach, it's important to use partial classes or extension methods to keep business logic separate from scaffolded entities. This ensures that business logic doesn't get overwritten if you re-scaffold the entities. I'm going to delete my entity model and re-scaffold. This time, I'm going to generate the models in a subdirectory of the Models directory, I'll specify the namespaces for the generated classes.

Now I can create partial classes in the Models directory to contain my business logic. This way, I can regenerate the entity models without disturbing my business logic.

Now that we've seen how Entity Framework Core can work with an existing database, in the next video, I'm going to show you how to use Entity Framework Core with ASP.NET Core to streamline your web development.

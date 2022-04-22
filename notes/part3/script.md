# Part 3 Script

## Please note: This is the working script used for shooting. The final videos may contain variations and adjustments.

> Hi, friends! Welcome back to Entity Framework Core for Beginners.
>
> In this video, I'm going to show you how you can use Entity Framework Core with ASP.NET Core scaffolding to streamline your web development. Let's get to it!

I've already created an empty ASP.NET Core Razor Pages web app. I used the command I showed you in the last video to scaffold a `DbContext` and models against that same database. Now we're going to scaffold some Razor pages that use `ContosoPizzaContext` to interact with the database.

`ContosoPizzaContext` contains the connection string that was used for scaffold in the `OnConfiguring` method. We're going to get our connection information from configuration, so let's delete that method.

Now I'm going to visit *Program.cs*. I'll paste in some code to and then I'll add the `using` directives to resolve those references.

The `AddDbContext` extension method registers `ContosoPizzaContext` with ASP.NET Core's dependency injection container. We pass the method a lambda expression that configures EF Core to use the SQL Server database provider using a connection string retrieved from configuration.

> In the previous videos, I've mentioned that it's a bad practice to store your connection strings with your code. The .NET Secrets Manager gives us a mechanism to separate our secrets from our code. Let's use the .NET secrets manager to store that connection string.

I'm right-clicking on the project and selecting **Manage User Secrets**. Visual Studio opens a file named *secrets.json* for editing, and I'll paste in my connection string. This file is stored in you user profile on your development machine. The secrets aren't encrypted. It's just a location to store them away from your code. At runtime, ASP.NET Core will look for the configuration in *appsettings.json* and other locations. *secrets.json* is one of the locations it checks.

If you're using the .NET CLI, you must first initialize the secret store with `dotnet user-secrets init`. Then you can add the your secrets with `dotnet user-secrets set`.

Now we're going to generate razor pages to support Creating, Reading, Updating, and Deleting products. These operations are collectively referred to as CRUD. The first thing I'm going to do is add the `Microsoft.VisualStudio.Web.CodeGeneration.Design` package to the project. This installs some dependencies for the scaffolding tool.

Now I'll create a Products folder inside the Pages folder. After that, I'll right-click on the folder, select "Add", and then "New Scaffolded Item..." In the dialog that follows, select Razor Pages using Entity Framework CRUD. Select `Product` as the model class and `ContosoPizzaContext` as the data context class. Click Add.

If you're using the .NET CLI, first install the `dotnet-aspnet-codegenerator` tool as a global tool. Then use the `dotnet aspnet-codegenerator` command to scaffold the pages. I've put the full command in the notes.

The scaffolding creates five pages: Create, Delete, Details, Edit, and Index.

I'm going to run the application. I'll edit my URL to navigate directly to the products Index page. This View lists all the products in the table. I'm going to leave the app running, but I'll switch back to my IDE. Let's look at the code for *Index.cshtml.cs*.

Notice that we're injecting `ContosoPizzaContext` into the constructor. ASP.NET Core's dependency injection container takes care of this for us. All we have to do is ensure the constructor has the right signature. 

The products collection is accessed by a property on the page model class. The `OnGet` method sets that property equal to the contents of the `Products` `DbSet`.

The Razor view enumerates over that list of products and for each product lists the name and price.

Let's use the Create page to create a new product.

There's a new product. Let's look at what happened in the code. We'll start with the page model. The `OnGet` method in the page model returns the empty form, which is a Razor view.

The Razor view has elements to support name and price. It uses label, input, and span elements to build the form that we saw earlier. This includes validation that enforces the constraints in our model classes.

When we post the form, the model binder binds the elements on the form to our product property, which in turn is added to the products `DbSet`. Finally, we call `SaveChangesAsync` to save the changes to the database.

Let's edit a record. When we visit this page, the name and price elements are pre-populated with existing data. Looking at the page model for `Edit`, the `OnGet` method queries the database for products that match the `Id` that was passed in on the URL's query string. We retrieve that product and present it for the user to edit. 

When the user posts the form, the model binder builds a `Product` object from the elements on the page, attaches it to the existing entity, marks it as modified, and saves the changes.

The final view we're going to look at is `Delete`. The `Delete` view is similar to the `Edit` view. The first thing `OnGet` does is look up the product by `Id` and display it for the user.

When the user clicks the "Submit" button, we find that same product by its ID. Then we call `Remove` on the `Products` `DbSet`, passing in the entity to delete.

> In this video, we saw how easy it is to use ASP.NET Core along with Entity Framework Core to streamline your web development. In the next video, we're going to look at using different database providers with Entity Framework Core.

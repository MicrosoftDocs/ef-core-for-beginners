# Part 3 Script

> Please note: This is the working script used for shooting. The final videos may contain variations and adjustments.

Hi, friends! Welcome back to Entity Framework Core for Beginners.

In this video, I'm going to show you how you can use Entity Framework Core with ASP.NET Core scaffolding to streamline your web development.

You can see in Visual Studio,
I've got a mostly empty web application.
This web application, already has
ContosoPetsContext DbContext as well as an entity model.
The entity model reflects
a working database that's already running in production.
The first thing I'm going to do is I'm going to register
our ContosoPetsContext with ASP.NET
Core's dependency injection container.
The way I do this is by calling AddDbContext on
the services class and configure services in the startup.cs.
You'll note that we're passing in use
SQL Server on the options along with our connection string.
Again, please don't ever hardcode your connection strings.
We're going to use the scaffold to generate
razor pages to support adding,
editing, deleting, and reading products.
I've created a product's folder and on
that folder I'm going to right-click,
go to "Add Razor Pages"
and Razor Pages using Entity Framework CRUD.
I'll select product as
the model class and ContosoPetsContext as the data context class.
Visual Studio creates five pages: create,
delete, details, edit, and index.
If we run the application,
we can look at the index page which lists the products.
Let's look at the code behind this index page.
If we look at the constructor for
the page model behind the index page,
you'll note that we're injecting
ContosoPetsContext into the constructor.
ASP.NET Core's dependency injection
container takes care of this for us.
All we have to do is make
our constructor with the right signature.
The list of products, rather,
is contained on a property on the page model class.
The view enumerates over that list of products
and for each product lists the name and price.
Let's create a new product.
So there's our new product.
Let's look at what happened in the code.
We'll start with the page model.
The OnGET method in the page model returns
the empty form, which is a Razor view.
The Razor view has elements to support name and price.
We have label, input, and span.
They combine to form the form that we saw earlier including
validation that enforces the constraints in our entity model.
When we post the form,
the model binder binds the elements on the form to
our product property which we then
add to our products table and save changes async.
Let's edit an entity. Know that on this form,
the name and price elements were
pre-populated with the existing data before we changed it.
If we look at the page model for edit on the OnGET,
we're querying our database contexts for products that match
the ID that was passed in on the URL's query string.
We retrieve that product and present it for the user to edit.
Now, when the user posts the form,
the model binder grabs
that same product object and attaches it to the database context,
finds the existing product,
marks it as modified, and save the changes.
The final operation we're going to look at is the Delete.
The delete form is actually similar to the edit form.
The very first thing we do on OnGET is we look up
the product by ID and display it for the user.
When the user clicks the "Submit" button,
which posts, we find that same product by its ID.
We call remove on the products table
passing in that entity and we save our changes.
In this video, we look at how easy it is to use the ASP.NET
Core scaffolding along with
Entity Framework to streamline your web development.
In the next video, we're going to look at using
different database providers with Entity Framework Core.
Entity Framework Core 101
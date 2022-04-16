Hi. I'm Cam Soper, a Content Developer working on .NET docs here at Microsoft.

In this video, we're going to get started with Entity Framework Core, which is a toolset that makes it easy to store your .NET objects in
a variety of databases without writing much (or any) database code.

Here's an entity digram describing the entities we're going to persist to our database. These entities support a pizza delivery website, ContosoPizza. As you can see, a Customer can have zero or more Orders associated with it. Each Order contains 1 or more OrderDetails, and each OrderDetail contains a Product and quantity.

Let's get started with the demo.

I've got an empty .NET 6 console project. I'm going to manage my NuGet packages for the project, and search for Microsoft.EntityFrameworkCore.

I'll grab the Microsoft.EntityFrameworkCore.SqlServer package and install it to my project. Now that that's installed, I'm also going to
install Microsoft.EntityFrameworkCore.Design and Microsoft.EntityFrameworkCore.Tools.

To get started with Entity Framework Core, we need to build classes describing our entity model. By convention, these are usually stored in a folder called models.

I'm going to create the first table, probably the simplest one, Products. We've added an empty class, and for expediency I'm going paste in some code.

Looking at the product class as we've built it, the first thing that I want to call out is this first property, ID. In Entity Framework Core,
ID is a special property name that indicates that this property is to be the primary key in the table that gets generated. It doesn't have to be named ID, it can be the table name followed by ID, or it can be anything we want it to be, in which case we decorate the property with the KEY attribute to indicate that it's a primary key.

The other two properties on this class are NAME and PRICE, which we've indicated is a decimal with two decimal points of precision. 

You may be wondering why I've initialized NAME as null with an exclamation point. That's because in .NET 6, all projects enable nullable reference types by default. This means the compiler will issue a warning if a non-nullable reference type isn't initialized. Since EF Core manages entity intialization, we can suppress the warning by explicitly initializing the property as null, and then adding the null-forgiving operator. This lets the compiler know we know what we're doing, and it doesn't need to warn us about this assignment. This isn't necessary for the app to compile and run, but it keeps our project free from build warnings.

The next class we're going to add will be the customer class. Here we're using nullable and non-nullable reference types which database fields should allow nulls and which ones shouldn't. Since FIRSTNAME and LASTNAME are non-nullable strings, EF Core knows that when it creates the table, those two columns should not allow nulls.

The ADDRESS and PHONE properties, on the other hand, are nullable strings, so the database will allow nulls in those columns.

Finally, the last property on the class, called ORDERS, is a collection of ORDER objects. We haven't created the order class yet, we're going to do that in just a second. This is called a navigation property, and it indicates that a customer may have zero or more orders. This creates a one-to-many relationship in the database that gets generated.

Creating the empty orders class, I'll again paste in some code to define my properties. This should look pretty familiar. We have our ID property, an ORDERPLACED property which is a datetime, and an ORDERFULFILLED property that gets populated when the order is actually fulfilled, That last one is a nullable DateTime, so the database will allow nulls in that column.

We also have a CUSTOMER property which is another type of navigation property, specifying one customer entity per order. We've included a Customer ID property to represent the foreign key relationship to the Customer table that will be generated. If we omit the customer ID property, that's okay, too. EF Core would create it anyway as a shadow property.

Finally, we have another navigation property for a collection of OrderDetails.

The final class we're going to create is OrderDetail. This entity will generate an intersection table to facilitates the many-to-many relationship. It has navigation properties for both order and product. As with the Order class, the OrderId and ProductId represent foreign key relationships and aren't strictly required.

Now we're going to create a database context class. By convention, this typically goes in a folder called "data." I'm going to name my class ContosoPizzaContext.

ContosoPizzaContext derives from DBContext. Think of DBContext as representing a session with the database. On the DBContext derived class,
we have four properties of type DBSet. Each DBSet maps to a table that will be created in the database. 

Finally, we've overridden the OnConfiguring method to include some configuration information. Since we're using the SQL Server package,
we have a use SQL Server extension method available to us that configures the SQL Server database provider. Set the connection string to the correct connection string for your environment. I should point out that hard-coding a connection string like this is a bad practice, and you should always use a secure storage method for your real-world connection strings.

So now that we've created our entity model, we're going to create something called a migration. The EF Core migrations feature is a tool that makes it easy to create and evolve our database.

I'm going to use the Package Manager Console to run the Add-Migration commandlet. I'm going to name my migration InitialCreate.

Let's take a look at the generated code. We should look it over to make sure it's accurate and that it creates the table the way we want it to be created.

Looking at the products table as an example, we can see where it's creating our identity column, our primary key, our Name (which is not nullable), and our price, decimal with two decimal points of precision.

I'm satisfied that the migration is correct, so I'll run the migration with the Update-Database commandlet. Now let's take a look at the database that was created.

The first table we're going to look at is this one that we didn't create at all, EF migration history. This table is used by Entity Framework Core to track which migrations have been run against this database.

Let's look at the products table. It looks like the products table was generated exactly as we intended.

Let's also look at customer. The customer table was also generated pretty much as we expected, except I just realized that I forgot to add an e-mail column. Let's go back to the customer entity and add a property for e-mail. E-mail will be a nullable string. 

Now that we've modified the customer entity, we'll create another migration. I'll name this one AddEmail. If we look at this migration, we see that it's pretty simple. All it does is add a column.

Let's go ahead and run Update-Database again to make sure that our database is up-to-date with our migrations. As expected, the e-mail column has been added to the table.

Now that we've built our database context and our entity model, let's do something with it.'

To get started, I'm going to add a few products to my products table.

The first thing I'm going to do is use a Using declaration to create a new instance of ContosoPetsContext. This Using declaration ensures that the ContosoPizzaContext object is disposed off properly when we're done using it.

The first product I'm going to add to my table will be a Veggie Special Pizza. I create the veggieSpecial object and then add it to the products table using the DBContext.

The next product I'm going to add will be a Deluxe Meat Pizza. This time I added it directly to the context. EF Core can infer that this entity is a Product based on its type.

Finally, we're going to call save changes on the context.

Let's run it and see what happens.

As expected, two products have been added to the products table; our Veggie Special Pizza and our Deluxe Meat Pizza. 

Now that there are some entities in the database, let's try reading them. Using that same ContosoPizza database context, I'm going to query the products table using a Fluent API. Fluent APIs use extension methods to chain methods together, along with lambda expressions to specify the query. In this case, we're looking for any product where the price is greater than 10, and we're going to order by name. Then we're just going to write it all out to the console.

If you don't like the Fluent API syntax, you can also use the LINQ syntax. LINQ syntax is very similar to SQL code. Let's replace the fluent API syntax with the LINQ syntax. Both of these methods are equivalent and result in the same queries to the database.

As expected, our one product whose price is greater than 10 shows up in the results.

Now that we've read entities from the database, let's try updating an entity. To update an entity, first we have to get a reference to it. We'll query the table looking for any product whose name is Veggie Special Pizza and take the first or default result. If there's no record that matches that name, we'll get the default, which is null. Here we check to see if the veggieSpecial object is a product and not null, and if it is a product, we'll set the price to 10.99. Finally, we'll save our changes.

Since we changed the price to greater than 10, Veggie Special Pizza shows up in the result set now.

The final thing we're going to show is how to delete an entity from the database. To delete, you simply pass a reference to the entity to the remove function on the database context.

That's how easy it is to use Entity Framework Core to persist .NET objects in a database! In this video, we used EF Core migrations to create a new database from our code. In the next video, we're going to show how to go the other way, creating code to use an existing database.

In the meantime, if you'd like to try an interactive tutorial for Entity Framework Core, go to aka.ms/learn-ef-core.
# Part 5 Script

> Please note: This is the working script used for shooting. The final videos may contain variations and adjustments.

Hi, friends! Welcome back to Entity Framework Core for Beginners.

>> Hi. I'm Cam Soper,
a Content Developer here at Microsoft working on.NETDOCS.
Today in this video,
we're going to get started with Entity Framework Core,
which is a toolset that makes it easy to store your.NET objects in
a variety of databases without writing much if any database code.
The database we're going to build supports
an online retailer Contoso pets,
which markets dog toys.
The customers table can have
zero or many orders associated with it,
and each order has many products associated with it.
This is enabled by way of
an intersection table which
facilitates a many-to-many relationship.
Let's get started with the demo.
I've got an empty console project here created with.NET Core 3.0.
I'm going to go manage my NuGet packages,
and I'm searching for Microsoft.entityframeworkcore.
I'm going to grab the Microsoft.EntityFrameworkCore.SqlServer
package and install it to my project.
Now that that's installed, I'm also going to
install Microsoft.EntityFrameworkCore.Design,
and Microsoft.EntityFrameworkCore.Tools.
To get started with Entity Framework Core,
we need to build an entity model.
By convention, this is usually stored in a folder called models.
We're going to create the first table,
probably the simplest one, products.
So we've added an empty class,
and I'm going to use Visual Studio
snippet feature to save some typing.
Looking at the product class as we've built it,
the first thing that I want to call out is this first property ID.
In Entity Framework Core,
ID is a special identifier that
indicates that this property is to be
treated as the primary key in the table that gets built.
It doesn't have to just be ID,
it can be table name followed by ID,
or it can be anything we want it to be and we mark
the property with the key attribute
to indicate that it's a primary key.
The other two properties on this class are name,
which we've marked as required using a data attribute,
and also price, which we've indicated
is a decimal with two decimal points of precision.
The next class we're going to add will be the customer class.
The customer class looks a little bit
different because this time we're using
the nullable reference type feature of
C# to indicate which fields allowed nulls and which ones don't.
Since FirstName and LastName are not nullable strings,
Entity Framework knows that when it creates the table,
those two columns should not allow nulls.
The address and phone properties
on the other hand are nullable strings,
so Entity Framework will allow nulls in those columns.
Finally, the last property on the class called
orders is a collection of order objects.
We haven't created the order class yet,
we're going to do that in just a second.
This is called a navigation property,
and it indicates that a customer may have zero or more orders.
This creates a one-to-many relationship
in the database that gets generated.
Creating the empty orders class,
I'll again use a snippet to populate my properties in the class.
This shouldn't introduce any new concepts.
We have our ID property,
our order placed property which is a date time,
an order fulfilled property that gets
populated when the order is actually fulfilled,
and we've implemented that is a nullable DateTime,
so the database will allow nulls in that column.
We also have a customer object
which is another type of navigation property,
one customer per order.
We have a customer ID property which represents
the foreign key relationship to
the customer table that will be generated.
If we didn't include the customer ID property,
it's okay, Entity Framework Core
would create it anyway as a shadow property.
Finally, we have another navigation property
to point to our intersection table, ProductOrders.
The final class we're going to create is the intersection table.
The intersection table productorder
facilitates the many-to-many relationship.
It has navigation properties for both order and product.
Just as with the other class,
the orderId and productId represent
foreign key relationships and aren't strictly required.
Now we're going to create a database contexts class.
By convention, this typically goes in a folder called data.
I'm going to name my class ContosoPetsContext.
ContosoPetsContext derives from DBContext.
Think of DBContext as representing a session with the database.
On the DBContext derived class,
we have four properties of type DBSet.
Each DBSet represents the table
that will be created in the database.
Finally, we've overridden the OnConfiguring method
to include some configuration information.
Since we're using the SQL Server package,
we have a use SQL Server extension method available to us
that indicates to Entity Framework that we're using SQL Server.
We pass in the connection string, and by the way,
you should probably never hardcode your connection string,
we're just doing this for demonstration purposes.
So now that we've created our entity model,
we're going to create something called a migration.
Migrations are tools that make it
easy to create and evolve our database.
I'm going to use the Package Manager Console to
run that ad migration commandlet.
I'm going to name my migration InitialCreate.
Let's take a look at the generated code.
Unlike some generated code,
this code is ours to maintain.
We should look it over to make sure it's accurate
and that it creates the table the way we want it to be created.
Looking at for example at the products table,
we can see where it's creating our identity column,
our primary key, our name which is not nullable,
and our price which is
a decimal with two decimal points of precision.
So now that we're satisfied that the migration is correct,
we'll run the migration with the update database commandlet.
That's run. So let's take a look at the database that was created.
The first table we're going to look
at is this one that we didn't create at all,
this EF migration history.
This table was used by Entity Framework Core,
so it knows which migrations have been run against this database.
Let's look at the products table.
It looks like the products table was
generated exactly as we intended.
Let's also look at customer.
The customer table was also generated pretty much as we expected,
except I realized that I forgot to add an e-mail column.
Let's go back to the customer entity and
add up property for e-mail.
E-mail will be a nullable string.
Now that we've modified the customer entity,
we'll create another migration.
I'll name this one AddEmail.
If we look at this migration,
we see that it's pretty simple.
All it does is add a column.
Let's go ahead and run update database again,
to make sure that our database is up-to-date with our migrations.
As expected, the e-mail column has been added to the table.
So now that we've built our database context in our entity model,
let's do something with it.
To get started, I'm going to
add a few products to my products table.
The first thing I'm going to do is I'm going to use
a Using declaration to create
a new instance of ContosoPetsContext.
This Using declaration ensures that
the ContosoPetsContext object is
disposed off properly, when we're done using it.
The first product I'm going to add to
my table will be a squeaky bone.
You'll note that I create the squeaky bone object and then add
it to the products table on the DBContext incidence.
The next product I'm going to add will
be a three-pack of tennis balls.
Note that this one I added directly to the context,
I didn't have to add it to the products table.
That's because Entity Framework knows that this is
a product entity and
it knows that it belongs on the products table.
Finally, we're going to call save changes on the context.
Let's run it and see what happens.
As expected, two products have been added to the products table;
our squeaky dog bone and our tennis ball three-pack.
Well, now that we've added information,
we've created some entities,
let's try reading information from the database.
Using that same Contoso pets database context,
I'm going to query the products table using a Fluent API.
Fluent APIs use extension methods that chain
methods together and lambda expressions to specify the query.
In this case, we're looking for
any product where the price is greater than five,
and we're going to order by name.
Then we're just going to write it all out to the console.
If you don't like the Fluent API syntax,
you can also use the link syntax.
Link syntax is very similar to SQL code.
Let's replace the fluent API syntax with the link syntax.
Both of these methods are equivalent and
result in the same queries to the database.
As expected, our one product
whose price is greater than five shows up in the results.
Now that we've read data from the database,
let's try editing a record.
The editor record, first we have to get a reference to it.
We'll query the table looking
for any product whose name
is squeaky dog bone and take the first or default.
In the case that there's no record that
matches that name, we'll get a null.
So we'll check to see if the squeaky bone object
is a product and not null,
and if it is, we'll set the price to 799.
Finally, we'll save our changes.
Since we changed the price to greater than five,
squeaky dog bone shows up in the result set now.
The final thing we're going to show is how
to delete a record from the database.
To delete, you simply pass a reference to
the entity to the remove function on the database context.
That's how easy it is to use
Entity Framework Core to store your.NET objects in a database.
In the next video, we're going to show how
to use an existing database.
In the meantime, if you'd like to try an interactive tutorial for
Entity Framework Core, go to aka.ms/Learn-EF-Core.
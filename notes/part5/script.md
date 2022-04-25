# Part 5 Script

## Please note: This is the working script used for shooting. The final videos may contain variations and adjustments.

> Hi, friends! Welcome back to Entity Framework Core for Beginners. In this video, I'm going to show you some tips to get the most performance out of your EF Core applications.
>
> The first topic we're going to cover is change tracking. When EF Core queries a database, it stores a snapshot of the results set in memory. Any modifications you make to your entities are actually made against that snapshot, and then later written to the database. In read-only scenarios where there's no chance you'll actually want to write data back to the database, we can skip the snapshot and conserve system resources. Let's look at how to disable change tracking for a query.

I've got my ContosoPizza web app open, and I've set up my user secrets already. I'm going to disable change tracking on my Customer Index page, since that page is read-only. To disable change tracking on any results set, all we have to do is add the `AsNoTracking` method to the query. Now when we view the Customer Index view, EF Core will skip the snapshot.

> In our previous videos, we've looked at using navigation properties to load related entities. Entity Framework Core allows you to specify when those related entities are read from the database. We're going to look at two patterns for loading those entities: Eager loading and lazy loading.

We'll look at eager loading first. Here's that same Customer Index page. We're already using eager loading by way of the `Include` method. The `Include` method signals to EF Core that the related orders should be loaded on the same database query as the customers.

Sometimes, however, it might benefit our app's performance to wait to load the orders until they're actually needed. This is called lazy loading. To enable lazy loading, first I'm going to install the `Microsoft.EntityFrameworkCore.Proxies` package. I'm going to get rid of the `Include` method. `AsNoTracking` doesn't work with lazy loading, so I'll get rid of that too.

When I add the database context to the dependency injection container, I'm going to add `UseLazyLoadingProxies` to the options.

Finally, I'll go make sure the navigation properties are marked virtual so that Entity Framework Core can override them with the proxies that it generates.

Now I've enabled lazy loading, and the orders won't be requested from the database until they're actually needed by our code.

> When eager loading one-to-many datasets, EF Core defaults to using LEFT JOINs to get the entire dataset from the database in one query. This can lead to very large datasets when the data from the LEFT side of the JOIN is repeated for each record returned on the RIGHT side. This is known as a cartesian explosion, and it can be mitigated by using a feature called split queries. Split queries use multiple queries to get the same dataset.

I'm already running the app. The Customer Details page needs to use a lot of navigation properties. The debugger output shows the query that's sent to SQL Server. You can see that it's using one big query. To use a split query, all I need to do is add the `AsSplitQuery` method. Now I'll hot-reload the page. This time, instead of a single SQL query, there are three.

> Sometimes when working with Entity Framework Core, you need to use your own SQL rather than the SQL that it generates for you. Entity Framework Core makes this easy using the `FromSqlRaw` and `FromSqlInterpolated` methods.

Let's look at the Product detail page. That page is currently loading Customer data using a `Where` method. I'm going to use `FromSqlInterpolated` to specify my own SQL query to retrieve some customer information from the database. I'll use an interperpolated string containing raw SQL and passing in Customer ID.

Let's run it! After it launches, I'll drill down on a customer order to view a product.

Entity Framework Core takes care of converting this interpolated string to a parameterized SQL statement, which protects from SQL injection attacks.

> We've previously discussed how Entity Framework Core uses in-memory snapshots to track changes to our entities. If we happen to have an entity cached in the snapshot, we can save ourselves a trip to the database by looking it up with the `Find` or `FindAsync` methods.

In my Products Details page, I'm using `FirstOrDefaultAsync` to look up a product from the database by its primary key. Since I'm looking up an entity by primary key, I can instead use `FindAsync`. This checks the snapshot first before calling the database.

> Whenever we use a database context, there's a certain amount of overhead that goes into creating and destroying the object. We can bypass that overhead by using database context pooling to reuse our database context objects over and over again.

To use database context pooling, all we have to do is replace `AddDbContext` use the `AddDbContextPool` method. Now, our database contexts will be reused over and over again.

> This concludes Entity Framework Core for Beginners. Be sure to check out aka.ms/ef-core-101 for more great learning resources!
>
> Thanks for watching! 🙂
using ContosoPizza.Data;
using ContosoPizza.Models;

using ContosoPizzaContext context = new ContosoPizzaContext();

foreach (Customer c in context.Customers)
{
    Console.WriteLine($"Name: {c.FirstLast}");
}
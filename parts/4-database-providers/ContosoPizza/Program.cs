using ContosoPizza.Data;
using ContosoPizza.Models;

using ContosoPizzaContext context = new ContosoPizzaContext();

Product veggieSpecial = new Product()
{
    Name = "Veggie Special Pizza",
    Price = 9.99M
};
context.Products.Add(veggieSpecial);

Product deluxeMeat = new Product()
{
    Name = "Deluxe Meat Pizza",
    Price = 12.99M
};
context.Add(deluxeMeat);

context.SaveChanges();
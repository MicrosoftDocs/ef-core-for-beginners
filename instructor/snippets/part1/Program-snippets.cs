
#region addproducts

using ContosoPizzaContext context = new ContosoPizzaContext();

Product veggieSpecial = new Product()
{
   Name = "Veggie Special",
   Price = 9.99M
};
context.Products.Add(veggieSpecial);

Product meatLovers = new Product()
{
   Name = "Meat Lovers",
   Price = 12.99M
};
context.Add(meatLovers);

context.SaveChanges();

#endregion

#region displayproducts

var products = context.Products
                    .Where(p => p.Price >= 5.00m)
                    .OrderBy(p => p.Name);

foreach (Product p in products)
{
   Console.WriteLine($"Id:    {p.Id}");
   Console.WriteLine($"Name:  {p.Name}");
   Console.WriteLine($"Price: {p.Price}");
   Console.WriteLine(new string('-', 20));
}

#endregion

#region linqproduct

var products = from product in context.Products
               where product.Price > 5.00m
               orderby product.Name
               select product;

#endregion

#region updateproduct

var meatLovers = context.Products
                       .Where(p => p.Name == "Meat Lovers")
                       .FirstOrDefault();

if (meatLovers is Product)
{
   context.Remove(meatLovers);
}

context.SaveChanges();

#endregion
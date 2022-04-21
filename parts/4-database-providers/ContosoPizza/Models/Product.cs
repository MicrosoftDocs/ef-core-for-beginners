using System;
using System.Collections.Generic;

namespace ContosoPizza.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

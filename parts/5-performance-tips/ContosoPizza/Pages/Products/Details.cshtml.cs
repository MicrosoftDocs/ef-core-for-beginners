#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoPizza.Data;
using ContosoPizza.Models;

namespace ContosoPizza.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly ContosoPizza.Data.ContosoPizzaContext _context;

        public DetailsModel(ContosoPizza.Data.ContosoPizzaContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id, int customerId)
        {
            if (id == null)
            {
                return NotFound();
            }
            CustomerId = customerId;

            Product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);
            
            if (Product == null)
            {
                return NotFound();
            }

            if(CustomerId > 0)
            {
                Customer = await _context.Customers
                    .Where(c => c.Id == CustomerId)
                    .FirstOrDefaultAsync();
            }

            return Page();
        }
    }
}

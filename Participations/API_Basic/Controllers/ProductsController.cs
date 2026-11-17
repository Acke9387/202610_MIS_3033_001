using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Basic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> products = new List<Product>
{
    new Product { ProductId = 1, Name = "Wireless Mouse", Category = "Electronics", Price = 24.99m, InStock = true },
    new Product { ProductId = 2, Name = "Mechanical Keyboard", Category = "Electronics", Price = 89.99m, InStock = true },
    new Product { ProductId = 3, Name = "USB-C Hub", Category = "Electronics", Price = 50.00m, InStock = false },
    new Product { ProductId = 4, Name = "Wireless Headphones", Category = "Electronics", Price = 100.00m, InStock = true },
    new Product { ProductId = 5, Name = "Computer Monitor", Category = "Electronics", Price = 229.99m, InStock = false },
    new Product { ProductId = 6, Name = "Notebook", Category = "Office", Price = 3.49m, InStock = true },
    new Product { ProductId = 7, Name = "Gel Pen Set", Category = "Office", Price = 8.99m, InStock = false },
    new Product { ProductId = 8, Name = "Desk Organizer", Category = "Office", Price = 19.99m, InStock = true },
    new Product { ProductId = 9, Name = "Desk Lamp", Category = "Office", Price = 34.99m, InStock = true },
    new Product { ProductId = 10, Name = "Office Chair", Category = "Office", Price = 149.99m, InStock = false },
    new Product { ProductId = 11, Name = "Coffee Mug", Category = "Kitchen", Price = 9.99m, InStock = true },
    new Product { ProductId = 12, Name = "Measuring Cup Set", Category = "Kitchen", Price = 12.49m, InStock = true },
    new Product { ProductId = 13, Name = "Cutting Board", Category = "Kitchen", Price = 24.99m, InStock = false },
    new Product { ProductId = 14, Name = "Electric Kettle", Category = "Kitchen", Price = 49.99m, InStock = true },
    new Product { ProductId = 15, Name = "Air Fryer", Category = "Kitchen", Price = 119.99m, InStock = false },
    new Product { ProductId = 16, Name = "Crew Socks", Category = "Clothing", Price = 7.99m, InStock = true },
    new Product { ProductId = 17, Name = "Cotton T-Shirt", Category = "Clothing", Price = 14.99m, InStock = false },
    new Product { ProductId = 18, Name = "Baseball Cap", Category = "Clothing", Price = 19.99m, InStock = true },
    new Product { ProductId = 19, Name = "Hoodie", Category = "Clothing", Price = 50.00m, InStock = true },
    new Product { ProductId = 20, Name = "Rain Jacket", Category = "Clothing", Price = 79.99m, InStock = false },
    new Product { ProductId = 21, Name = "Water Bottle", Category = "Outdoors", Price = 15.99m, InStock = true },
    new Product { ProductId = 22, Name = "LED Flashlight", Category = "Outdoors", Price = 24.99m, InStock = false },
    new Product { ProductId = 23, Name = "Camping Chair", Category = "Outdoors", Price = 39.99m, InStock = true },
    new Product { ProductId = 24, Name = "Hiking Backpack", Category = "Outdoors", Price = 100.00m, InStock = false },
    new Product { ProductId = 25, Name = "Two-Person Tent", Category = "Outdoors", Price = 159.99m, InStock = true },
    new Product { ProductId = 26, Name = "Jump Rope", Category = "Fitness", Price = 9.99m, InStock = false },
    new Product { ProductId = 27, Name = "Resistance Bands", Category = "Fitness", Price = 19.99m, InStock = true },
    new Product { ProductId = 28, Name = "Yoga Mat", Category = "Fitness", Price = 29.99m, InStock = true },
    new Product { ProductId = 29, Name = "Kettlebell", Category = "Fitness", Price = 54.99m, InStock = false },
    new Product { ProductId = 30, Name = "Adjustable Dumbbell Set", Category = "Fitness", Price = 249.99m, InStock = true }
};



        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);

        }

        [HttpGet("search")]
        public ActionResult<List<Product>> SearchProducts([FromQuery] string? category, [FromQuery] decimal? maxPrice)
        {
          
            if (maxPrice.HasValue && maxPrice < 0)
            {
                return BadRequest("maxPrice must be a non-negative value.");
            }

            var filteredProducts = products.AsEnumerable();
            
            if (!string.IsNullOrEmpty(category))
            {
                filteredProducts = filteredProducts.Where(p => p.Category == category);
            }

            if (maxPrice.HasValue)
            {
                filteredProducts = filteredProducts.Where(p => p.Price <= maxPrice.Value);
            }


            return Ok(filteredProducts.ToList());
        }

        [HttpGet("instock")]
        public ActionResult<List<Product>> GetInStockProducts()
        {
            var inStockProducts = products.Where(p => p.InStock).ToList();
            return Ok(inStockProducts);
        }


    }
}


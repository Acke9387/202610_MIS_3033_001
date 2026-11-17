namespace API_Basic
{
    public class Product
    {

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }

        public Product()
        {
            ProductId = 0;
            Name = string.Empty;
            Category = string.Empty;
            Price = 0.0m;
            InStock = false;
        }

    }
}
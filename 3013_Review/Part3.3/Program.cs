

using Newtonsoft.Json;
using Part3._3;

string jsonFile = File.ReadAllText("product_catalog.json");

List<Product> products = JsonConvert.DeserializeObject<List<Product>>(jsonFile);

DisplayProducts(products);

File.WriteAllText("filtered_product_catalog.json", JsonConvert.SerializeObject(products, Formatting.Indented));

void DisplayProducts(List<Product> products, string category = "All", double minPrice = 0)
{
	foreach (var item in products)
	{

        if (
            (category == "All" || item.Category == category) 
        && item.Price >= minPrice)
        {
            Console.WriteLine(item);
        }

    }
}
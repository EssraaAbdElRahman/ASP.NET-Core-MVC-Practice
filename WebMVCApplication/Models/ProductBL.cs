namespace WebMVCApplication.Models
{
    public class ProductBL
    {
        List<Product> Products;
        public ProductBL()
        {
            Products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Price = 10.99m, Description = "Description for Product 1", ImageURL = "product1.jpeg" },
                new Product { Id = 2, Name = "Product 2", Price = 20.99m, Description = "Description for Product 2", ImageURL = "product2.jpeg" },
                new Product { Id = 3, Name = "Product 3", Price = 30.99m, Description = "Description for Product 3", ImageURL = "product3.jpeg" }
            };
        }
        public List<Product> GetProducts()
        {
            return Products;
        }
        public Product GetProductById(int id) 
        {
            return Products.FirstOrDefault(p => p.Id == id);
        }



    }
}

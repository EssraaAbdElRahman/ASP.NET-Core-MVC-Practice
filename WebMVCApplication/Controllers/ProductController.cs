using Microsoft.AspNetCore.Mvc;
using WebMVCApplication.Models;

namespace WebMVCApplication.Controllers
{
    public class ProductController : Controller
    {
        ProductBL productBL= new ProductBL();

        public IActionResult ShowProducts()
        {
            List<Product> products = productBL.GetProducts();
            return View(products);
        }
        public IActionResult Details(int id)
        {
            if (id != 0)
            {
                Product product = productBL.GetProductById(id);
                if (product != null)
                {
                    return View(product);
                }             
            }
            return NotFound();

        }
        public IActionResult Create()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using WebApplication30_Rohan_Phadtare_DotnetTask1_MVCCore_CollectionCRUD.Models;
namespace WebApplication30_Rohan_Phadtare_DotnetTask1_MVCCore_CollectionCRUD.Controllers
{
    public class ProductController : Controller
    {
        public static List<Product> Products = new List<Product>
        {
           new Product{Id=1,Name="Dell Laptop",Price=65000},
           new Product{Id=2,Name="HP Laptop",Price=62000},
            new Product{Id=3,Name="Acer Laptop",Price=56000},
        };
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DisplayAllProducts()
        {
            return View(Products);
        }
        public IActionResult DisplayAllProductsByID(int id)
        {
            var product=Products.FirstOrDefault(x=>x.Id==id);
            if(product == null)
            {
                return NotFound("Product Not Found");
            }
            else
            {
                return View(product);
            }
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]

        public IActionResult AddProduct(Product newproduct)
        {
            newproduct.Id=Products.Max(x=>x.Id)+1;
            Products.Add(newproduct);
            return RedirectToAction("DisplayAllProducts");
        }

        [HttpGet]
        public IActionResult UpdateProductPrice(int Id)
        {
            var product = Products.First(x => x.Id == Id);
            if (product == null)
            {

                return NotFound("Product not found");
            }
            return View(product);

        }

        [HttpPost]
        public IActionResult UpdateProductPrice(Product updateproduct)
        {
            var product = Products.FirstOrDefault(x => x.Id == updateproduct.Id);
            if (product != null)
            {
                product.Price = updateproduct.Price;

            }
            return RedirectToAction("DisplayAllProducts");
        }

        [HttpGet]
        public IActionResult DeleteProduct(int Id)
        {
            var product=Products.FirstOrDefault(x => x.Id == Id);
            if (product == null)
            {
                return NotFound("Not Found");
            }
            return View(product);

        }

        [HttpPost, ActionName("DeleteProduct")]

        public IActionResult DeleteConfirmed(int Id)
        {

            var product=Products.First(x => x.Id == Id);
            if(product != null)
            {
                Products.Remove(product);
            }
            return RedirectToAction("DisplayAllProducts");
        }

    }
}

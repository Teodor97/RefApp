using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RefApp.Services.DataServices;
using RefApp.Services.Models;
using RefApp.Services.Models.Home;

namespace RefApp.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IProductService productsService;

        public HomeController(IProductService productsService)
        {
            this.productsService = productsService;
        }

        public IActionResult Index(string category, string brand)
        {
            IEnumerable<IndexProductViewModel> products = null;
            if (category == null && brand == null)
            {
                products = this.productsService.GetRandomProducts(10);
            }
            else
            {
                if (category == null)
                {
                    products = this.productsService.GetProductsByBrand(brand);
                }
                else
                {
                    products = this.productsService.GetProductsByCategory(category);
                }

            }

            var viewModel = new IndexViewModel
            {
                Products = products,
            };

            return this.View(viewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = $"My application has {this.productsService.GetCount()} jokes.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

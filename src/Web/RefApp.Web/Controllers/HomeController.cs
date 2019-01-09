using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RefApp.Data.Models;
using RefApp.Services.DataServices;
using RefApp.Services.Models;
using RefApp.Services.Models.Home;

namespace RefApp.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IProductService productsService;
        public int PageSize = 6;

        public HomeController(IProductService productsService)
        {
            this.productsService = productsService;
        }

        public IActionResult Index(string category, int productPage = 1)
        {
            IEnumerable<IndexProductViewModel> products = null;
            if (!String.IsNullOrEmpty(category))
            {
                products = this.productsService.SetForPageByCategoryTerm(category, productPage, PageSize);
            }
            else products = this.productsService.SetForPage(productPage, PageSize);
            
            var viewModel = new IndexViewModel
            {
                Products = products,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? productsService.GetCount() : productsService.GetProductsByCategory(category).Count()
                },
                CurrentCategory = category
            };

            return this.View(viewModel);
        }
        public IActionResult Search(string searchString, int productPage = 1)
        {

            IEnumerable<IndexProductViewModel> products = null;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = this.productsService.SetForPageBySearchTerm(searchString, productPage, PageSize);
            }
            else products = this.productsService.SetForPage(productPage, PageSize);

            ViewData["CurrentTerm"] = searchString;
            TempData["FoundProductsCount"] = searchString == null ? productsService.GetCount() : productsService
                .GetProductsBySearch(searchString).Count();

            var viewModel = new IndexViewModel
            {
                Products = products,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = searchString == null ? productsService.GetCount() : productsService.GetProductsBySearch(searchString).Count()
                },
            };
            return View("Index",viewModel);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RefApp.Services.DataServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RefApp.Web.Model.Products;

namespace RefApp.Web.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService productsService;
        private readonly ICategoriesService categoriesService;

        public ProductController(
            IProductService productsService,
            ICategoriesService categoriesService)
        {
            this.productsService = productsService;
            this.categoriesService = categoriesService;
        }

        [Authorize]
        public IActionResult Create()
        {
            this.ViewData["Categories"] = this.categoriesService.GetAll()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.NameAndCount,
                });
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var id = await this.productsService.Create(input.CategoryId, input.Description, input.Name, input.Price);
            return this.RedirectToAction("Details", new { id = id });
        }

        public IActionResult Details(int id)
        {
            var product = this.productsService.GetProductById(id);
            return this.View(product);
        }
    }
}

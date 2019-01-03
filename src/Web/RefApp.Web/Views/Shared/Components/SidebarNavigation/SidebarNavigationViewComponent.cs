using Microsoft.AspNetCore.Mvc;
using RefApp.Data.Common;
using RefApp.Services.DataServices;
using RefApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefApp.Web.Views.Shared.Components.SidebarNavigation
{
    [ViewComponentAttribute]
    public class SidebarNavigationViewComponent : ViewComponent
    {
        private readonly ICategoriesService categoriesService;
        private readonly IBrandService brandService;

        public SidebarNavigationViewComponent(ICategoriesService categoriesService, IBrandService brandService)
        {
            this.categoriesService = categoriesService;
            this.brandService = brandService;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            ViewBag.SelectedBrand = RouteData?.Values["brand"];
            var categories = categoriesService
                .GetAll()
                .Select(x => x.Name)
                .Distinct()
                .OrderBy(x => x);
            var brands = brandService
                .GetAll()
                .Select(x => x.Name)
                .Distinct()
                .OrderBy(x => x);

            var cb = new CategoriesAndBrandsSideBarViewModel
            {
                Brands = brands,
                Categories = categories

            };
            return View(cb);
        }
    }
}

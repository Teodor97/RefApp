using Microsoft.AspNetCore.Mvc;
using RefApp.Data.Common;
using RefApp.Services.DataServices;
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

        public SidebarNavigationViewComponent(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            return View(categoriesService
                .GetAll()
                .Select(x => x.Name)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}

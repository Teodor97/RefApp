using Microsoft.AspNetCore.Mvc;
using RefApp.Web.Model.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefApp.Web.Views.Shared.Components.CartDetails
{
    [ViewComponentAttribute]
    public class CartDetailsViewComponent:ViewComponent
    {
        private readonly Cart cartService;

        public CartDetailsViewComponent(Cart cartService)
        {
            this.cartService = cartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(cartService);
        }
    }
}

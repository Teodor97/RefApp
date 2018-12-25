using RefApp.Services.DataServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RefApp.Web.Common;
using RefApp.Web.Model.Cart;
using RefApp.Data.Models;
using RefApp.Web.Model.Cart.ViewModel;

namespace RefApp.Web.Controllers
{
    public class CartController:BaseController
    {
        private readonly IProductService productService;
        private readonly Cart cart;

        public CartController(
            IProductService productService,
            Cart cartService)
        {
            this.productService = productService;
            this.cart = cartService;
        }
        public ViewResult Index(string returnUrl)
        {
            return View(new CartViewIndexModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            var product = productService.ProductById(productId);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {
            var product = productService.ProductById(productId);
            if (product != null)
            {
                cart.RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        private Cart GetCart()
        {
            Cart cart = this.HttpContext.Session.GetJson<Cart>("CartLine") ?? new Cart();
            return cart;
        }
        private void SaveCart(Cart cart)
        {
            this.HttpContext.Session.SetJson("CartLine", cart);
        }
    }
}

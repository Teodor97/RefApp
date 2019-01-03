using Microsoft.AspNetCore.Mvc;
using RefApp.Data;
using RefApp.Data.Models;
using RefApp.Web.Model.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefApp.Web.Controllers
{
    public class OrderController:BaseController
    {
        private readonly IOrderRepository orderService;
        private readonly Cart cartService;

        public OrderController(IOrderRepository orderService, Cart cartService)
        {
            this.orderService = orderService;
            this.cartService = cartService;
        }
        public ViewResult Checkout()
        {
            return this.View(new Order());
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cartService.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                order.Lines = cartService.Lines.ToArray();
                orderService.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }
        }
        public ViewResult Completed()
        {
            cartService.ClearCart();
            return View();
        }

        public ViewResult List()
        {
            return this.View(orderService.Orders.Where(o => o.IsShipped == false));
        }

        [HttpPost]
        public IActionResult MarkShipped(int orderId)
        {
            var order = this.orderService.Orders.Where(o => o.Id == orderId).FirstOrDefault();
            if (order != null)
            {
                order.IsShipped = true;
                orderService.SaveOrder(order);
            }

            return this.RedirectToAction(nameof(this.List));
        }
    }
}

using RefApp.Data.Models;
using RefApp.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace RefApp.Services.Models.Cart
{
    public class CartLine
    {
        public int CartId { get; set; }
        public int Quantity { get; set; }

        public Data.Models.Product Product { get; set; }
    }
}

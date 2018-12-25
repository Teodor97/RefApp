using System;
using System.Collections.Generic;
using System.Text;
using RefApp.Services.Mapping;

namespace RefApp.Services.Models.Product
{
    public class ProductDetailsViewModel : IMapFrom<RefApp.Data.Models.Product>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }
    }
}

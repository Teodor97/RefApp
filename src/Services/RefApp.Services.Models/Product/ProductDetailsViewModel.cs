using System;
using System.Collections.Generic;
using System.Text;
using RefApp.Services.Mapping;

namespace RefApp.Services.Models.Product
{
    public class ProductDetailsViewModel : IMapFrom<RefApp.Data.Models.Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ShortDescription { get; set; }

        public int Stock { get; set; }

        public string BrandName { get; set; }

        public string Model { get; set; }

        public string ImagePath { get; set; }

        public string ProductInformation { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }
    }
}

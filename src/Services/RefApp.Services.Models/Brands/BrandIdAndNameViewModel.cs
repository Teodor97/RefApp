using RefApp.Data.Models;
using RefApp.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace RefApp.Services.Models.Brands
{
    public class BrandIdAndNameViewModel:IMapFrom<Brand>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

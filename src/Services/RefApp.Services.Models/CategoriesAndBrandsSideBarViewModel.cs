using RefApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RefApp.Services.Models
{
    public class CategoriesAndBrandsSideBarViewModel
    {
        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<string> Brands { get; set; }
    }
}

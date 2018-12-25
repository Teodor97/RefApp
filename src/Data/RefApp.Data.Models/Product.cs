using RefApp.Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace RefApp.Data.Models
{
    public class Product : BaseModel<int>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}

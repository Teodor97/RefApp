using RefApp.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RefApp.Data.Models
{
    public class Product : BaseModel<int>
    {
        [Required(ErrorMessage = "Name of product is required!")]
        [MinLength(3, ErrorMessage = "Name must be atleast 3 characters long!")]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        [MinLength(20)]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}

using RefApp.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RefApp.Data.Models
{
    public class Brand : BaseModel<int>
    {
        public Brand()
        {
            this.Products = new HashSet<Product>();
        }

        [Required(ErrorMessage = "Name of brand is required!")]
        [MinLength(3, ErrorMessage = "Name must be atleast 3 characters long!")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

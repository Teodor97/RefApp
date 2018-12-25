using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using RefApp.Data.Common;

namespace RefApp.Data.Models
{
    public class Category : BaseModel<int>
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }

        [Required(ErrorMessage = "Name of category is required!")]
        [MinLength(3,ErrorMessage = "Name must be atleast 3 characters long!")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

using RefApp.Services.Models;
using System.ComponentModel.DataAnnotations;

namespace RefApp.Web.Model.Products
{
    public class CreateProductInputModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
        

        [Required]
        [MinLength(20)]
        public string Description { get; set; }

        [ValidCategoryId]
        public int CategoryId { get; set; }
    }
}

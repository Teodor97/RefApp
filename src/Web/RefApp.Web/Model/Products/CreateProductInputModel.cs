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
        public int Stock { get; set; }

        [Required]
        public int BrandId { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string ImagePath { get; set; }

        public string ShortDescription { get; set; }

        public string ProductInformation { get; set; }

        [Required]
        [MinLength(20)]
        public string Description { get; set; }

        [ValidCategoryId]
        public int CategoryId { get; set; }
    }
}

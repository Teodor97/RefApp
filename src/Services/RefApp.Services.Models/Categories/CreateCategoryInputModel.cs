using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RefApp.Services.Models.Categories
{
    public class CreateCategoryInputModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using RefApp.Services.DataServices;

namespace RefApp.Services.Models
{
    public class ValidCategoryIdAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var service = (ICategoriesService) validationContext
                .GetService(typeof(ICategoriesService));

            if (service.IsCategoryIdValid((int) value))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Invalid category id!");
            }
        }
    }
}
using System.Collections.Generic;
using System.Text;
using RefApp.Services.Models.Categories;

namespace RefApp.Services.DataServices
{
    public interface ICategoriesService
    {
        IEnumerable<CategoryIdAndNameViewModel> GetAll();

        bool IsCategoryIdValid(int categoryId);
    }
}

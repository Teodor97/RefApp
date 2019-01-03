using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RefApp.Services.Models.Categories;

namespace RefApp.Services.DataServices
{
    public interface ICategoriesService
    {
        IEnumerable<CategoryIdAndNameViewModel> GetAll();

        bool IsCategoryIdValid(int categoryId);

        Task<int> Create(string name);
    }
}

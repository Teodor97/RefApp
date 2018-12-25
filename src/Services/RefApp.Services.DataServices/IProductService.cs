using System.Collections.Generic;
using System.Threading.Tasks;
using RefApp.Data.Models;
using RefApp.Services.Models.Home;
using RefApp.Services.Models.Product;

namespace RefApp.Services.DataServices
{
    public interface IProductService
    {
        IEnumerable<IndexProductViewModel> GetRandomProducts(int count);

        int GetCount();

        Task<int> Create(int categoryId, string description, string name, decimal price);

        ProductDetailsViewModel GetProductById(int id);
        IEnumerable<IndexProductViewModel> GetProductsByCategory(string category);
        Product ProductById(int productId);

        IEnumerable<Product> GetAllProducts();

        void SaveProduct(Product product);

        Product DeleteProduct(int productId);
    }
}
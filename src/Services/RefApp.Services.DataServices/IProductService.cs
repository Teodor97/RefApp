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

        Task<int> Create(int categoryId, string description,
            string shortDescription, int brandId,
            string model, string imagePath,
            string productInformation, int stock,
            string name, decimal price);

        ProductDetailsViewModel GetProductById(int id);
        IEnumerable<IndexProductViewModel> GetProductsByCategory(string category);
        IEnumerable<IndexProductViewModel> GetProductsByBrand(string brand);
        Product ProductById(int productId);

        IEnumerable<Product> GetAllProducts();

        void SaveProduct(Product product);

        Product DeleteProduct(int productId);
    }
}
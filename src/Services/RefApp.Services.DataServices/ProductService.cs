using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefApp.Data.Common;
using RefApp.Data.Models;
using RefApp.Services.Mapping;
using RefApp.Services.Models.Home;
using RefApp.Services.Models.Product;
using Remotion.Linq.Utilities;

namespace RefApp.Services.DataServices
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> productsRepository;
        private readonly IRepository<Category> categoriesRepository;

        public ProductService(
            IRepository<Product> productsRepository,
            IRepository<Category> categoriesRepository)
        {
            this.productsRepository = productsRepository;
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<IndexProductViewModel> GetRandomProducts(int count)
        {
            var products = this.productsRepository.All()
                .OrderBy(x => Guid.NewGuid())
                .To<IndexProductViewModel>().Take(count).ToList();

            return products;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            var products = this.productsRepository.All().ToList();

            return products;
        }

        public int GetCount()
        {
            return this.productsRepository.All().Count();
        }

        public async Task<int> Create(int categoryId, string description, string name, decimal price)
        {
            var product = new Product
            {
                CategoryId = categoryId,
                Name = name,
                Price = price,
                Description = description

            };

            await this.productsRepository.AddAsync(product);
            await this.productsRepository.SaveChangesAsync();

            return product.Id;
        }

        public Product ProductById(int productId)
        {
            var product = this.productsRepository.All().Where(p => p.Id == productId).FirstOrDefault();
            return product;
        }
        public ProductDetailsViewModel GetProductById(int id)
        {
            
            var product = this.productsRepository.All().Where(x => x.Id == id)
                .To<ProductDetailsViewModel>()
                .FirstOrDefault();
            return product;
        }

        public IEnumerable<IndexProductViewModel> GetProductsByCategory(string category)
        {
            var products = this.productsRepository.All().Where(p => p.Category == null || p.Category.Name == category).To<IndexProductViewModel>().ToList();
            return products;
        }

        public void SaveProduct(Product product)
        {
            if (product.Id == 0)
            {
                productsRepository.AddAsync(product);
            }
            else
            {
                Product dbEntry = productsRepository.All()
                .FirstOrDefault(p => p.Id == product.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.CategoryId = product.CategoryId;
                }
            }
            productsRepository.SaveChanges();
        }

        public Product DeleteProduct(int productId)
        {
            Product dbEntry = productsRepository.All()
            .FirstOrDefault(p => p.Id == productId);
            if (dbEntry != null)
            {
                productsRepository.Delete(dbEntry);
                productsRepository.SaveChanges();
            }
            return dbEntry;
        }
    }
}

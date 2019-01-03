using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefApp.Data.Common;
using RefApp.Data.Models;
using RefApp.Services.Mapping;
using RefApp.Services.Models.Brands;

namespace RefApp.Services.DataServices
{
    public class BrandService : IBrandService
    {
        private readonly IRepository<Brand> brandRepository;

        public BrandService(IRepository<Brand> brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public async Task<int> Create(string name)
        {
            var brand = new Brand
            {
                Name = name
            };

            await this.brandRepository.AddAsync(brand);
            await this.brandRepository.SaveChangesAsync();

            return brand.Id;
        }

        public IEnumerable<BrandIdAndNameViewModel> GetAll()
        {
            var brand = this.brandRepository.All().OrderBy(x => x.Name)
            .To<BrandIdAndNameViewModel>().ToList();

            return brand;
        }

        public bool IsBrandIdValid(int brandId)
        {
            return this.brandRepository.All().Any(x => x.Id == brandId);
        }
    }
}

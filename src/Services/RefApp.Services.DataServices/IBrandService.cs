using RefApp.Services.Models.Brands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RefApp.Services.DataServices
{
    public interface IBrandService
    {
        IEnumerable<BrandIdAndNameViewModel> GetAll();

        bool IsBrandIdValid(int brandId);

        Task<int> Create(string name);
    }
}

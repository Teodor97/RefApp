using AutoMapper;
using RefApp.Data.Models;
using RefApp.Services.Mapping;

namespace RefApp.Services.Models.Home
{
    public class IndexProductViewModel : IMapFrom<Data.Models.Product>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ShortDescription { get; set; }

        public int Stock { get; set; }

        public string ImagePath { get; set; }

        public string CategoryName { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Data.Models.Product, IndexProductViewModel>().ForMember(x => x.ShortDescription, x => x.MapFrom(j => j.ShortDescription));
            // configuration.CreateMap<Joke, IndexProductViewModel>().ForMember(x => x.CategoryName, x => x.MapFrom(j => j.Category.Name))
        }
    }
}

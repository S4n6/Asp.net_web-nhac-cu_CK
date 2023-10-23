using AutoMapper;
using netframe.DTO;
using netframe.Models;

namespace netframe.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }

    }
}

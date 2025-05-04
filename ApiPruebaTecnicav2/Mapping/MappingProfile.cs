using APIPruebaTecnicav2.Models;
using ApiPruebaTecnicav2.Dtos;
using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CrearProductDto, Product>();
        CreateMap<ActualizarProductDto, Product>();
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

        CreateMap<CrearCategoryDto, Category>();
        CreateMap<Category, CategoriaDto>();
    }
}

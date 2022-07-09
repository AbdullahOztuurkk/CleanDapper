using AutoMapper;
using DapperORM.Application.Commands;
using DapperORM.Application.Queries;
using DapperORM.Domain.Entities;

namespace DapperORM.Application.MappingConfiguration
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            //Commands
            CreateMap<Product, CreateProductCommandRequest>().ReverseMap();
            CreateMap<Product, DeleteProductCommandRequest>().ReverseMap();
            CreateMap<Category, CreateCategoryCommandRequest>().ReverseMap();
            CreateMap<Category, DeleteCategoryCommandRequest>().ReverseMap();

            //Queries
            CreateMap<Product, GetProductQueryRequest>().ReverseMap();
            CreateMap<Product, GetAllProductQueryRequest>().ReverseMap();
            CreateMap<Category, GetCategoryQueryRequest>().ReverseMap();
            CreateMap<Category, GetAllCategoryQueryRequest>().ReverseMap();
        }
    }
}

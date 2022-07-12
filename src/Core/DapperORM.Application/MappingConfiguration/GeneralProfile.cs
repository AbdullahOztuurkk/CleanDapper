using AutoMapper;
using DapperORM.Application.Features.Commands.CreateEvent;
using DapperORM.Application.Features.Commands.DeleteEvent;
using DapperORM.Application.Features.Commands.UpdateEvent;
using DapperORM.Application.Features.Queries.GetAllEvent;
using DapperORM.Application.Features.Queries.GetEvent;
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
            CreateMap<Product, UpdateProductCommandRequest>().ReverseMap();
            CreateMap<Category, CreateCategoryCommandRequest>().ReverseMap();
            CreateMap<Category, DeleteCategoryCommandRequest>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommandRequest>().ReverseMap();

            //Queries
            CreateMap<Product, GetProductQueryRequest>().ReverseMap();
            CreateMap<Product, GetAllProductQueryRequest>().ReverseMap();
            CreateMap<Product, GetProductByCategoryQueryRequest>().ReverseMap();
            CreateMap<Category, GetCategoryQueryRequest>().ReverseMap();
            CreateMap<Category, GetAllCategoryQueryRequest>().ReverseMap();
        }
    }
}

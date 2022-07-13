using AutoMapper;
using DapperORM.Application.Features.Commands.CreateEvent;
using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Application.MappingConfiguration;
using DapperORM.Application.Validations.Create;
using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Constants;
using MediatR;
using Moq;
using NUnit.Framework;
using System.Drawing;
using System.Threading.Tasks;

namespace DapperORM.Tests
{
    /// <summary>
    /// This class contains all product validations
    /// </summary>
    public class ProductTests
    {
        private Mock<IProductRepository> MockProductRepository;
        private CreateProductValidator createValidator;
        private CreateProductCommandHandler handler;
        private CreateProductCommandRequest request;
        private IMapper mapper;

        [SetUp]
        public void Setup()
        {
            MockProductRepository = new Mock<IProductRepository>();
            createValidator = new CreateProductValidator();

            var mapperConfig = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new GeneralProfile());
            });

            mapper = mapperConfig.CreateMapper();

            handler = new CreateProductCommandHandler(
                MockProductRepository.Object,
                createValidator,
                mapper);
        }

        [Test]
        public async Task AddProduct_IfInvalidName_MustThrownErrorResult()
        {
            //Product instance without name property
            request = new CreateProductCommandRequest 
            {
                Color = nameof(KnownColor.Control),
                QuantityPerUnit = 100,
                UnitPrice = 200,
                UnitsInStock = 5
            };

            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.IsInstanceOf<IResult>(result);
            Assert.IsFalse(result.IsSuccess);
            Assert.AreSame(ValidationMessages.Product_Name_Length_Error, result.Message);
        }

        [Test]
        public async Task AddProduct_IfInvalidColor_MustThrownErrorResult()
        {
            //Product instance without color property
            request = new CreateProductCommandRequest
            {
                Name = "Test Product",
                QuantityPerUnit = 100,
                UnitPrice = 200,
                UnitsInStock = 5
            };

            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.IsInstanceOf<IResult>(result);
            Assert.IsFalse(result.IsSuccess);
            Assert.AreSame(ValidationMessages.Product_Color_Must_be_Known_Color, result.Message);
        }

        [Test]
        public async Task AddProduct_IfInvalidUnitPrice_MustThrownErrorResult()
        {
            //Product instance without unit-price property
            request = new CreateProductCommandRequest
            {
                Name = "Test Product",
                QuantityPerUnit = 100,
                Color = "Control",
                UnitsInStock = 5
            };

            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.IsInstanceOf<IResult>(result);
            Assert.IsFalse(result.IsSuccess);
            Assert.AreSame(ValidationMessages.Product_Price_Must_Greater_Than_Or_Equal_To_Zero, result.Message);
        }

        [Test]
        public async Task AddProduct_IfInvalidQuantity_MustThrownErrorResult()
        {
            //Product instance without unit-price property
            request = new CreateProductCommandRequest
            {
                Name = "Test Product",
                UnitPrice = 100,
                Color = "Control",
                UnitsInStock = 5
            };

            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.IsInstanceOf<IResult>(result);
            Assert.IsFalse(result.IsSuccess);
            Assert.AreSame(ValidationMessages.Product_Quantity_Must_Greater_Than_Zero, result.Message);
        }

        [Test]
        public async Task AddProduct_IfInvalidStock_MustThrownErrorResult()
        {
            //Product instance without unit-price property
            request = new CreateProductCommandRequest
            {
                Name = "Test Product",
                UnitPrice = 100,
                Color = "Control",
                QuantityPerUnit = 5
            };

            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.IsInstanceOf<IResult>(result);
            Assert.IsFalse(result.IsSuccess);
            Assert.AreSame(ValidationMessages.Product_Stock_Must_Greater_Than_Zero, result.Message);
        }
    }
}
using AutoMapper;
using DapperORM.Application.Features.Commands.CreateEvent;
using DapperORM.Application.Features.Commands.DeleteEvent;
using DapperORM.Application.Features.Commands.UpdateEvent;
using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Application.MappingConfiguration;
using DapperORM.Application.Validations.Create;
using DapperORM.Application.Validations.Delete;
using DapperORM.Application.Validations.Update;
using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Constants;
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
        }

        [Test]
        public async Task AddProduct_IfInvalidName_MustThrownErrorResult()
        {
            //Product instance without name property
            CreateProductCommandRequest request = new CreateProductCommandRequest 
            {
                Color = nameof(KnownColor.Control),
                QuantityPerUnit = 100,
                UnitPrice = 200,
                UnitsInStock = 5
            };

            CreateProductCommandHandler handler = handler = new CreateProductCommandHandler(
                MockProductRepository.Object,
                createValidator,
                mapper);

            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.IsInstanceOf<IResult>(result);
            Assert.IsFalse(result.IsSuccess);
            Assert.AreSame(ValidationMessages.Product_Name_Length_Error, result.Message);
        }

        [Test]
        public async Task AddProduct_IfInvalidColor_MustThrownErrorResult()
        {
            //Product instance without color property
            CreateProductCommandRequest request = new CreateProductCommandRequest
            {
                Name = "Test Product",
                QuantityPerUnit = 100,
                UnitPrice = 200,
                UnitsInStock = 5
            };

            CreateProductCommandHandler handler = handler = new CreateProductCommandHandler(
                MockProductRepository.Object,
                createValidator,
                mapper);

            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.IsInstanceOf<IResult>(result);
            Assert.IsFalse(result.IsSuccess);
            Assert.AreSame(ValidationMessages.Product_Color_Must_be_Known_Color, result.Message);
        }

        [Test]
        public async Task AddProduct_IfInvalidUnitPrice_MustThrownErrorResult()
        {
            //Product instance without unit-price property
            CreateProductCommandRequest request = new CreateProductCommandRequest
            {
                Name = "Test Product",
                QuantityPerUnit = 100,
                Color = "Control",
                UnitsInStock = 5
            };

            CreateProductCommandHandler handler = handler = new CreateProductCommandHandler(
                MockProductRepository.Object,
                createValidator,
                mapper);

            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.IsInstanceOf<IResult>(result);
            Assert.IsFalse(result.IsSuccess);
            Assert.AreSame(ValidationMessages.Product_Price_Must_Greater_Than_Or_Equal_To_Zero, result.Message);
        }

        [Test]
        public async Task AddProduct_IfInvalidQuantity_MustThrownErrorResult()
        {
            //Product instance without unit-price property
            CreateProductCommandRequest request = new CreateProductCommandRequest
            {
                Name = "Test Product",
                UnitPrice = 100,
                Color = "Control",
                UnitsInStock = 5
            };

            CreateProductCommandHandler handler = handler = new CreateProductCommandHandler(
                MockProductRepository.Object,
                createValidator,
                mapper);

            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.IsInstanceOf<IResult>(result);
            Assert.IsFalse(result.IsSuccess);
            Assert.AreSame(ValidationMessages.Product_Quantity_Must_Greater_Than_Zero, result.Message);
        }

        [Test]
        public async Task AddProduct_IfInvalidStock_MustThrownErrorResult()
        {
            //Product instance without units-in-stock property
            CreateProductCommandRequest request = new CreateProductCommandRequest
            {
                Name = "Test Product",
                UnitPrice = 100,
                Color = "Control",
                QuantityPerUnit = 5
            };

            CreateProductCommandHandler handler = handler = new CreateProductCommandHandler(
                MockProductRepository.Object,
                createValidator,
                mapper);

            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.IsInstanceOf<IResult>(result);
            Assert.IsFalse(result.IsSuccess);
            Assert.AreSame(ValidationMessages.Product_Stock_Must_Greater_Than_Zero, result.Message);
        }

        [Test]
        public async Task DeleteProduct_IfInvalidIdentifierNumber_MustThrownErrorResult()
        {
            //Delete request without identifier number property
            DeleteProductCommandRequest request = new DeleteProductCommandRequest { };

            DeleteProductCommandHandler handler = handler = new DeleteProductCommandHandler(
                MockProductRepository.Object,
                mapper,
                new DeleteProductValidator());

            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.IsInstanceOf<IResult>(result);
            Assert.IsFalse(result.IsSuccess);
            Assert.AreSame(ValidationMessages.Id_Cannot_Be_Empty, result.Message);
        }

        [Test]
        public async Task UpdateProduct_IfInvalidIdentifierNumber_MustThrownErrorResult()
        {
            //Delete request without identifier number property
            UpdateProductCommandRequest request = new UpdateProductCommandRequest 
            {
                Name = "Test Product",
                UnitPrice = 100,
                Color = "Control",
                UnitsInStock = 5,
                QuantityPerUnit = 1
            };

            UpdateProductCommandHandler handler = handler = new UpdateProductCommandHandler(
                MockProductRepository.Object,
                mapper,
                new UpdateProductValidator());

            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.IsInstanceOf<IResult>(result);
            Assert.IsFalse(result.IsSuccess);
            Assert.AreSame(ValidationMessages.Id_Cannot_Be_Empty, result.Message);
        }
    }
}
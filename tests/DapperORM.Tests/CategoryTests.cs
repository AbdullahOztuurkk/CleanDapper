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
using System.Threading.Tasks;

namespace DapperORM.Tests
{
    public class CategoryTests
    {
        private Mock<ICategoryRepository> MockCategoryRepository;
        private CreateCategoryValidator createCategoryValidator;
        private IMapper mapper;

        [SetUp]
        public void Setup()
        {
            MockCategoryRepository = new Mock<ICategoryRepository>();
            createCategoryValidator = new CreateCategoryValidator();

            var mapperConfig = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new GeneralProfile());
            });

            mapper = mapperConfig.CreateMapper();
        }

        [Test]
        public async Task AddCategory_IfInvalidName_MustThrownErrorResult()
        {
            //Category instance without name property
            CreateCategoryCommandRequest request = new CreateCategoryCommandRequest
            {
                Description = Faker.Lorem.Sentence(5),
            };

            CreateCategoryCommandHandler handler = new CreateCategoryCommandHandler(
                MockCategoryRepository.Object,
                createCategoryValidator,
                mapper);

            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.IsInstanceOf<IResult>(result);
            Assert.IsFalse(result.IsSuccess);
            Assert.AreSame(ValidationMessages.Category_Name_Length_Error, result.Message);
        }

        [Test]
        public async Task AddCategory_IfInvalidDescription_MustThrownErrorResult()
        {
            //Category instance without name property
            CreateCategoryCommandRequest request = new CreateCategoryCommandRequest
            {
                Name = Faker.Name.First(),
            };

            CreateCategoryCommandHandler handler = new CreateCategoryCommandHandler(
                MockCategoryRepository.Object,
                createCategoryValidator,
                mapper);

            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.IsInstanceOf<IResult>(result);
            Assert.IsFalse(result.IsSuccess);
            Assert.AreSame(ValidationMessages.Category_Description_Length_Error, result.Message);
        }

        [Test]
        public async Task DeleteCategory_IfInvalidIdentifierNumber_MustThrownErrorResult()
        {
            //Category instance without name property
            DeleteCategoryCommandRequest request = new DeleteCategoryCommandRequest { };

            DeleteCategoryCommandHandler handler = new DeleteCategoryCommandHandler(
                MockCategoryRepository.Object,
                mapper,
                new DeleteCategoryValidator());

            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.IsInstanceOf<IResult>(result);
            Assert.IsFalse(result.IsSuccess);
            Assert.AreSame(ValidationMessages.Id_Cannot_Be_Empty, result.Message);
        }

        [Test]
        public async Task UpdateCategory_IfInvalidIdentifierNumber_MustThrownErrorResult()
        {
            //Category instance without name property
            UpdateCategoryCommandRequest request = new UpdateCategoryCommandRequest { };

            UpdateCategoryCommandHandler handler = new UpdateCategoryCommandHandler(
                MockCategoryRepository.Object,
                mapper,
                new UpdateCategoryValidator());

            var result = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.IsInstanceOf<IResult>(result);
            Assert.IsFalse(result.IsSuccess);
            Assert.AreSame(ValidationMessages.Id_Cannot_Be_Empty, result.Message);
        }
    }
}

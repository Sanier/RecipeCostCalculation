using Microsoft.Extensions.Logging;
using NUnit.Framework.Internal;
using RecipeCostCalculation.DAL.Repositories;
using RecipeCostCalculation.Domain.Entities;
using RecipeCostCalculation.Domain.Enums;
using RecipeCostCalculation.Domain.Models;
using RecipeCostCalculation.Service.Implementations;

namespace RecipeCostCalculation.Tests.ServiceTests
{
    [TestFixture]
    public class ProductServiceTests
    {

        private FakeProductRepositories _fridgeRepository;
        private ProductService _fridgeService;
        private ILogger<ProductService> _logger;

        [SetUp]
        public void Setup()
        {
            _fridgeRepository = new FakeProductRepositories();
            _fridgeService = new ProductService(_fridgeRepository, _logger);
        }

        [Test]
        public async Task Create_ValidModel_ReturnsSuccess()
        {
            var fridgeModel = new CreateProductModel
            {
                Id = 2,
                Name = "Pomidoro",
                Count = "3",
                Price = 200d,
                EnergyValue = 200d,
                ExpirationDate = DateTime.Now.ToString()
            };

            var result = await _fridgeService.Create(fridgeModel);

            Assert.That(result, Is.Not.Null);

            Assert.That(result.StatusCode, Is.EqualTo(StatusCode.Success));
        }

        [Test]
        public async Task Create_NullProducts()
        {
            var result = await _fridgeService.Create(null);

            Assert.That(result.Description, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(StatusCode.InternalServerError));
            Assert.That(result.Data, Is.Empty);
        }

        [Test]
        public async Task GetProductsInFridge_ReturnsSuccessResponse()
        {
            var fridgeModel = new ProductEntity
            {
                Id = 2,
                Name = "Pomidoro",
                Count = "3",
                Price = 200d,
                EnergyValue = 200d,
                DateOfManufacture = DateTime.Now,
                ExpirationDate = DateTime.Now
            };

            await _fridgeRepository.Create(fridgeModel);

            var result = await _fridgeService.GetProductsInFridge();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(StatusCode.Success));
            Assert.That(result.Data, Is.Not.Empty);
        }

        [Test]
        public async Task Delete_Valid_Products()
        {
            var fridgeModel = new ProductEntity
            {
                Id = 1,
                Name = "Pomidoro",
                Count = "3",
                Price = 200d,
                EnergyValue = 200d,
                DateOfManufacture = DateTime.Now,
                ExpirationDate = DateTime.Now
            };
            var fridgeEntity = new ProductEntity
            {
                Id = 2,
                Name = "Potatoes",
                Count = "2",
                Price = 25d,
                EnergyValue = 20d,
                DateOfManufacture = DateTime.Now,
                ExpirationDate = DateTime.Now
            };

            await _fridgeRepository.Create(fridgeModel);
            await _fridgeRepository.Create(fridgeEntity);

            var result = await _fridgeService.DeleteProductsInFridge(fridgeModel.Id);

            Assert.That(result.Data, Is.Null);
            Assert.That(result.StatusCode, Is.EqualTo(StatusCode.Success));
            Assert.That(result.Description, Is.Not.Empty);
        }

        [Test]
        public async Task Delete_InValid_Products()
        {
            var result = await _fridgeService.DeleteProductsInFridge(0);

            Assert.That(result.Data, Is.Null);
            Assert.That(result.StatusCode, Is.EqualTo(StatusCode.InternalServerError));
            Assert.That(result.Description, Is.Not.Empty);
        }

        [Test]
        public async Task ChangeProductsInFridge_ReturnsSuccessResponse()
        {
            var fridgeModel = new ProductEntity
            {
                Id = 2,
                Name = "Pomidoro",
                Count = "3",
                Price = 200d,
                EnergyValue = 200d
            };

            await _fridgeRepository.Create(fridgeModel);

            var list = new AvailableProductsModel
            {
                Id = 2,
                Name = "Pomidoro",
                Count = "3",
                Price = 100d,
                EnergyValue = 20d
            };

            var result = await _fridgeService.ChangeProductsInFridge(list);

            Assert.That(result.Data, Is.Null);
            Assert.That(result.StatusCode, Is.EqualTo(StatusCode.Success));
            Assert.That(result.Description, Is.Not.Empty);
        }

        [Test]
        public async Task ChangeProductsInFridge_ReturnsErrorResponse()
        {
            var result = await _fridgeService.ChangeProductsInFridge(null);

            Assert.That(result.Data, Is.Null);
            Assert.That(result.StatusCode, Is.EqualTo(StatusCode.InternalServerError));
            Assert.That(result.Description, Is.Not.Empty);
        }
    }
}

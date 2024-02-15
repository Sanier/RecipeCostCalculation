using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework.Internal;
using RecipeCostCalculation.DAL.Interfaces;
using RecipeCostCalculation.DAL.Repositories;
using RecipeCostCalculation.Domain.Entities;
using RecipeCostCalculation.Domain.Enums;
using RecipeCostCalculation.Domain.Models;
using RecipeCostCalculation.Service.Implementations;
using RecipeCostCalculation.Service.Interfaces;

namespace RecipeCostCalculation.Tests.ServiceTests
{
    [TestFixture]
    public class FridgeServiceTests
    {

        private FakeFridgeRepositories _fridgeRepository;
        private FridgeService _fridgeService;
        private ILogger<FridgeService> _logger;

        [SetUp]
        public void Setup()
        {
            _fridgeRepository = new FakeFridgeRepositories();
            _fridgeService = new FridgeService(_fridgeRepository, _logger);
        }

        [Test]
        public async Task Create_ValidModel_ReturnsSuccess()
        {
            var fridgeModel = new CreateFridgeModel
            {
                Id = 2,
                Name = "Pomidoro",
                Count = "3",
                Price = 200d,
                EnergyValue = 200d,
                DateOfManufacture = DateTime.Now.ToString(),
                ExpirationDate = DateTime.Now.ToString()
            };

            var result = await _fridgeService.Create(fridgeModel);

            Assert.That(result, Is.Not.Null);

            Assert.That(result.StatusCode, Is.EqualTo(StatusCode.Success));
        }

        [Test]
        public async Task CreateNullProducts()
        {
            var result = await _fridgeService.Create(null);

            Assert.That(result.Description, Is.Not.Null);

            Assert.That(result.StatusCode, Is.EqualTo(StatusCode.InternalServerError));
        }

        [Test]
        public async Task GetProductsInFridge_ReturnsSuccessResponse()
        {
            var fridgeModel = new FridgeEntity
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
    }
}

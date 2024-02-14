using RecipeCostCalculation.Domain.Entities;
using RecipeCostCalculation.DAL.Repositories;

namespace RecipeCostCalculation.Tests.DbTests
{
    [TestFixture]
    public class FakeFridgeRepositoriesTests
    {
        private FakeFridgeRepositories _repository;
        private FridgeEntity _fridgeEntity;

        [SetUp]
        public void SetUp()
        {
            _repository = new FakeFridgeRepositories();
            _fridgeEntity = new FridgeEntity
            {
                Id = 1,
                Name = "Potatoes",
                Count = "2",
                Price = 25d,
                EnergyValue = 20d,
                DateOfManufacture = DateTime.Now,
                ExpirationDate = DateTime.Now
            };
        }

        [Test]
        public async Task CreateEntity()
        {
            await _repository.Create(_fridgeEntity);

            Assert.Contains(_fridgeEntity, _repository.GetAll().ToList());
        }

        [Test]
        public async Task DeleteEntity()
        {
            await _repository.Create(_fridgeEntity);
            await _repository.Delete(_fridgeEntity);

            Assert.That(_repository.GetAll().ToList(), Does.Not.Contain(_fridgeEntity));
        }

        [Test]
        public async Task UpdateEntity()
        {
            await _repository.Create(_fridgeEntity);
            var updateEntity = new FridgeEntity
            {
                Id = 1,
                Name = "Potatoes",
                Count = "1",
                Price = 45d,
                EnergyValue = 25d,
                DateOfManufacture = DateTime.Now,
                ExpirationDate = DateTime.Now
            };
            var result = await _repository.Update(updateEntity);

            Assert.That(result, Is.EqualTo(updateEntity));
        }
    }
}

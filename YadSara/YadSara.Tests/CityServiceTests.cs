using Microsoft.Extensions.Logging;
using Moq;
using YadSara.Core.Entities;
using YadSara.Core.Repositories;
using YadSara.Service;
using Xunit;

namespace YadSara.Tests
{
    public class CityServiceTests
    {
        private readonly Mock<ICityRepository> _repository = new();
        private readonly CityService _sut;

        public CityServiceTests()
        {
            _sut = new CityService(_repository.Object, Mock.Of<ILogger<CityService>>());
        }

        [Fact]
        public async Task GetCityAsync_WhenFound_ReturnsCity()
        {
            var city = new City(1, "בני ברק");
            _repository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(city);

            var result = await _sut.GetCityAsync(1);

            Assert.Equal(city, result);
        }

        [Fact]
        public async Task AddCityAsync_WhenDuplicateKey_PropagatesException()
        {
            var city = new City(1, "בני ברק");
            _repository.Setup(r => r.AddAsync(city)).ThrowsAsync(new InvalidOperationException("duplicate"));

            await Assert.ThrowsAsync<InvalidOperationException>(() => _sut.AddCityAsync(city));
        }

        [Fact]
        public async Task DeleteCityAsync_DelegatesToRepositoryAndReturnsResult()
        {
            _repository.Setup(r => r.DeleteAsync(1)).ReturnsAsync(true);

            var result = await _sut.DeleteCityAsync(1);

            Assert.True(result);
            _repository.Verify(r => r.DeleteAsync(1), Times.Once);
        }
    }
}

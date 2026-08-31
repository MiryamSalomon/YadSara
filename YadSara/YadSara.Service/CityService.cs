using Microsoft.Extensions.Logging;
using YadSara.Core.Entities;
using YadSara.Core.Repositories;
using YadSara.Core.Services;

namespace YadSara.Service
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly ILogger<CityService> _logger;

        public CityService(ICityRepository cityRepository, ILogger<CityService> logger)
        {
            _cityRepository = cityRepository;
            _logger = logger;
        }

        public Task<List<City>> GetListAsync() => _cityRepository.GetAllAsync();

        public Task<City?> GetCityAsync(int id) => _cityRepository.GetByIdAsync(id);

        public async Task<City> UpdateCityAsync(City city)
        {
            var updated = await _cityRepository.UpdateAsync(city);
            _logger.LogInformation("Updated city {CityId}", city.CityId);
            return updated;
        }

        public async Task<bool> DeleteCityAsync(int id)
        {
            var deleted = await _cityRepository.DeleteAsync(id);
            if (deleted)
            {
                _logger.LogInformation("Deleted city {CityId}", id);
            }
            else
            {
                _logger.LogWarning("Attempted to delete non-existent city {CityId}", id);
            }
            return deleted;
        }

        public async Task<City> AddCityAsync(City city)
        {
            var added = await _cityRepository.AddAsync(city);
            _logger.LogInformation("Added city {CityId}", added.CityId);
            return added;
        }
    }
}

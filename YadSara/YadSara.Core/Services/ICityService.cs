using YadSara.Core.Entities;

namespace YadSara.Core.Services
{
    public interface ICityService
    {
        Task<List<City>> GetListAsync();
        Task<City?> GetCityAsync(int id);
        Task<City> UpdateCityAsync(City c);
        Task<bool> DeleteCityAsync(int id);
        Task<City> AddCityAsync(City city);
    }
}

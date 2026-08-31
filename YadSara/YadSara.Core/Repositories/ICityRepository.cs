using YadSara.Core.Entities;

namespace YadSara.Core.Repositories
{
    public interface ICityRepository
    {
        Task<List<City>> GetAllAsync();
        Task<City?> GetByIdAsync(int id);
        Task<City> UpdateAsync(City c);
        Task<bool> DeleteAsync(int id);
        Task<City> AddAsync(City city);
    }
}

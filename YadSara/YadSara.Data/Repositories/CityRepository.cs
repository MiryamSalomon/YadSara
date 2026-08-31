using Microsoft.EntityFrameworkCore;
using YadSara.Core.Entities;
using YadSara.Core.Repositories;

namespace YadSara.Data.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly DataContext _context;

        public CityRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<City>> GetAllAsync()
        {
            return await _context.City.AsNoTracking().ToListAsync();
        }

        public async Task<City?> GetByIdAsync(int id)
        {
            return await _context.City.FindAsync(id);
        }

        public async Task<City> UpdateAsync(City c)
        {
            var existing = await _context.City.FindAsync(c.CityId)
                ?? throw new KeyNotFoundException($"City with id '{c.CityId}' was not found.");

            existing.CityName = c.CityName;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.City.FindAsync(id);
            if (existing == null)
            {
                return false;
            }

            _context.City.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<City> AddAsync(City city)
        {
            _context.City.Add(city);
            await _context.SaveChangesAsync();
            return city;
        }
    }
}

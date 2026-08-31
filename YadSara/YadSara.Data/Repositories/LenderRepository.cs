using Microsoft.EntityFrameworkCore;
using YadSara.Core.Entities;
using YadSara.Core.Repositories;

namespace YadSara.Data.Repositories
{
    public class LenderRepository : ILenderRepository
    {
        private readonly DataContext _context;

        public LenderRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Lender>> GetAllAsync()
        {
            return await _context.Lender.AsNoTracking().ToListAsync();
        }

        public async Task<Lender?> GetByIdAsync(string id)
        {
            return await _context.Lender.FindAsync(id);
        }

        public async Task<Lender> UpdateAsync(Lender lender)
        {
            var existing = await _context.Lender.FindAsync(lender.lenderId)
                ?? throw new KeyNotFoundException($"Lender with id '{lender.lenderId}' was not found.");

            existing.lenderName = lender.lenderName;
            existing.lenderPhone = lender.lenderPhone;
            existing.lenderAdress = lender.lenderAdress;
            existing.lenderCityId = lender.lenderCityId;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var existing = await _context.Lender.FindAsync(id);
            if (existing == null)
            {
                return false;
            }

            _context.Lender.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Lender> AddAsync(Lender lender)
        {
            _context.Lender.Add(lender);
            await _context.SaveChangesAsync();
            return lender;
        }
    }
}

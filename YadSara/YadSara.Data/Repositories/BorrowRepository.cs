using Microsoft.EntityFrameworkCore;
using YadSara.Core.Entities;
using YadSara.Core.Repositories;

namespace YadSara.Data.Repositories
{
    public class BorrowRepository : IBorrowRepository
    {
        private readonly DataContext _context;

        public BorrowRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Borrow>> GetAllAsync()
        {
            return await _context.Borrow.AsNoTracking().ToListAsync();
        }

        public async Task<Borrow?> GetByIdAsync(string id)
        {
            return await _context.Borrow.FindAsync(id);
        }

        public async Task<Borrow> UpdateAsync(Borrow borrow)
        {
            var existing = await _context.Borrow.FindAsync(borrow.borrowId)
                ?? throw new KeyNotFoundException($"Borrow with id '{borrow.borrowId}' was not found.");

            existing.borrowName = borrow.borrowName;
            existing.address = borrow.address;
            existing.phone = borrow.phone;
            existing.cityId = borrow.cityId;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var existing = await _context.Borrow.FindAsync(id);
            if (existing == null)
            {
                return false;
            }

            _context.Borrow.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Borrow> AddAsync(Borrow borrow)
        {
            _context.Borrow.Add(borrow);
            await _context.SaveChangesAsync();
            return borrow;
        }
    }
}

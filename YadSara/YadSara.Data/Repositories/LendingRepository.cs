using Microsoft.EntityFrameworkCore;
using YadSara.Core.Entities;
using YadSara.Core.Repositories;

namespace YadSara.Data.Repositories
{
    public class LendingRepository : ILendingRepository
    {
        private readonly DataContext _context;

        public LendingRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Lending>> GetAllAsync()
        {
            return await _context.Lending.AsNoTracking().ToListAsync();
        }

        public async Task<List<Lending>> GetByTimeAsync(DateTime dateTime)
        {
            return await _context.Lending.AsNoTracking()
                .Where(l => l.TimeLending.Equals(dateTime))
                .ToListAsync();
        }

        public async Task<List<Lending>> GetByLandBAsync(string borrowId, string lenderId)
        {
            return await _context.Lending.AsNoTracking()
                .Where(l => l.borrowId == borrowId && l.lenderId == lenderId)
                .ToListAsync();
        }

        public async Task<Lending?> GetByIdAsync(int id)
        {
            return await _context.Lending.FindAsync(id);
        }

        public async Task<Lending> UpdateAsync(Lending lending)
        {
            var existing = await _context.Lending.FindAsync(lending.LendingId)
                ?? throw new KeyNotFoundException($"Lending with id '{lending.LendingId}' was not found.");

            existing.TimeLending = lending.TimeLending;
            existing.deadlineLending = lending.deadlineLending;
            existing.IsReturned = lending.IsReturned;
            existing.IdEquipment = lending.IdEquipment;
            existing.lenderId = lending.lenderId;
            existing.borrowId = lending.borrowId;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Lending.FindAsync(id);
            if (existing == null)
            {
                return false;
            }

            _context.Lending.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Lending> AddAsync(Lending lending)
        {
            _context.Lending.Add(lending);
            await _context.SaveChangesAsync();
            return lending;
        }
    }
}

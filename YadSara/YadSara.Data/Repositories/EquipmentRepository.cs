using Microsoft.EntityFrameworkCore;
using YadSara.Core.Entities;
using YadSara.Core.Repositories;

namespace YadSara.Data.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly DataContext _context;

        public EquipmentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Equipment>> GetAllAsync()
        {
            return await _context.Equipment.AsNoTracking().ToListAsync();
        }

        public async Task<Equipment?> GetByIdAsync(int id)
        {
            return await _context.Equipment.FindAsync(id);
        }

        public async Task<Equipment> UpdateAsync(Equipment equipment)
        {
            var existing = await _context.Equipment.FindAsync(equipment.idEquipment)
                ?? throw new KeyNotFoundException($"Equipment with id '{equipment.idEquipment}' was not found.");

            existing.nameEquipment = equipment.nameEquipment;
            existing.nameEquipmentck = equipment.nameEquipmentck;
            existing.currentquantity = equipment.currentquantity;
            existing.deposit = equipment.deposit;
            existing.lenderId = equipment.lenderId;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Equipment.FindAsync(id);
            if (existing == null)
            {
                return false;
            }

            _context.Equipment.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Equipment> AddAsync(Equipment equipment)
        {
            _context.Equipment.Add(equipment);
            await _context.SaveChangesAsync();
            return equipment;
        }
    }
}

using YadSara.Core.Entities;

namespace YadSara.Core.Repositories
{
    public interface IEquipmentRepository
    {
        Task<List<Equipment>> GetAllAsync();
        Task<Equipment?> GetByIdAsync(int id);
        Task<Equipment> UpdateAsync(Equipment equipment);
        Task<bool> DeleteAsync(int id);
        Task<Equipment> AddAsync(Equipment equipment);
    }
}

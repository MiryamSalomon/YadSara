using YadSara.Core.Entities;

namespace YadSara.Core.Services
{
    public interface IEquipmentService
    {
        Task<List<Equipment>> GetListAsync();
        Task<Equipment?> GetEquipmentAsync(int id);
        Task<Equipment> UpdateEquipmentAsync(Equipment e);
        Task<bool> DeleteEquipmentAsync(int id);
        Task<Equipment> AddEquipmentAsync(Equipment equipment);
    }
}

using Microsoft.Extensions.Logging;
using YadSara.Core.Entities;
using YadSara.Core.Repositories;
using YadSara.Core.Services;

namespace YadSara.Service
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly ILogger<EquipmentService> _logger;

        public EquipmentService(IEquipmentRepository equipmentRepository, ILogger<EquipmentService> logger)
        {
            _equipmentRepository = equipmentRepository;
            _logger = logger;
        }

        public Task<List<Equipment>> GetListAsync() => _equipmentRepository.GetAllAsync();

        public Task<Equipment?> GetEquipmentAsync(int id) => _equipmentRepository.GetByIdAsync(id);

        public async Task<Equipment> UpdateEquipmentAsync(Equipment equipment)
        {
            var updated = await _equipmentRepository.UpdateAsync(equipment);
            _logger.LogInformation("Updated equipment {EquipmentId}", equipment.idEquipment);
            return updated;
        }

        public async Task<bool> DeleteEquipmentAsync(int id)
        {
            var deleted = await _equipmentRepository.DeleteAsync(id);
            if (deleted)
            {
                _logger.LogInformation("Deleted equipment {EquipmentId}", id);
            }
            else
            {
                _logger.LogWarning("Attempted to delete non-existent equipment {EquipmentId}", id);
            }
            return deleted;
        }

        public async Task<Equipment> AddEquipmentAsync(Equipment equipment)
        {
            var added = await _equipmentRepository.AddAsync(equipment);
            _logger.LogInformation("Added equipment {EquipmentId}", added.idEquipment);
            return added;
        }
    }
}

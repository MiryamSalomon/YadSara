using Microsoft.Extensions.Logging;
using YadSara.Core.Entities;
using YadSara.Core.Repositories;
using YadSara.Core.Services;

namespace YadSara.Service
{
    public class LendingService : ILendingService
    {
        private readonly ILendingRepository _lendingRepository;
        private readonly ILogger<LendingService> _logger;

        public LendingService(ILendingRepository lendingRepository, ILogger<LendingService> logger)
        {
            _lendingRepository = lendingRepository;
            _logger = logger;
        }

        public Task<List<Lending>> GetListAsync() => _lendingRepository.GetAllAsync();

        public Task<List<Lending>> GetListByDateAsync(DateTime date) => _lendingRepository.GetByTimeAsync(date);

        public Task<List<Lending>> GetListLandBAsync(string borrowId, string lenderId) =>
            _lendingRepository.GetByLandBAsync(borrowId, lenderId);

        public Task<Lending?> GetLendingAsync(int id) => _lendingRepository.GetByIdAsync(id);

        public async Task<Lending> UpdateLendingAsync(Lending lending)
        {
            var updated = await _lendingRepository.UpdateAsync(lending);
            _logger.LogInformation("Updated lending {LendingId}", lending.LendingId);
            return updated;
        }

        public async Task<bool> DeleteLendingAsync(int id)
        {
            var deleted = await _lendingRepository.DeleteAsync(id);
            if (deleted)
            {
                _logger.LogInformation("Deleted lending {LendingId}", id);
            }
            else
            {
                _logger.LogWarning("Attempted to delete non-existent lending {LendingId}", id);
            }
            return deleted;
        }

        public async Task<Lending> AddLendingAsync(Lending lending)
        {
            var added = await _lendingRepository.AddAsync(lending);
            _logger.LogInformation("Added lending {LendingId}", added.LendingId);
            return added;
        }
    }
}

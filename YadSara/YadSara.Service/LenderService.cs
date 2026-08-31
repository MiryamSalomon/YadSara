using Microsoft.Extensions.Logging;
using YadSara.Core.Entities;
using YadSara.Core.Repositories;
using YadSara.Core.Services;

namespace YadSara.Service
{
    public class LenderService : ILenderService
    {
        private readonly ILenderRepository _lenderRepository;
        private readonly ILogger<LenderService> _logger;

        public LenderService(ILenderRepository lenderRepository, ILogger<LenderService> logger)
        {
            _lenderRepository = lenderRepository;
            _logger = logger;
        }

        public Task<List<Lender>> GetListAsync() => _lenderRepository.GetAllAsync();

        public Task<Lender?> GetLenderAsync(string id) => _lenderRepository.GetByIdAsync(id);

        public async Task<Lender> UpdateLenderAsync(Lender lender)
        {
            var updated = await _lenderRepository.UpdateAsync(lender);
            _logger.LogInformation("Updated lender {LenderId}", lender.lenderId);
            return updated;
        }

        public async Task<bool> DeleteLenderAsync(string id)
        {
            var deleted = await _lenderRepository.DeleteAsync(id);
            if (deleted)
            {
                _logger.LogInformation("Deleted lender {LenderId}", id);
            }
            else
            {
                _logger.LogWarning("Attempted to delete non-existent lender {LenderId}", id);
            }
            return deleted;
        }

        public async Task<Lender> AddLenderAsync(Lender lender)
        {
            var added = await _lenderRepository.AddAsync(lender);
            _logger.LogInformation("Added lender {LenderId}", added.lenderId);
            return added;
        }
    }
}

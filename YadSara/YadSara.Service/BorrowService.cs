using Microsoft.Extensions.Logging;
using YadSara.Core.Entities;
using YadSara.Core.Repositories;
using YadSara.Core.Services;

namespace YadSara.Service
{
    public class BorrowService : IBorrowService
    {
        private readonly IBorrowRepository _borrowRepository;
        private readonly ILogger<BorrowService> _logger;

        public BorrowService(IBorrowRepository borrowRepository, ILogger<BorrowService> logger)
        {
            _borrowRepository = borrowRepository;
            _logger = logger;
        }

        public Task<List<Borrow>> GetListAsync() => _borrowRepository.GetAllAsync();

        public Task<Borrow?> GetBorrowAsync(string id) => _borrowRepository.GetByIdAsync(id);

        public async Task<Borrow> UpdateBorrowAsync(Borrow borrow)
        {
            var updated = await _borrowRepository.UpdateAsync(borrow);
            _logger.LogInformation("Updated borrow {BorrowId}", borrow.borrowId);
            return updated;
        }

        public async Task<bool> DeleteBorrowAsync(string id)
        {
            var deleted = await _borrowRepository.DeleteAsync(id);
            if (deleted)
            {
                _logger.LogInformation("Deleted borrow {BorrowId}", id);
            }
            else
            {
                _logger.LogWarning("Attempted to delete non-existent borrow {BorrowId}", id);
            }
            return deleted;
        }

        public async Task<Borrow> AddBorrowAsync(Borrow borrow)
        {
            var added = await _borrowRepository.AddAsync(borrow);
            _logger.LogInformation("Added borrow {BorrowId}", added.borrowId);
            return added;
        }
    }
}

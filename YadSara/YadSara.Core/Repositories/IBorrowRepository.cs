using YadSara.Core.Entities;

namespace YadSara.Core.Repositories
{
    public interface IBorrowRepository
    {
        Task<List<Borrow>> GetAllAsync();
        Task<Borrow?> GetByIdAsync(string id);
        Task<Borrow> UpdateAsync(Borrow borrow);
        Task<bool> DeleteAsync(string id);
        Task<Borrow> AddAsync(Borrow borrow);
    }
}

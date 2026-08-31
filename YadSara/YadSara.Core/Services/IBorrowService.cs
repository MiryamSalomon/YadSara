using YadSara.Core.Entities;

namespace YadSara.Core.Services
{
    public interface IBorrowService
    {
        Task<List<Borrow>> GetListAsync();
        Task<Borrow?> GetBorrowAsync(string id);
        Task<Borrow> UpdateBorrowAsync(Borrow borrow);
        Task<bool> DeleteBorrowAsync(string id);
        Task<Borrow> AddBorrowAsync(Borrow borrow);
    }
}

using YadSara.Core.Entities;

namespace YadSara.Core.Repositories
{
    public interface ILenderRepository
    {
        Task<List<Lender>> GetAllAsync();
        Task<Lender?> GetByIdAsync(string id);
        Task<Lender> UpdateAsync(Lender lender);
        Task<bool> DeleteAsync(string id);
        Task<Lender> AddAsync(Lender lender);
    }
}

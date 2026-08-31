using YadSara.Core.Entities;

namespace YadSara.Core.Repositories
{
    public interface ILendingRepository
    {
        Task<List<Lending>> GetAllAsync();
        Task<List<Lending>> GetByTimeAsync(DateTime dateTime);
        Task<List<Lending>> GetByLandBAsync(string borrowId, string lenderId);
        Task<Lending?> GetByIdAsync(int id);
        Task<Lending> UpdateAsync(Lending lending);
        Task<bool> DeleteAsync(int id);
        Task<Lending> AddAsync(Lending lending);
    }
}

using YadSara.Core.Entities;

namespace YadSara.Core.Services
{
    public interface ILendingService
    {
        Task<List<Lending>> GetListAsync();
        Task<List<Lending>> GetListByDateAsync(DateTime date);
        Task<List<Lending>> GetListLandBAsync(string borrowId, string lenderId);
        Task<Lending?> GetLendingAsync(int id);
        Task<Lending> UpdateLendingAsync(Lending lending);
        Task<bool> DeleteLendingAsync(int id);
        Task<Lending> AddLendingAsync(Lending lending);
    }
}

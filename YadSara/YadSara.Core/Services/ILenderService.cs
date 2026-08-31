using YadSara.Core.Entities;

namespace YadSara.Core.Services
{
    public interface ILenderService
    {
        Task<List<Lender>> GetListAsync();
        Task<Lender?> GetLenderAsync(string id);
        Task<Lender> UpdateLenderAsync(Lender l);
        Task<bool> DeleteLenderAsync(string id);
        Task<Lender> AddLenderAsync(Lender lender);
    }
}

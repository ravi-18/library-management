using LibraryManagementApi.Models;

namespace LibraryManagementApi.Interfaces.Repositories
{
    public interface IBorrowTransactionRepository
    {
        Task<IEnumerable<BorrowTransaction>> GetAllAsync();
        Task<BorrowTransaction> GetByIdAsync(int id);
        Task AddAsync(BorrowTransaction borrowTransaction);
        Task UpdateAsync(BorrowTransaction borrowTransaction);
        Task DeleteAsync(int id);
    }
}

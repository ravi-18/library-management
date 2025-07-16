using LibraryManagementApi.Interfaces.Repositories;
using LibraryManagementApi.Models;

namespace LibraryManagementApi.Services.Repositories
{
    public class BorrowTransactionRepository : IBorrowTransactionRepository
    {
        public Task AddAsync(BorrowTransaction borrowTransaction)
        {
            throw new NotImplementedException();
        }
        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<BorrowTransaction>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public Task<BorrowTransaction> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task UpdateAsync(BorrowTransaction borrowTransaction)
        {
            throw new NotImplementedException();
        }
    }
}

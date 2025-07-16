using LibraryManagementApi.Interfaces.Repositories;
using LibraryManagementApi.Models;

namespace LibraryManagementApi.Services.Repositories
{
    public class FineRepository : IFineRepository
    {
        public Task AddAsync(Fine borrowTransaction)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Fine>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public Task<Fine> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task UpdateAsync(Fine borrowTransaction)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Fine>> IFineRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Fine> IFineRepository.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

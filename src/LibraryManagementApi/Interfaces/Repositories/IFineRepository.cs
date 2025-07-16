using LibraryManagementApi.Models;

namespace LibraryManagementApi.Interfaces.Repositories
{
    public interface IFineRepository
    {
        Task<IEnumerable<Fine>> GetAllAsync();
        Task<Fine> GetByIdAsync(int id);
        Task AddAsync(Fine borrowTransaction);
        Task UpdateAsync(Fine borrowTransaction);
        Task DeleteAsync(int id);
    }
}

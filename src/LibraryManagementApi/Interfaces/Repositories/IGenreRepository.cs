using LibraryManagementApi.Dtos.Genre;
using LibraryManagementApi.Models;

namespace LibraryManagementApi.Interfaces.Repositories
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetAllAsync();
        Task<Genre?> GetByIdAsync(Guid id);
        Task<Genre> AddAsync(GenreRequestDto genre);
        Task<Genre> UpdateAsync(GenreUpdateDto genre);
        Task DeleteAsync(Guid id);
    }
}

namespace LibraryManagementApi.Interfaces.Repositories
{
    using LibraryManagementApi.Dtos.Book;
    using LibraryManagementApi.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(Guid id);
        Task<Book> AddAsync(BookRequestDto book);
        Task<Book> UpdateAsync(BookUpdateDto book);
        Task DeleteAsync(Guid id);
    }
}
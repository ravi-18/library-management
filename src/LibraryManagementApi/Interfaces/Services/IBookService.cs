namespace LibraryManagementApi.Interfaces.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using LibraryManagementApi.Dtos.Book;

    public interface IBookService
    {
        Task<IEnumerable<BookResponseDto>> GetAllBooksAsync();
        Task<BookResponseDto> GetBookByIdAsync(Guid id);
        Task<BookResponseDto> AddBookAsync(BookRequestDto book);
        Task<BookResponseDto> UpdateBookAsync(BookUpdateDto book);
        Task DeleteBookAsync(Guid id);
    }
}
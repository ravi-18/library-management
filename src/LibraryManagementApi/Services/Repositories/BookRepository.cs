namespace LibraryManagementApi.Services.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using LibraryManagementApi.Data;
    using LibraryManagementApi.Dtos.Book;
    using LibraryManagementApi.Interfaces.Repositories;
    using LibraryManagementApi.Models;
    using Microsoft.EntityFrameworkCore;

    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BookRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await Task.FromResult(_dbContext.Books);
        }

        public async Task<Book?> GetByIdAsync(Guid id)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(e => e.Id == id);
            return book;
        }

        public async Task<Book> AddAsync(BookRequestDto book)
        {
            var newBook = new Book
            {
                Id = Guid.NewGuid(),
                Title = book.Title,
                ISBN = book.ISBN,
                Author = book.Author,
                Publisher = book.Publisher,
                YearPublished = book.YearPublished,
                Quantity = book.Quantity,
                Description = book.Description,
                CreatedAt = DateTime.UtcNow,
            };
            await _dbContext.Books.AddAsync(newBook);
            return newBook;
        }

        public async Task<Book> UpdateAsync(BookUpdateDto book)
        {
            var existingBook = await GetByIdAsync(book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.ISBN = book.ISBN;
                existingBook.Author = book.Author;
                existingBook.Publisher = book.Publisher;
                existingBook.YearPublished = book.YearPublished;
                existingBook.Quantity = book.Quantity;
                existingBook.Description = book.Description;
                existingBook.UpdatedAt = DateTime.UtcNow;
            }
            else
            {
                throw new Exception("Book not found.");
            }

            return existingBook;
        }

        public async Task DeleteAsync(Guid id)
        {
            var book = await GetByIdAsync(id);
            if (book != null)
            {
                _dbContext.Books.Remove(book);
            }
        }
    }
}
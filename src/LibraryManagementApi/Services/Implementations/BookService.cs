namespace LibraryManagementApi.Services.Implementations
{
    using AutoMapper;
    using LibraryManagementApi.Data;
    using LibraryManagementApi.Dtos.Book;
    using LibraryManagementApi.Interfaces.Repositories;
    using LibraryManagementApi.Interfaces.Services;
    using LibraryManagementApi.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using static System.Reflection.Metadata.BlobBuilder;

    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;

        public BookService(IBookRepository bookRepository, IMapper mapper, ApplicationDbContext dbContext)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<BookResponseDto>> GetAllBooksAsync()
        {

            var books = await _bookRepository.GetAllAsync();
            var result = _mapper.Map<List<BookResponseDto>>(books);
            
            return result;
        }

        public async Task<BookResponseDto> GetBookByIdAsync(Guid id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            var result = _mapper.Map<BookResponseDto>(book);
            return result;
        }

        public async Task<BookResponseDto> AddBookAsync(BookRequestDto book)
        {
            var trx = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                if (book == null)
                {
                    throw new ArgumentNullException(nameof(book), "Book cannot be null.");
                }
                if (string.IsNullOrWhiteSpace(book.Title) || string.IsNullOrWhiteSpace(book.Author))
                {
                    throw new ArgumentException("Book title and author cannot be empty.");
                }

                if (book.YearPublished.HasValue && book.YearPublished < 0)
                {
                    throw new ArgumentException("Year published cannot be negative.");
                }

                var newBook = await _bookRepository.AddAsync(book);
                await trx.CommitAsync();

                return _mapper.Map<BookResponseDto>(newBook);
            }
            catch (ArgumentNullException ex)
            {
                await trx.RollbackAsync();
                throw new Exception("Invalid book data provided.", ex);
            }
            catch (ArgumentException ex)
            {
                await trx.RollbackAsync();
                throw new Exception("Invalid book data provided.", ex);
            }
            catch (Exception ex)
            {
                await trx.RollbackAsync();
                throw new Exception("An error occurred while adding the book.", ex);
            }
        }

        public async Task<BookResponseDto> UpdateBookAsync(BookUpdateDto book)
        {
            var trx = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var updatedBook = await _bookRepository.UpdateAsync(book);
                await trx.CommitAsync();

                return _mapper.Map<BookResponseDto>(updatedBook);
            }
            catch (Exception ex)
            {
                await trx.RollbackAsync();
                throw new Exception("An error occurred while updating the book.", ex);
            }
        }

        public async Task DeleteBookAsync(Guid id)
        {
            var trx = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                await _bookRepository.DeleteAsync(id);
                await trx.CommitAsync();
            }
            catch (Exception ex)
            {
                await trx.RollbackAsync();
                throw new Exception("An error occurred while deleting the book.", ex);
            }
        }
    }
}
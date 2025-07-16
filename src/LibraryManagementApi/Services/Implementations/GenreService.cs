using AutoMapper;
using LibraryManagementApi.Data;
using LibraryManagementApi.Dtos.Genre;
using LibraryManagementApi.Interfaces.Repositories;
using LibraryManagementApi.Interfaces.Services;

namespace LibraryManagementApi.Services.Implementations
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public GenreService(IGenreRepository genreRepository, IMapper mapper, ApplicationDbContext context)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
            _context = context;
        }


        public async Task<GenreResponseDto> AddGenreAsync(GenreRequestDto genre)
        {
            var trx = await _context.Database.BeginTransactionAsync();
            try
            {
                if (genre == null)
                {
                    throw new ArgumentNullException(nameof(genre), "Genre cannot be null");
                }
                
                if (string.IsNullOrWhiteSpace(genre.Name))
                {
                    throw new ArgumentException("Genre name cannot be empty", nameof(genre.Name));
                }

                var newGenre = await _genreRepository.AddAsync(genre);
                if (newGenre == null)
                {
                    throw new Exception("Failed to create genre");
                }

                await _context.SaveChangesAsync();
                await trx.CommitAsync();

                return _mapper.Map<GenreResponseDto>(newGenre);
            }
            catch (ArgumentException ex)
            {
                await trx.RollbackAsync();
                throw new ArgumentException("Invalid genre data", ex);
            }
            catch (Exception ex)
            {
                await trx.RollbackAsync();
                throw new Exception("An error occurred while adding the genre", ex);
            }
        }

        public async Task DeleteGenreAsync(Guid id)
        {
            var trx = _context.Database.BeginTransactionAsync();
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Genre ID cannot be empty", nameof(id));
                }
                var genre = _genreRepository.GetByIdAsync(id);
                if (genre == null)
                {
                    throw new KeyNotFoundException($"Genre with ID {id} not found");
                }
                await _genreRepository.DeleteAsync(id);
                await _context.SaveChangesAsync();
                await trx.Result.CommitAsync();
            }
            catch (KeyNotFoundException ex)
            {
                await trx.Result.RollbackAsync();
                throw new Exception("Genre not found", ex);
            }
            catch (Exception ex)
            {
                await trx.Result.RollbackAsync();
                throw new Exception("An error occurred while deleting the genre", ex);
            }
        }

        public async Task<IEnumerable<GenreResponseDto>> GetAllGenresAsync()
        {
            var genres = await _genreRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<GenreResponseDto>>(genres);
            return result;
        }

        public async Task<GenreResponseDto> GetGenreByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("Genre ID cannot be empty");
            }
            var genre = _genreRepository.GetByIdAsync(id);
            if (genre == null)
            {
                throw new Exception($"Genre with ID {id} not found");
            }

            return _mapper.Map<GenreResponseDto>(genre);
        }

        public async Task<GenreResponseDto> UpdateGenreAsync(GenreUpdateDto genre)
        {
            var trx = await _context.Database.BeginTransactionAsync();
            try
            {
                if (genre == null)
                {
                    throw new ArgumentNullException(nameof(genre), "Genre cannot be null");
                }
                if (genre.Id == Guid.Empty)
                {
                    throw new ArgumentException("Genre ID cannot be empty", nameof(genre.Id));
                }
                var existingGenre = await _genreRepository.GetByIdAsync(genre.Id);
                if (existingGenre == null)
                {
                    throw new KeyNotFoundException($"Genre with ID {genre.Id} not found");
                }
                var updateGenre = await _genreRepository.UpdateAsync(genre);
                await _context.SaveChangesAsync();
                await trx.CommitAsync();

                return _mapper.Map<GenreResponseDto>(updateGenre);
            }
            catch (KeyNotFoundException ex)
            {
                await trx.RollbackAsync();
                throw new Exception("Genre not found", ex);
            }
            catch (Exception ex)
            {
                await trx.RollbackAsync();
                throw new Exception("An error occurred while updating the genre", ex);
            }
        }
    }
}

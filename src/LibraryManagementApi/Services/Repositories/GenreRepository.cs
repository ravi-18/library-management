using LibraryManagementApi.Data;
using LibraryManagementApi.Dtos.Genre;
using LibraryManagementApi.Interfaces.Repositories;
using LibraryManagementApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementApi.Services.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _context;

        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Genre> AddAsync(GenreRequestDto genre)
        {
            var newGenre = new Genre
            {
                Id = Guid.NewGuid(),
                Name = genre.Name,
                Description = genre.Description,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "admin",
            };
            await _context.Genres.AddAsync(newGenre);

            return newGenre;
        }

        public async Task DeleteAsync(Guid id)
        {
            var genre = await GetByIdAsync(id);
            if (genre != null)
            {
                _context.Genres.Remove(genre);
            }
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await Task.FromResult(_context.Genres);
        }

        public async Task<Genre?> GetByIdAsync(Guid id)
        {
            return await _context.Genres.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<Genre> UpdateAsync(GenreUpdateDto genre)
        {
            var existingGenre = await GetByIdAsync(genre.Id);
            if (existingGenre != null)
            {
                existingGenre.Name = genre.Name;
                existingGenre.Description = genre.Description;
                existingGenre.UpdatedAt = DateTime.UtcNow;
                _context.Genres.Update(existingGenre);
            }
            else
            {
                throw new Exception($"Genre not found.");
            }

            return existingGenre;
        }
    }
}

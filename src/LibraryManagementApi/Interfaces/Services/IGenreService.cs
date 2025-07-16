using LibraryManagementApi.Dtos.Genre;

namespace LibraryManagementApi.Interfaces.Services
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreResponseDto>> GetAllGenresAsync();
        Task<GenreResponseDto> GetGenreByIdAsync(Guid id);
        Task<GenreResponseDto> AddGenreAsync(GenreRequestDto genre);
        Task<GenreResponseDto> UpdateGenreAsync(GenreUpdateDto genre);
        Task DeleteGenreAsync(Guid id);
    }
}

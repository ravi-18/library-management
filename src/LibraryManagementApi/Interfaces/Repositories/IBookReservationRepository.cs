using LibraryManagementApi.Models;

namespace LibraryManagementApi.Interfaces.Repositories
{
    public interface IBookReservationRepository
    {
        Task<IEnumerable<BookReservation>> GetAllAsync();
        Task<BookReservation> GetByIdAsync(int id);
        Task AddAsync(BookReservation bookReservation);
        Task UpdateAsync(BookReservation bookReservation);
        Task DeleteAsync(int id);
    }
}

using LibraryManagementApi.Interfaces.Repositories;
using LibraryManagementApi.Models;

namespace LibraryManagementApi.Services.Repositories
{
    public class BookReservationRepository : IBookReservationRepository
    {
        public Task AddAsync(BookReservation bookReservation)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookReservation>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BookReservation> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(BookReservation bookReservation)
        {
            throw new NotImplementedException();
        }
    }
}

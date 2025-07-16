using LibraryManagementApi.Helpers;

namespace LibraryManagementApi.Dtos.BookReservation
{
    public class BookReservationRequestDto
    {
        public Guid? UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime? ReservedAt { get; set; }
        public ReservationStatus? Status { get; set; }
    }
}

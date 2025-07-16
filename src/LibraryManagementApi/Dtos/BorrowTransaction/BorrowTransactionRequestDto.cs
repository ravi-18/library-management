using LibraryManagementApi.Helpers;

namespace LibraryManagementApi.Dtos.BorrowTransaction
{
    public class BorrowTransactionRequestDto
    {
        public Guid? UserId { get; set; }
        public DateTime? BorrowDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public BorrowStatus? Status { get; set; }
    }
}

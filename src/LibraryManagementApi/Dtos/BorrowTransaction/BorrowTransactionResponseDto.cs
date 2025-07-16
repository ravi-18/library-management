using LibraryManagementApi.Helpers;

namespace LibraryManagementApi.Dtos.BorrowTransaction
{
    public class BorrowTransactionResponseDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime? BorrowDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public BorrowStatus? Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string DeletedBy { get; set; }

    }
}

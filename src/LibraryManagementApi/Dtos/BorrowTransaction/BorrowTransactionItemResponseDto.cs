namespace LibraryManagementApi.Dtos.BorrowTransaction
{
    public class BorrowTransactionItemResponseDto
    {
        public Guid Id { get; set; }
        public Guid TransactionId { get; set; }
        public Guid BookId { get; set; }
        public int Quantity { get; set; }

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string DeletedBy { get; set; }
    }
}

namespace LibraryManagementApi.Dtos.BorrowTransaction
{
    public class BorrowTransactionItemRequestDtp
    {
        public Guid TransactionId { get; set; }
        public Guid BookId { get; set; }
        public int Quantity { get; set; }
    }
}

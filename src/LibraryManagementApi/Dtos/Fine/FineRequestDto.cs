namespace LibraryManagementApi.Dtos.Fine
{
    public class FineRequestDto
    {
        public Guid TransactionId { get; set; }
        public decimal? Amount { get; set; }
        public bool? Paid { get; set; }
        public DateTime? PaidDate { get; set; }
    }
}

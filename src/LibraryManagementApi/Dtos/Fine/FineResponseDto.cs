namespace LibraryManagementApi.Dtos.Fine
{
    public class FineResponseDto
    {
        public Guid Id { get; set; }
        public Guid TransactionId { get; set; }
        public decimal? Amount { get; set; }
        public bool? Paid { get; set; }
        public DateTime? PaidDate { get; set; }

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string DeletedBy { get; set; }
    }
}

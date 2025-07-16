namespace LibraryManagementApi.Dtos.Book
{
    public class BookRequestDto
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public int? YearPublished { get; set; }
        public int? Quantity { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}

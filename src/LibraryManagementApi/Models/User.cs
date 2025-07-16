namespace LibraryManagementApi.Models;

public class User
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }

    public ICollection<BorrowTransaction> BorrowTransactions { get; set; }
    public ICollection<BookReservation> BookReservations { get; set; }
}
namespace LibraryManagementApi.Models;

using System;
using System.Collections.Generic;

public class Book
{
    public Guid Id { get; set; }
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }
    public int? YearPublished { get; set; }
    public int? Quantity { get; set; }
    public string Description { get; set; }

    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }

    public ICollection<BookGenre> BookGenres { get; set; }
    public ICollection<BorrowTransactionItem> BorrowTransactionItems { get; set; }
    public ICollection<BookReservation> BookReservations { get; set; }
}

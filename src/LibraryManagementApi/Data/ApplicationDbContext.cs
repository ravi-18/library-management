using LibraryManagementApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementApi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fine>()
            .Property(e => e.Amount)
            .HasPrecision(18, 2);

        modelBuilder.Entity<BookGenre>()
            .HasKey(bg => new { bg.BookId, bg.GenreId });

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<BookGenre> BookGenres { get; set; }
    public DbSet<BorrowTransaction> BorrowTransactions { get; set; }
    public DbSet<BorrowTransactionItem> BorrowTransactionItems { get; set; }
    public DbSet<Fine> Fines { get; set; }
    public DbSet<User> Users { get; set; }

public DbSet<LibraryManagementApi.Models.BookReservation> BookReservation { get; set; } = default!;
}
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementApi.Models;

public class BookGenre
{
    public Guid BookId { get; set; }
    public Guid GenreId { get; set; }

    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }

    public Book Book { get; set; }
    public Genre Genre { get; set; }
}
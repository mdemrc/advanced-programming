using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.Models;

public class Book
{
    public int Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Title { get; set; }

    [Required]
    [StringLength(17)]
    public string ISBN { get; set; }

    [Range(1.0, 500.0)]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [Display(Name = "Published Date")]
    [DataType(DataType.Date)]
    public DateTime PublishedDate { get; set; }

    [Range(0, 1000)]
    public int Stock { get; set; }

    [Required]
    [Display(Name = "Author")]
    public int AuthorId { get; set; }

    public Author Author { get; set; }

    [Required]
    [Display(Name = "Category")]
    public int CategoryId { get; set; }

    public Category Category { get; set; }
}

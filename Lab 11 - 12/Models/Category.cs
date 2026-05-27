using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models;

public class Category
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [StringLength(250)]
    public string Description { get; set; }

    public List<Book> Books { get; set; } = new List<Book>();
}

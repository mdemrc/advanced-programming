using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models;

public class Author
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required]
    [StringLength(50)]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [StringLength(500)]
    public string Bio { get; set; }

    public List<Book> Books { get; set; } = new List<Book>();

    [Display(Name = "Author")]
    public string FullName => $"{FirstName} {LastName}";
}

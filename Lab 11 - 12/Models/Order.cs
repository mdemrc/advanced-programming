using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.Models;

public class Order
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    [Display(Name = "Customer Name")]
    public string CustomerName { get; set; }

    [Required]
    [EmailAddress]
    [Display(Name = "Email Address")]
    public string CustomerEmail { get; set; }

    [Display(Name = "Order Date")]
    public DateTime OrderDate { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    [Display(Name = "Total Amount")]
    public decimal TotalAmount { get; set; }

    public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bookstore.Data;
using Bookstore.Models;

namespace Bookstore.Controllers;

public class OrdersController : Controller
{
    private readonly BookstoreContext _context;

    public OrdersController(BookstoreContext context)
    {
        _context = context;
    }

    // GET: Orders
    public async Task<IActionResult> Index()
    {
        var orders = await _context.Order
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Book)
            .OrderByDescending(o => o.OrderDate)
            .ToListAsync();
            
        return View(orders);
    }

    // GET: Orders/Create
    public IActionResult Create()
    {
        var books = _context.Book.Where(b => b.Stock > 0).OrderBy(b => b.Title);
        ViewBag.BookId = new SelectList(books, "Id", "Title");
        return View();
    }

    // POST: Orders/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(string customerName, string customerEmail, int bookId, int quantity)
    {
        var book = await _context.Book.FindAsync(bookId);
        if (book == null)
        {
            return NotFound();
        }

        if (quantity <= 0)
        {
            ModelState.AddModelError("", "Quantity must be at least 1.");
        }
        else if (book.Stock < quantity)
        {
            ModelState.AddModelError("", $"Insufficient stock. Only {book.Stock} copies of '{book.Title}' are available.");
        }

        if (ModelState.IsValid)
        {
            // Create order
            var order = new Order
            {
                CustomerName = customerName,
                CustomerEmail = customerEmail,
                OrderDate = DateTime.Now,
                TotalAmount = book.Price * quantity
            };

            _context.Order.Add(order);
            await _context.SaveChangesAsync(); // get order ID

            // Create order item
            var orderItem = new OrderItem
            {
                OrderId = order.Id,
                BookId = book.Id,
                Quantity = quantity,
                Price = book.Price
            };

            // Deduct stock
            book.Stock -= quantity;

            _context.OrderItem.Add(orderItem);
            _context.Book.Update(book);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        var books = _context.Book.Where(b => b.Stock > 0).OrderBy(b => b.Title);
        ViewBag.BookId = new SelectList(books, "Id", "Title", bookId);
        return View();
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bookstore.Data;
using Bookstore.Models;

namespace Bookstore.Controllers;

public class AuthorsController : Controller
{
    private readonly BookstoreContext _context;

    public AuthorsController(BookstoreContext context)
    {
        _context = context;
    }

    // GET: Authors
    public async Task<IActionResult> Index()
    {
        return View(await _context.Author.ToListAsync());
    }

    // GET: Authors/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Authors/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Bio")] Author author)
    {
        if (ModelState.IsValid)
        {
            _context.Add(author);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(author);
    }
}

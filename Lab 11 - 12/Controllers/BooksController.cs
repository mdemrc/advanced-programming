using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bookstore.Data;
using Bookstore.Models;

namespace Bookstore.Controllers;

public class BooksController : Controller
{
    private readonly BookstoreContext _context;

    public BooksController(BookstoreContext context)
    {
        _context = context;
    }

    // GET: Books
    public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
    {
        ViewData["CurrentSort"] = sortOrder;
        ViewData["TitleSortParm"] = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
        ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
        ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

        if (searchString != null)
        {
            pageNumber = 1;
        }
        else
        {
            searchString = currentFilter;
        }

        ViewData["CurrentFilter"] = searchString;

        var booksQuery = _context.Book
            .Include(b => b.Author)
            .Include(b => b.Category)
            .AsNoTracking();

        if (!string.IsNullOrEmpty(searchString))
        {
            booksQuery = booksQuery.Where(b => b.Title.Contains(searchString) 
                                            || b.ISBN.Contains(searchString)
                                            || b.Author.FirstName.Contains(searchString)
                                            || b.Author.LastName.Contains(searchString));
        }

        booksQuery = sortOrder switch
        {
            "title_desc" => booksQuery.OrderByDescending(b => b.Title),
            "Price" => booksQuery.OrderBy(b => b.Price),
            "price_desc" => booksQuery.OrderByDescending(b => b.Price),
            "Date" => booksQuery.OrderBy(b => b.PublishedDate),
            "date_desc" => booksQuery.OrderByDescending(b => b.PublishedDate),
            _ => booksQuery.OrderBy(b => b.Title),
        };

        int pageSize = 3;
        int pageIndex = pageNumber ?? 1;
        int totalCount = await booksQuery.CountAsync();
        
        var items = await booksQuery
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        ViewData["PageIndex"] = pageIndex;
        ViewData["TotalPages"] = (int)Math.Ceiling(totalCount / (double)pageSize);
        ViewData["HasPreviousPage"] = pageIndex > 1;
        ViewData["HasNextPage"] = pageIndex < (int)Math.Ceiling(totalCount / (double)pageSize);

        return View(items);
    }

    // GET: Books/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var book = await _context.Book
            .Include(b => b.Author)
            .Include(b => b.Category)
            .FirstOrDefaultAsync(m => m.Id == id);
            
        if (book == null)
        {
            return NotFound();
        }

        return View(book);
    }

    // GET: Books/Create
    public IActionResult Create()
    {
        PopulateDropdowns();
        return View();
    }

    // POST: Books/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title,ISBN,Price,PublishedDate,Stock,AuthorId,CategoryId")] Book book)
    {
        if (ModelState.IsValid)
        {
            _context.Add(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        PopulateDropdowns(book.AuthorId, book.CategoryId);
        return View(book);
    }

    // GET: Books/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var book = await _context.Book.FindAsync(id);
        if (book == null)
        {
            return NotFound();
        }
        PopulateDropdowns(book.AuthorId, book.CategoryId);
        return View(book);
    }

    // POST: Books/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ISBN,Price,PublishedDate,Stock,AuthorId,CategoryId")] Book book)
    {
        if (id != book.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(book);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(book.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        PopulateDropdowns(book.AuthorId, book.CategoryId);
        return View(book);
    }

    // GET: Books/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var book = await _context.Book
            .Include(b => b.Author)
            .Include(b => b.Category)
            .FirstOrDefaultAsync(m => m.Id == id);
            
        if (book == null)
        {
            return NotFound();
        }

        return View(book);
    }

    // POST: Books/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var book = await _context.Book.FindAsync(id);
        if (book != null)
        {
            _context.Book.Remove(book);
        }
        
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private void PopulateDropdowns(object selectedAuthor = null, object selectedCategory = null)
    {
        var authorsQuery = from a in _context.Author
                           orderby a.LastName
                           select a;
        ViewBag.AuthorId = new SelectList(authorsQuery.AsNoTracking(), "Id", "FullName", selectedAuthor);

        var categoriesQuery = from c in _context.Category
                              orderby c.Name
                              select c;
        ViewBag.CategoryId = new SelectList(categoriesQuery.AsNoTracking(), "Id", "Name", selectedCategory);
    }

    private bool BookExists(int id)
    {
        return _context.Book.Any(e => e.Id == id);
    }
}

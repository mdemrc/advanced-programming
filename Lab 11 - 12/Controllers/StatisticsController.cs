using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bookstore.Data;
using Bookstore.Models;

namespace Bookstore.Controllers;

public class StatisticsController : Controller
{
    private readonly BookstoreContext _context;

    public StatisticsController(BookstoreContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var stats = new BookstoreStatsViewModel();

        // 1. Total revenue
        stats.TotalRevenue = await _context.OrderItem
            .SumAsync(oi => oi.Price * oi.Quantity);

        // 2. Total books sold
        stats.TotalBooksSold = await _context.OrderItem
            .SumAsync(oi => oi.Quantity);

        // 3. Top selling books (LINQ query)
        stats.TopSellingBooks = await _context.OrderItem
            .Include(oi => oi.Book)
                .ThenInclude(b => b.Author)
            .GroupBy(oi => oi.BookId)
            .Select(g => new TopBookStat
            {
                Title = g.First().Book.Title,
                Author = g.First().Book.Author.FirstName + " " + g.First().Book.Author.LastName,
                SoldCount = g.Sum(oi => oi.Quantity)
            })
            .OrderByDescending(s => s.SoldCount)
            .Take(5)
            .ToListAsync();

        // 4. Sales by category (LINQ query)
        stats.SalesByCategory = await _context.OrderItem
            .Include(oi => oi.Book)
                .ThenInclude(b => b.Category)
            .GroupBy(oi => oi.Book.Category.Name)
            .Select(g => new CategoryStat
            {
                CategoryName = g.Key,
                TotalSales = g.Sum(oi => oi.Price * oi.Quantity)
            })
            .OrderByDescending(c => c.TotalSales)
            .ToListAsync();

        // 5. Active customers
        stats.ActiveCustomers = await _context.Order
            .GroupBy(o => o.CustomerEmail)
            .Select(g => new CustomerStat
            {
                CustomerName = g.First().CustomerName,
                CustomerEmail = g.Key,
                OrderCount = g.Count()
            })
            .OrderByDescending(c => c.OrderCount)
            .Take(5)
            .ToListAsync();

        return View(stats);
    }
}

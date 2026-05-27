namespace Bookstore.Models;

public class BookstoreStatsViewModel
{
    public decimal TotalRevenue { get; set; }
    public int TotalBooksSold { get; set; }
    public List<TopBookStat> TopSellingBooks { get; set; } = new();
    public List<CategoryStat> SalesByCategory { get; set; } = new();
    public List<CustomerStat> ActiveCustomers { get; set; } = new();
}

public class TopBookStat
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int SoldCount { get; set; }
}

public class CategoryStat
{
    public string CategoryName { get; set; }
    public decimal TotalSales { get; set; }
}

public class CustomerStat
{
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public int OrderCount { get; set; }
}

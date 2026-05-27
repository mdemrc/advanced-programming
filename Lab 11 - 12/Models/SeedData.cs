using Microsoft.EntityFrameworkCore;
using Bookstore.Data;

namespace Bookstore.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new BookstoreContext(
            serviceProvider.GetRequiredService<DbContextOptions<BookstoreContext>>()))
        {
            // Seed check
            if (context.Book.Any() || context.Author.Any() || context.Category.Any())
            {
                return;   // already seeded
            }

            // 1. Authors
            var tolkien = new Author { FirstName = "J.R.R.", LastName = "Tolkien", Bio = "English writer, poet, philologist, and academic." };
            var martin = new Author { FirstName = "George R.R.", LastName = "Martin", Bio = "American novelist and short story writer, screenwriter, and television producer." };
            var sanderson = new Author { FirstName = "Brandon", LastName = "Sanderson", Bio = "American author of epic fantasy and science fiction." };

            context.Author.AddRange(tolkien, martin, sanderson);
            context.SaveChanges(); // generate IDs

            // 2. Categories
            var fantasy = new Category { Name = "Fantasy", Description = "Speculative fiction set in a fictional universe." };
            var scifi = new Category { Name = "Science Fiction", Description = "Speculative fiction dealing with imaginative concepts such as futuristic science and technology." };
            var history = new Category { Name = "History", Description = "Non-fiction works concerning historical events." };

            context.Category.AddRange(fantasy, scifi, history);
            context.SaveChanges(); // generate IDs

            // 3. Books
            var hobbit = new Book
            {
                Title = "The Hobbit",
                AuthorId = tolkien.Id,
                CategoryId = fantasy.Id,
                Price = 14.99M,
                Stock = 10,
                ISBN = "978-0261102217",
                PublishedDate = DateTime.Parse("1937-09-21")
            };

            var fellowship = new Book
            {
                Title = "The Fellowship of the Ring",
                AuthorId = tolkien.Id,
                CategoryId = fantasy.Id,
                Price = 19.99M,
                Stock = 15,
                ISBN = "978-0261103573",
                PublishedDate = DateTime.Parse("1954-07-29")
            };

            var thrones = new Book
            {
                Title = "A Game of Thrones",
                AuthorId = martin.Id,
                CategoryId = fantasy.Id,
                Price = 12.99M,
                Stock = 8,
                ISBN = "978-0553103540",
                PublishedDate = DateTime.Parse("1996-08-01")
            };

            var mistborn = new Book
            {
                Title = "Mistborn: The Final Empire",
                AuthorId = sanderson.Id,
                CategoryId = fantasy.Id,
                Price = 10.99M,
                Stock = 12,
                ISBN = "978-0765311788",
                PublishedDate = DateTime.Parse("2006-07-17")
            };

            context.Book.AddRange(hobbit, fellowship, thrones, mistborn);
            context.SaveChanges();

            // 4. Sample Order
            var sampleOrder = new Order
            {
                CustomerName = "John Watson",
                CustomerEmail = "john.watson@example.com",
                OrderDate = DateTime.Now.AddDays(-3),
                TotalAmount = 42.97M
            };

            context.Order.Add(sampleOrder);
            context.SaveChanges();

            var item1 = new OrderItem
            {
                OrderId = sampleOrder.Id,
                BookId = hobbit.Id,
                Quantity = 2,
                Price = 14.99M
            };

            var item2 = new OrderItem
            {
                OrderId = sampleOrder.Id,
                BookId = thrones.Id,
                Quantity = 1,
                Price = 12.99M
            };

            context.OrderItem.AddRange(item1, item2);
            context.SaveChanges();
        }
    }
}

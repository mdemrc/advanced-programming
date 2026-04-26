using DocumentLibrary.Models;
using DocumentLibrary.Services;
using DocumentLibrary.Exceptions;

namespace DocumentLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            DocumentManager manager = new DocumentManager();

            // --- Adding books ---
            Console.WriteLine("--- Adding documents ---");

            try
            {
                manager.AddDocument(new Book("978-0-13-468599-1", "The Pragmatic Programmer", 1999, 352, "David Thomas"));
                Console.WriteLine("Added: The Pragmatic Programmer");
            }
            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }

            try
            {
                manager.AddDocument(new Book("978-0-201-63361-0", "Design Patterns", 1994, 395, "Erich Gamma"));
                Console.WriteLine("Added: Design Patterns");
            }
            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }

            try
            {
                manager.AddDocument(new Book("978-0-596-00712-6", "Head First Design Patterns", 2004, 694, "Eric Freeman"));
                Console.WriteLine("Added: Head First Design Patterns");
            }
            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }

            // --- Adding volumes ---
            try
            {
                manager.AddDocument(new Volume("978-0-7432-7356-5", "The Lord of the Rings", 1954, 423, "J.R.R. Tolkien", 1, 3));
                Console.WriteLine("Added: The Lord of the Rings vol.1");
            }
            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }

            try
            {
                manager.AddDocument(new Volume("978-0-7432-7357-2", "The Two Towers", 1954, 352, "J.R.R. Tolkien", 2, 3));
                Console.WriteLine("Added: The Two Towers vol.2");
            }
            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }

            try
            {
                manager.AddDocument(new Volume("978-0-7432-7358-9", "Return of the King", 1955, 416, "J.R.R. Tolkien", 3, 3));
                Console.WriteLine("Added: Return of the King vol.3");
            }
            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }

            // --- Adding magazines ---
            try
            {
                manager.AddDocument(new Magazine("1234-5678", "National Geographic", 2023, 120, 5, Frequency.Monthly));
                Console.WriteLine("Added: National Geographic");
            }
            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }

            try
            {
                manager.AddDocument(new Magazine("2345-6789", "The Economist", 2023, 80, 42, Frequency.Weekly));
                Console.WriteLine("Added: The Economist");
            }
            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }

            try
            {
                manager.AddDocument(new Magazine("3456-7890", "Science Yearly Review", 2024, 200, 1, Frequency.Yearly));
                Console.WriteLine("Added: Science Yearly Review");
            }
            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }

            // --- Testing exceptions ---
            Console.WriteLine();
            Console.WriteLine("--- Testing exceptions ---");

            // Duplicate ISBN
            try
            {
                manager.AddDocument(new Book("978-0-13-468599-1", "Duplicate Book", 2020, 100, "Unknown"));
                Console.WriteLine("Added: Duplicate Book");
            }
            catch (DuplicateIsbnException ex) { Console.WriteLine("Error: " + ex.Message); }

            // Volume number > total volumes
            try
            {
                manager.AddDocument(new Volume("999-0-0000-0001-0", "Bad Volume", 2020, 100, "Author", 5, 3));
                Console.WriteLine("Added: Bad Volume");
            }
            catch (InvalidVolumeNumberException ex) { Console.WriteLine("Error: " + ex.Message); }

            // Year before printing press
            try
            {
                manager.AddDocument(new Book("999-0-0000-0002-0", "Ancient Text", 1200, 50, "Monk"));
                Console.WriteLine("Added: Ancient Text");
            }
            catch (InvalidPublicationYearException ex) { Console.WriteLine("Error: " + ex.Message); }

            // --- Show all documents ---
            Console.WriteLine();
            Console.WriteLine("--- All documents ---");
            List<Document> allDocs = manager.GetAllDocuments();
            foreach (Document doc in allDocs)
            {
                Console.WriteLine(doc.ToString());
            }

            // --- Search by title ---
            Console.WriteLine();
            Console.WriteLine("--- Search by title: 'Design' ---");
            List<Document> found = manager.SearchByTitle("Design");
            foreach (Document doc in found)
            {
                Console.WriteLine(doc.ToString());
            }

            // --- Search by ISBN ---
            Console.WriteLine();
            Console.WriteLine("--- Search by ISBN: '978-0-13-468599-1' ---");
            Document result = manager.GetDocumentByIsbn("978-0-13-468599-1");
            if (result != null)
                Console.WriteLine(result.ToString());
            else
                Console.WriteLine("Not found.");

            // --- Monthly magazines ---
            Console.WriteLine();
            Console.WriteLine("--- Monthly magazines ---");
            List<Magazine> monthly = manager.GetMagazinesByFrequency(Frequency.Monthly);
            foreach (Magazine mag in monthly)
            {
                Console.WriteLine(mag.ToString());
            }

            // --- Print all documents ---
            Console.WriteLine();
            Console.WriteLine("--- Printing all documents ---");
            foreach (Document doc in allDocs)
            {
                Console.WriteLine(doc.Print());
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}

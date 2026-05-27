using System;
using System.Collections.Generic;

namespace Lab4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== PART I: generic methods tests ===\n");

            // test 1: swap
            Console.WriteLine("[1] Swap");
            int x = 10, y = 20;
            Console.WriteLine("before: x=" + x + " y=" + y);
            GenericMethods.Swap(ref x, ref y);
            Console.WriteLine("after:  x=" + x + " y=" + y);

            string s1 = "hello", s2 = "world";
            GenericMethods.Swap(ref s1, ref s2);
            Console.WriteLine("strings after swap: " + s1 + ", " + s2);
            Console.WriteLine();

            // test 2: print types and reset to default
            Console.WriteLine("[2] PrintAndReset");
            int num = 42;
            string text = "something";
            GenericMethods.PrintAndReset(ref num, ref text);
            Console.WriteLine("after reset: num=" + num + ", text=" + (text == null ? "null" : text));
            Console.WriteLine();

            // test 3: create new instance
            Console.WriteLine("[3] CreateNew");
            Person newPerson = GenericMethods.CreateNew<Person>();
            Console.WriteLine("created person: " + newPerson);
            List<int> newList = GenericMethods.CreateNew<List<int>>();
            Console.WriteLine("created list count: " + newList.Count);
            Console.WriteLine();

            // test 4: bigger
            Console.WriteLine("[4] Bigger");
            Console.WriteLine("bigger of 5 and 9: " + GenericMethods.Bigger(5, 9));
            Console.WriteLine("bigger of apple and banana: " + GenericMethods.Bigger("apple", "banana"));
            Console.WriteLine();

            // test 5: sorted list
            Console.WriteLine("[5] SortedList");
            List<int> sortedInts = GenericMethods.SortedList(5, 1, 4, 2, 3);
            Console.WriteLine("sorted ints: " + string.Join(", ", sortedInts));
            List<string> sortedStrs = GenericMethods.SortedList("pear", "apple", "banana");
            Console.WriteLine("sorted strings: " + string.Join(", ", sortedStrs));
            Console.WriteLine();

            // test 6: make dictionary (key is struct, value is class)
            Console.WriteLine("[6] MakeDictionary");
            Dictionary<int, string> dict = GenericMethods.MakeDictionary(1, "one");
            dict.Add(2, "two");
            dict.Add(3, "three");
            Console.WriteLine("dict has " + dict.Count + " entries");
            Console.WriteLine();

            // test 7: print dictionary
            Console.WriteLine("[7] PrintDictionary");
            GenericMethods.PrintDictionary(dict);
            Console.WriteLine();

            // test 8: queue or stack
            Console.WriteLine("[8] QueueOrStack");
            var small = GenericMethods.QueueOrStack(1, 2);
            Console.WriteLine("less than 3 items, type: " + small.GetType().Name);
            foreach (var v in small) Console.Write(v + " ");
            Console.WriteLine();

            var big = GenericMethods.QueueOrStack(1, 2, 3, 4, 5);
            Console.WriteLine("3 or more items, type: " + big.GetType().Name);
            foreach (var v in big) Console.Write(v + " ");
            Console.WriteLine("\n");

            // PART II
            Console.WriteLine("=== PART II: Person and Car ===\n");

            Person john = new Person("John", "Smith", 30, new List<Car>
            {
                new Car("Toyota", 50000),
                new Car("Ford", 75000)
            });

            Person anna = new Person("Anna", "Brown", 25, new List<Car>
            {
                new Car("BMW", 120000)
            });

            Person mark = new Person("Mark", "Wilson", 40, new List<Car>
            {
                new Car("Audi", 90000),
                new Car("Mercedes", 150000),
                new Car("Fiat", 30000)
            });

            // use foreach directly on a person (because Person implements IEnumerable<Car>)
            Console.WriteLine("Cars of " + mark.FirstName + ":");
            foreach (Car c in mark)
            {
                Console.WriteLine("  " + c);
            }
            Console.WriteLine();

            List<Person> people = new List<Person> { john, anna, mark };
            Console.WriteLine("Before sort:");
            foreach (Person p in people)
                Console.WriteLine("  " + p.FirstName + " total cars value: " + p.TotalCarsValue());

            people.Sort();

            Console.WriteLine("\nAfter sort by total cars value:");
            foreach (Person p in people)
                Console.WriteLine("  " + p.FirstName + " total cars value: " + p.TotalCarsValue());
            Console.WriteLine();

            // PART III
            Console.WriteLine("=== PART III: Quadruple ===\n");

            List<Quadruple<int, string, double, bool>> quads = new List<Quadruple<int, string, double, bool>>
            {
                new Quadruple<int, string, double, bool>(3, "three", 3.14, true),
                new Quadruple<int, string, double, bool>(1, "one", 1.1, false),
                new Quadruple<int, string, double, bool>(2, "two", 2.2, true),
                new Quadruple<int, string, double, bool>(5, "five", 5.5, false),
                new Quadruple<int, string, double, bool>(4, "four", 4.4, true)
            };

            Console.WriteLine("Before sort:");
            foreach (var q in quads) Console.WriteLine("  " + q);

            quads.Sort();

            Console.WriteLine("\nAfter sort by id:");
            foreach (var q in quads) Console.WriteLine("  " + q);

            // quick equals and hashcode check
            var qa = new Quadruple<int, string, double, bool>(1, "one", 1.1, false);
            var qb = new Quadruple<int, string, double, bool>(1, "one", 1.1, false);
            Console.WriteLine("\nEquals check: " + qa.Equals(qb));
            Console.WriteLine("HashCode equal: " + (qa.GetHashCode() == qb.GetHashCode()));

            Console.WriteLine("\nDone. Press any key to exit...");
            Console.ReadKey();
        }
    }
}

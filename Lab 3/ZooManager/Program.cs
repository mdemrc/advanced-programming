using System;

namespace ZooManager
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the animal manager object
            AnimalManager manager = new AnimalManager();

            // 1) Add animal objects to the animals list
            Console.WriteLine("====== ADDING ANIMALS ======\n");

            // Create herbivore animals
            Sheep sheep1 = new Sheep("Dolly", 3, 45.0);
            Sheep sheep2 = new Sheep("Fluffy", 2, 38.5);
            Koala koala1 = new Koala("Blinky", 5, 12.0);
            Koala koala2 = new Koala("Eddie", 4, 10.5);

            // Create carnivore animals
            Wolf wolf1 = new Wolf("Grey", 6, 55.0);
            Wolf wolf2 = new Wolf("Shadow", 4, 48.0);
            Lion lion1 = new Lion("Simba", 8, 190.0);
            Lion lion2 = new Lion("Nala", 7, 150.0);

            // Create omnivore animals (both herbivore and carnivore)
            Pig pig1 = new Pig("Babe", 2, 80.0);
            Pig pig2 = new Pig("Wilbur", 3, 95.0);
            Bear bear1 = new Bear("Teddy", 10, 300.0);
            Bear bear2 = new Bear("Grizzly", 12, 350.0);

            // Add all animals to the manager
            manager.AddAnimal(sheep1);
            manager.AddAnimal(sheep2);
            manager.AddAnimal(koala1);
            manager.AddAnimal(koala2);
            manager.AddAnimal(wolf1);
            manager.AddAnimal(wolf2);
            manager.AddAnimal(lion1);
            manager.AddAnimal(lion2);
            manager.AddAnimal(pig1);
            manager.AddAnimal(pig2);
            manager.AddAnimal(bear1);
            manager.AddAnimal(bear2);

            // ========================================
            // 2) Copy animals to herbivore and carnivore lists
            // ========================================
            Console.WriteLine("\n====== COPYING TO LISTS ======\n");
            manager.CopyAnimalsToLists();

            // ========================================
            // 3) Display all lists
            // ========================================
            Console.WriteLine("\n====== DISPLAYING LISTS ======\n");

            // Display all animals
            manager.DisplayAllAnimals();
            Console.WriteLine();

            // Display all herbivores
            manager.DisplayAllHerbivores();
            Console.WriteLine();

            // Display all carnivores
            manager.DisplayAllCarnivores();
            Console.WriteLine();

            // ========================================
            // 4) Group feeding and individual feeding
            // ========================================
            Console.WriteLine("\n====== GROUP FEEDING ======\n");

            // Feed all herbivores as a group
            manager.FeedAllHerbivores();
            Console.WriteLine();

            // Feed all carnivores as a group
            manager.FeedAllCarnivores();
            Console.WriteLine();

            // ========================================
            // Individual feeding using static methods
            // ========================================
            Console.WriteLine("\n====== INDIVIDUAL FEEDING ======\n");

            // Feed a single herbivore (Dolly the sheep)
            AnimalManager.FeedHerbivore(sheep1);
            Console.WriteLine();

            // Feed a single carnivore (Simba the lion)
            AnimalManager.FeedCarnivore(lion1);
            Console.WriteLine();

            // Feed an omnivore as herbivore (Babe the pig)
            AnimalManager.FeedHerbivore(pig1);
            Console.WriteLine();

            // Feed an omnivore as carnivore (Babe the pig)
            AnimalManager.FeedCarnivore(pig1);
            Console.WriteLine();

            // ========================================
            // Find an animal by name
            // ========================================
            Console.WriteLine("\n====== FINDING ANIMAL BY NAME ======\n");

            // Search for an animal named "Simba"
            Animal found = manager.FindAnimalByName("Simba");
            if (found != null)
            {
                Console.WriteLine("Found: " + found);
            }
            else
            {
                Console.WriteLine("Animal not found.");
            }

            // Search for an animal that does not exist
            Animal notFound = manager.FindAnimalByName("Rex");
            if (notFound != null)
            {
                Console.WriteLine("Found: " + notFound);
            }
            else
            {
                Console.WriteLine("Animal 'Rex' not found.");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;

namespace ZooManager
{
    // This class manages all animals in the zoo
    // It has lists for all animals, herbivores, and carnivores
    // It provides methods to add, display, feed, and find animals
    public class AnimalManager
    {
        // 1) Public initialized list of all animals
        public List<Animal> Animals = new List<Animal>();

        // 2) Public initialized list of herbivores
        public List<IHerbivore> Herbivores = new List<IHerbivore>();

        // 3) Public initialized list of carnivores
        public List<ICarnivore> Carnivores = new List<ICarnivore>();

        // 4) Method to add an animal to the animals list
        public void AddAnimal(Animal animal)
        {
            Animals.Add(animal);
            Console.WriteLine("Added " + animal.Name + " to the animals list.");
        }

        // 5) Method to add a herbivore to the herbivores list
        public void AddHerbivore(IHerbivore herbivore)
        {
            Herbivores.Add(herbivore);
            Console.WriteLine("Added herbivore to the herbivores list.");
        }

        // 6) Method to add a carnivore to the carnivores list
        public void AddCarnivore(ICarnivore carnivore)
        {
            Carnivores.Add(carnivore);
            Console.WriteLine("Added carnivore to the carnivores list.");
        }

        // 7) Method that copies animals from the main list to herbivore or carnivore lists
        // It checks if each animal implements IHerbivore or ICarnivore
        public void CopyAnimalsToLists()
        {
            foreach (Animal animal in Animals)
            {
                // If the animal is a herbivore, add it to the herbivores list
                if (animal is IHerbivore)
                {
                    Herbivores.Add((IHerbivore)animal);
                }

                // If the animal is a carnivore, add it to the carnivores list
                if (animal is ICarnivore)
                {
                    Carnivores.Add((ICarnivore)animal);
                }
            }

            Console.WriteLine("Copied animals to herbivore and carnivore lists.");
        }

        // 8) Method to feed all herbivores
        // Calls both FindFood() and EatPlant() on each herbivore
        public void FeedAllHerbivores()
        {
            Console.WriteLine("--- Feeding all herbivores ---");
            foreach (IHerbivore herbivore in Herbivores)
            {
                herbivore.FindFood();
                herbivore.EatPlant();
            }
        }

        // 9) Method to feed all carnivores
        // Calls both FindFood() and EatMeat() on each carnivore
        public void FeedAllCarnivores()
        {
            Console.WriteLine("--- Feeding all carnivores ---");
            foreach (ICarnivore carnivore in Carnivores)
            {
                carnivore.FindFood();
                carnivore.EatMeat();
            }
        }

        // 10) Static method to feed a single herbivore
        // The parameter is an interface reference (IHerbivore)
        public static void FeedHerbivore(IHerbivore herbivore)
        {
            Console.WriteLine("--- Feeding a single herbivore ---");
            herbivore.FindFood();
            herbivore.EatPlant();
        }

        // 11) Static method to feed a single carnivore
        // The parameter is an interface reference (ICarnivore)
        public static void FeedCarnivore(ICarnivore carnivore)
        {
            Console.WriteLine("--- Feeding a single carnivore ---");
            carnivore.FindFood();
            carnivore.EatMeat();
        }

        // 12) Method to display all animals
        // Uses the overridden ToString() method of each animal
        public void DisplayAllAnimals()
        {
            Console.WriteLine("=== All Animals ===");
            foreach (Animal animal in Animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }

        // 13) Method to display all herbivores
        public void DisplayAllHerbivores()
        {
            Console.WriteLine("=== All Herbivores ===");
            foreach (IHerbivore herbivore in Herbivores)
            {
                Console.WriteLine(herbivore.ToString());
            }
        }

        // 14) Method to display all carnivores
        public void DisplayAllCarnivores()
        {
            Console.WriteLine("=== All Carnivores ===");
            foreach (ICarnivore carnivore in Carnivores)
            {
                Console.WriteLine(carnivore.ToString());
            }
        }

        // 15) Method to find and return an animal by its name
        public Animal FindAnimalByName(string name)
        {
            foreach (Animal animal in Animals)
            {
                if (animal.Name == name)
                {
                    return animal;
                }
            }

            // If no animal was found, return null
            return null;
        }
    }
}

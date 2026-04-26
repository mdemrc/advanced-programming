using System;

namespace ZooManager
{
    // Sheep is a herbivore animal - it only eats plants
    // It inherits from Animal and implements IHerbivore
    public class Sheep : Animal, IHerbivore
    {
        // Constructor - sets name, age and weight
        public Sheep(string name, int age, double weight)
        {
            Name = name;
            Age = age;
            Weight = weight;
        }

        // Sheep looks for grass to eat
        public void FindFood()
        {
            Console.WriteLine("Sheep " + Name + " is looking for some fresh grass.");
        }

        // Sheep eats a plant
        public void EatPlant()
        {
            Console.WriteLine("Sheep " + Name + " is happily munching on grass.");
        }

        // Override ToString to show sheep info
        public override string ToString()
        {
            return "Sheep: " + Name + ", Age: " + Age + ", Weight: " + Weight + " kg";
        }
    }
}

using System;

namespace ZooManager
{
    // Koala is a herbivore animal - it only eats plants (eucalyptus)
    // It inherits from Animal and implements IHerbivore
    public class Koala : Animal, IHerbivore
    {
        // Constructor - sets name, age and weight
        public Koala(string name, int age, double weight)
        {
            Name = name;
            Age = age;
            Weight = weight;
        }

        // Koala looks for eucalyptus leaves
        public void FindFood()
        {
            Console.WriteLine("Koala " + Name + " is searching for eucalyptus leaves.");
        }

        // Koala eats eucalyptus
        public void EatPlant()
        {
            Console.WriteLine("Koala " + Name + " ate a big piece of eucalyptus.");
        }

        // Override ToString to show koala info
        public override string ToString()
        {
            return "Koala: " + Name + ", Age: " + Age + ", Weight: " + Weight + " kg";
        }
    }
}

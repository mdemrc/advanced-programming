using System;

namespace ZooManager
{
    // Pig is an omnivore - it eats both plants and meat
    // It inherits from Animal and implements BOTH IHerbivore and ICarnivore
    // Because both interfaces have FindFood(), we use explicit interface implementation
    public class Pig : Animal, IHerbivore, ICarnivore
    {
        // Constructor - sets name, age and weight
        public Pig(string name, int age, double weight)
        {
            Name = name;
            Age = age;
            Weight = weight;
        }

        // Explicit implementation of IHerbivore.FindFood()
        // This version is called when the Pig is treated as IHerbivore
        void IHerbivore.FindFood()
        {
            Console.WriteLine("Pig " + Name + " is looking for vegetables and roots.");
        }

        // Explicit implementation of ICarnivore.FindFood()
        // This version is called when the Pig is treated as ICarnivore
        void ICarnivore.FindFood()
        {
            Console.WriteLine("Pig " + Name + " is sniffing around for bugs and worms.");
        }

        // Pig eats a plant
        public void EatPlant()
        {
            Console.WriteLine("Pig " + Name + " is chomping on some cabbage.");
        }

        // Pig eats meat
        public void EatMeat()
        {
            Console.WriteLine("Pig " + Name + " is gobbling up some leftover meat.");
        }

        // Override ToString to show pig info
        public override string ToString()
        {
            return "Pig: " + Name + ", Age: " + Age + ", Weight: " + Weight + " kg";
        }
    }
}

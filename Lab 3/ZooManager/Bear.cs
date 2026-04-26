using System;

namespace ZooManager
{
    // Bear is an omnivore - it eats both plants and meat
    // It inherits from Animal and implements BOTH IHerbivore and ICarnivore
    // Because both interfaces have FindFood(), we use explicit interface implementation
    public class Bear : Animal, IHerbivore, ICarnivore
    {
        // Constructor - sets name, age and weight
        public Bear(string name, int age, double weight)
        {
            Name = name;
            Age = age;
            Weight = weight;
        }

        // Explicit implementation of IHerbivore.FindFood()
        // This version is called when the Bear is treated as IHerbivore
        void IHerbivore.FindFood()
        {
            Console.WriteLine("Bear " + Name + " is foraging for berries in the bushes.");
        }

        // Explicit implementation of ICarnivore.FindFood()
        // This version is called when the Bear is treated as ICarnivore
        void ICarnivore.FindFood()
        {
            Console.WriteLine("Bear " + Name + " is fishing for salmon in the river.");
        }

        // Bear eats a plant
        public void EatPlant()
        {
            Console.WriteLine("Bear " + Name + " is eating sweet honey and berries.");
        }

        // Bear eats meat
        public void EatMeat()
        {
            Console.WriteLine("Bear " + Name + " is eating a freshly caught fish.");
        }

        // Override ToString to show bear info
        public override string ToString()
        {
            return "Bear: " + Name + ", Age: " + Age + ", Weight: " + Weight + " kg";
        }
    }
}

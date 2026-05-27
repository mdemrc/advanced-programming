using System;

namespace ZooManager
{
    // Lion is a carnivore animal - it only eats meat
    // It inherits from Animal and implements ICarnivore
    public class Lion : Animal, ICarnivore
    {
        // Constructor - sets name, age and weight
        public Lion(string name, int age, double weight)
        {
            Name = name;
            Age = age;
            Weight = weight;
        }

        // Lion searches for prey
        public void FindFood()
        {
            Console.WriteLine("Lion " + Name + " is stalking prey on the savanna.");
        }

        // Lion eats meat
        public void EatMeat()
        {
            Console.WriteLine("Lion " + Name + " is feasting on a big steak.");
        }

        // Override ToString to show lion info
        public override string ToString()
        {
            return "Lion: " + Name + ", Age: " + Age + ", Weight: " + Weight + " kg";
        }
    }
}

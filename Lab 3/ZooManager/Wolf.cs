using System;

namespace ZooManager
{
    // Wolf is a carnivore animal - it only eats meat
    // It inherits from Animal and implements ICarnivore
    public class Wolf : Animal, ICarnivore
    {
        // Constructor - sets name, age and weight
        public Wolf(string name, int age, double weight)
        {
            Name = name;
            Age = age;
            Weight = weight;
        }

        // Wolf hunts for prey
        public void FindFood()
        {
            Console.WriteLine("Wolf " + Name + " is hunting for prey in the forest.");
        }

        // Wolf eats meat
        public void EatMeat()
        {
            Console.WriteLine("Wolf " + Name + " is devouring a piece of meat.");
        }

        // Override ToString to show wolf info
        public override string ToString()
        {
            return "Wolf: " + Name + ", Age: " + Age + ", Weight: " + Weight + " kg";
        }
    }
}

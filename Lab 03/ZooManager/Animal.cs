using System;

namespace ZooManager
{
    // Abstract base class for all animals
    // Every animal has a name, age and weight
    public abstract class Animal
    {
        // Name of the animal
        public string Name { get; set; }

        // Age of the animal in years
        public int Age { get; set; }

        // Weight of the animal in kilograms
        public double Weight { get; set; }

        // Override ToString to display animal info
        public override string ToString()
        {
            return Name + ", Age: " + Age + ", Weight: " + Weight + " kg";
        }
    }
}

namespace ZooManager
{
    // Interface for carnivore animals (meat eaters)
    // Any class that implements this must define how it finds food and eats meat
    public interface ICarnivore
    {
        // Method to find meat food
        void FindFood();

        // Method to eat meat
        void EatMeat();
    }
}

namespace ZooManager
{
    // Interface for herbivore animals (plant eaters)
    // Any class that implements this must define how it finds and eats plants
    public interface IHerbivore
    {
        // Method to find plant food
        void FindFood();

        // Method to eat a plant
        void EatPlant();
    }
}

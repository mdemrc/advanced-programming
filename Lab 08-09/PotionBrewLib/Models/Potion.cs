namespace PotionBrewLib.Models;

public class Potion
{
    public string Name { get; set; }
    public PotionEffect Effect { get; set; }
    public Rarity Rarity { get; set; }
    public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    public int BrewTimeMinutes { get; set; }
    public decimal Price { get; set; }

    public Potion()
    {
    }

    public Potion(string name, PotionEffect effect, Rarity rarity, List<Ingredient> ingredients, int brewTimeMinutes, decimal price)
    {
        Name = name;
        Effect = effect;
        Rarity = rarity;
        Ingredients = ingredients ?? new List<Ingredient>();
        BrewTimeMinutes = brewTimeMinutes;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Name} ({Rarity}) - {Effect} - {Price}g ({BrewTimeMinutes} mins)";
    }
}

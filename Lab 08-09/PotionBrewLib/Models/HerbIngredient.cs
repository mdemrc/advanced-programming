namespace PotionBrewLib.Models;

public class HerbIngredient : Ingredient
{
    public string Region { get; set; }

    public HerbIngredient() : base()
    {
    }

    public HerbIngredient(string name, Rarity rarity, decimal basePrice, string description, string region)
        : base(name, rarity, basePrice, description)
    {
        Region = region;
    }

    public override string GetSource()
    {
        return $"Harvested from {Region}";
    }
}

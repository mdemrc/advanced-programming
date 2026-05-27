namespace PotionBrewLib.Models;

public class MineralIngredient : Ingredient
{
    public string MineType { get; set; }

    public MineralIngredient() : base()
    {
    }

    public MineralIngredient(string name, Rarity rarity, decimal basePrice, string description, string mineType)
        : base(name, rarity, basePrice, description)
    {
        MineType = mineType;
    }

    public override string GetSource()
    {
        return $"Mined from {MineType}";
    }
}

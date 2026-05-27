namespace PotionBrewLib.Models;

public class CreatureIngredient : Ingredient
{
    public string CreatureName { get; set; }

    public CreatureIngredient() : base()
    {
    }

    public CreatureIngredient(string name, Rarity rarity, decimal basePrice, string description, string creatureName)
        : base(name, rarity, basePrice, description)
    {
        CreatureName = creatureName;
    }

    public override string GetSource()
    {
        return $"Obtained from {CreatureName}";
    }
}

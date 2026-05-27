using System.Text.Json;
using System.Text.Json.Serialization;

namespace PotionBrewLib.Models;

[JsonConverter(typeof(IngredientConverter))]
public abstract class Ingredient
{
    public string Name { get; set; }
    public Rarity Rarity { get; set; }
    public decimal BasePrice { get; set; }
    public string Description { get; set; }

    // Parameterless constructor for serialization
    protected Ingredient()
    {
    }

    protected Ingredient(string name, Rarity rarity, decimal basePrice, string description)
    {
        Name = name;
        Rarity = rarity;
        BasePrice = basePrice;
        Description = description;
    }

    public abstract string GetSource();

    public override string ToString()
    {
        return $"{Name} ({Rarity}) - {BasePrice}g - {GetSource()}";
    }
}

public class IngredientConverter : JsonConverter<Ingredient>
{
    public override Ingredient Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
        {
            var root = doc.RootElement;
            if (!root.TryGetProperty("Type", out var typeProp))
            {
                throw new JsonException("Missing Type property for Ingredient serialization");
            }

            string type = typeProp.GetString();
            string name = root.GetProperty("Name").GetString();
            Rarity rarity = (Rarity)root.GetProperty("Rarity").GetInt32();
            decimal basePrice = root.GetProperty("BasePrice").GetDecimal();
            string description = root.GetProperty("Description").GetString();

            if (type == "Herb")
            {
                string region = root.GetProperty("Region").GetString();
                return new HerbIngredient(name, rarity, basePrice, description, region);
            }
            else if (type == "Mineral")
            {
                string mineType = root.GetProperty("MineType").GetString();
                return new MineralIngredient(name, rarity, basePrice, description, mineType);
            }
            else if (type == "Creature")
            {
                string creatureName = root.GetProperty("CreatureName").GetString();
                return new CreatureIngredient(name, rarity, basePrice, description, creatureName);
            }
            
            throw new JsonException($"Unknown ingredient type: {type}");
        }
    }

    public override void Write(Utf8JsonWriter writer, Ingredient value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("Name", value.Name);
        writer.WriteNumber("Rarity", (int)value.Rarity);
        writer.WriteNumber("BasePrice", value.BasePrice);
        writer.WriteString("Description", value.Description);

        if (value is HerbIngredient herb)
        {
            writer.WriteString("Type", "Herb");
            writer.WriteString("Region", herb.Region);
        }
        else if (value is MineralIngredient mineral)
        {
            writer.WriteString("Type", "Mineral");
            writer.WriteString("MineType", mineral.MineType);
        }
        else if (value is CreatureIngredient creature)
        {
            writer.WriteString("Type", "Creature");
            writer.WriteString("CreatureName", creature.CreatureName);
        }
        writer.WriteEndObject();
    }
}

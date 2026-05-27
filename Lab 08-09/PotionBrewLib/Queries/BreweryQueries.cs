using PotionBrewLib.Models;
using PotionBrewLib.Services;

namespace PotionBrewLib.Queries;

public record PotionEffectCount(PotionEffect Effect, int Count);

public static class BreweryQueries
{
    // 1. GetPotionsByEffect(PotionEffect) - filter + order by name
    public static IEnumerable<Potion> GetPotionsByEffect(this Brewery brewery, PotionEffect effect)
    {
        return brewery.GetAllPotions()
            .Where(p => p.Effect == effect)
            .OrderBy(p => p.Name);
    }

    // 2. GetBrewersByMinSkill(int minSkill) - filter + order by skill desc
    public static IEnumerable<Brewer> GetBrewersByMinSkill(this Brewery brewery, int minSkill)
    {
        return brewery.GetAllBrewers()
            .Where(b => b.SkillLevel >= minSkill)
            .OrderByDescending(b => b.SkillLevel);
    }

    // 3. GetIngredientsByRarity(Rarity) - filter + order by name
    public static IEnumerable<Ingredient> GetIngredientsByRarity(this Brewery brewery, Rarity rarity)
    {
        return brewery.GetAllIngredients()
            .Where(i => i.Rarity == rarity)
            .OrderBy(i => i.Name);
    }

    // 4. GetTopBrewersByPotionsBrewed(int count) - order desc + take
    public static IEnumerable<Brewer> GetTopBrewersByPotionsBrewed(this Brewery brewery, int count)
    {
        return brewery.GetAllBrewers()
            .OrderByDescending(b => b.PotionsBrewed)
            .Take(count);
    }

    // 5. GetPotionsByPriceRange(decimal min, decimal max) - filter + order by price
    public static IEnumerable<Potion> GetPotionsByPriceRange(this Brewery brewery, decimal min, decimal max)
    {
        return brewery.GetAllPotions()
            .Where(p => p.Price >= min && p.Price <= max)
            .OrderBy(p => p.Price);
    }

    // 6. GetOrdersByStatus(bool completed) - filter
    public static IEnumerable<BrewOrder> GetOrdersByStatus(this Brewery brewery, bool completed)
    {
        return brewery.GetAllOrders()
            .Where(o => o.IsCompleted == completed);
    }

    // 7. GetTotalRevenue() - sum of completed orders' potion prices
    public static decimal GetTotalRevenue(this Brewery brewery)
    {
        return brewery.GetAllOrders()
            .Where(o => o.IsCompleted)
            .Sum(o => o.Potion?.Price ?? 0);
    }

    // 8. GetPotionCountByEffect() - group by effect, return PotionEffectCount record
    public static IEnumerable<PotionEffectCount> GetPotionCountByEffect(this Brewery brewery)
    {
        return brewery.GetAllPotions()
            .GroupBy(p => p.Effect)
            .Select(g => new PotionEffectCount(g.Key, g.Count()));
    }

    // 9. GetAverageBrewerSkill() - average skill level
    public static double GetAverageBrewerSkill(this Brewery brewery)
    {
        var brewers = brewery.GetAllBrewers();
        if (brewers.Count == 0) return 0;
        return brewers.Average(b => b.SkillLevel);
    }

    // 10. GetMostExpensivePotions(int count) - order desc + take
    public static IEnumerable<Potion> GetMostExpensivePotions(this Brewery brewery, int count)
    {
        return brewery.GetAllPotions()
            .OrderByDescending(p => p.Price)
            .Take(count);
    }
}

using PotionBrewLib.Delegates;
using PotionBrewLib.Exceptions;
using PotionBrewLib.Models;

namespace PotionBrewLib.Services;

public class Brewery
{
    public string Name { get; set; }

    private readonly List<Brewer> _brewers = new List<Brewer>();
    private readonly List<Potion> _potions = new List<Potion>();
    private readonly List<BrewOrder> _orders = new List<BrewOrder>();
    private readonly List<Ingredient> _ingredients = new List<Ingredient>();

    public event BrewerAction OnBrewerHired;
    public event PotionAction OnPotionAdded;
    public event OrderAction OnOrderPlaced;
    public event OrderAction OnOrderCompleted;

    public Brewery()
    {
    }

    public Brewery(string name)
    {
        Name = name;
    }

    public void AddBrewer(Brewer brewer)
    {
        if (brewer == null) return;
        if (_brewers.Any(b => b.Name.Equals(brewer.Name, StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException($"A brewer named '{brewer.Name}' is already hired in the brewery.");
        }

        _brewers.Add(brewer);
        OnBrewerHired?.Invoke(brewer);
    }

    public void AddPotion(Potion potion)
    {
        if (potion == null) return;
        if (_potions.Any(p => p.Name.Equals(potion.Name, StringComparison.OrdinalIgnoreCase)))
        {
            throw new DuplicateRecipeException(potion.Name);
        }

        _potions.Add(potion);
        OnPotionAdded?.Invoke(potion);
    }

    public void AddIngredient(Ingredient ingredient)
    {
        if (ingredient == null) return;
        if (!_ingredients.Any(i => i.Name.Equals(ingredient.Name, StringComparison.OrdinalIgnoreCase)))
        {
            _ingredients.Add(ingredient);
        }
    }

    public void PlaceOrder(string potionName, string brewerName, string customerName)
    {
        var potion = _potions.FirstOrDefault(p => p.Name.Equals(potionName, StringComparison.OrdinalIgnoreCase));
        if (potion == null)
        {
            throw new InvalidPotionException($"Potion '{potionName}' is not available in our recipes.");
        }

        var brewer = _brewers.FirstOrDefault(b => b.Name.Equals(brewerName, StringComparison.OrdinalIgnoreCase));
        if (brewer == null)
        {
            throw new BrewerNotFoundException(brewerName);
        }

        if (!brewer.CanBrew(potion))
        {
            throw new InsufficientSkillException(brewer.Name, potion.Name);
        }

        var order = new BrewOrder(potion, brewer, customerName);
        _orders.Add(order);
        OnOrderPlaced?.Invoke(order);
    }

    public void CompleteOrder(int orderId)
    {
        var order = _orders.FirstOrDefault(o => o.Id == orderId);
        if (order != null && !order.IsCompleted)
        {
            order.Complete();
            OnOrderCompleted?.Invoke(order);
        }
    }

    public void ForEachBrewer(BrewerAction action)
    {
        foreach (var brewer in _brewers)
        {
            action(brewer);
        }
    }

    public void ForEachPotion(PotionAction action)
    {
        foreach (var potion in _potions)
        {
            action(potion);
        }
    }

    public List<Brewer> GetAllBrewers() => _brewers;
    public List<Potion> GetAllPotions() => _potions;
    public List<BrewOrder> GetAllOrders() => _orders;
    public List<Ingredient> GetAllIngredients() => _ingredients;

    // Load data from deserialized source
    public void LoadData(List<Ingredient> ingredients, List<Potion> potions, List<Brewer> brewers, List<BrewOrder> orders)
    {
        _ingredients.Clear();
        if (ingredients != null) _ingredients.AddRange(ingredients);

        _potions.Clear();
        if (potions != null) _potions.AddRange(potions);

        _brewers.Clear();
        if (brewers != null) _brewers.AddRange(brewers);

        _orders.Clear();
        if (orders != null)
        {
            _orders.AddRange(orders);
            // restore next ID counter for orders
            int maxId = _orders.Count > 0 ? _orders.Max(o => o.Id) : 0;
            BrewOrder.SetNextId(maxId + 1);
        }
    }
}

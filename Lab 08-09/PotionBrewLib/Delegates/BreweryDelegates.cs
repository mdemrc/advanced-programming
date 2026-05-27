using PotionBrewLib.Models;

namespace PotionBrewLib.Delegates;

public delegate void BrewerAction(Brewer brewer);
public delegate void PotionAction(Potion potion);
public delegate void OrderAction(BrewOrder order);

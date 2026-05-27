namespace PotionBrewLib.Exceptions;

public class DuplicateRecipeException : Exception
{
    public DuplicateRecipeException(string name) 
        : base($"A recipe with the name '{name}' already exists in the brewery.")
    {
    }
}

public class InsufficientSkillException : Exception
{
    public InsufficientSkillException(string brewerName, string potionName) 
        : base($"Brewer '{brewerName}' does not have enough skill to brew '{potionName}'.")
    {
    }
}

public class BrewerNotFoundException : Exception
{
    public BrewerNotFoundException(string name) 
        : base($"Brewer '{name}' could not be found in the brewery roster.")
    {
    }
}

public class InvalidPotionException : Exception
{
    public InvalidPotionException(string reason) 
        : base($"Invalid potion configuration: {reason}")
    {
    }
}

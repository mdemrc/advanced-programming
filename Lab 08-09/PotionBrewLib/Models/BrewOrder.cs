namespace PotionBrewLib.Models;

public class BrewOrder
{
    private static int _nextId = 1;

    public int Id { get; set; }
    public Potion Potion { get; set; }
    public Brewer Brewer { get; set; }
    public string CustomerName { get; set; }
    public DateTime OrderDate { get; set; }
    public bool IsCompleted { get; set; }

    public BrewOrder()
    {
    }

    public BrewOrder(Potion potion, Brewer brewer, string customerName)
    {
        Id = _nextId++;
        Potion = potion;
        Brewer = brewer;
        CustomerName = customerName;
        OrderDate = DateTime.Now;
        IsCompleted = false;
    }

    public void Complete()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            if (Brewer != null && Potion != null)
            {
                Brewer.PotionsBrewed++;
                Brewer.GoldEarned += Potion.Price;
            }
        }
    }

    public static void SetNextId(int id)
    {
        _nextId = id;
    }

    public override string ToString()
    {
        string status = IsCompleted ? "Completed" : "Pending";
        return $"Order #{Id}: {Potion?.Name} brewed by {Brewer?.Name} for {CustomerName} - [{status}]";
    }
}

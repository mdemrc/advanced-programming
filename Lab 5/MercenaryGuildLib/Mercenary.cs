namespace MercenaryGuildLib;

// represents a single mercenary
public class Mercenary
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int ExperiencePoints { get; set; }
    public int CurrentHealth { get; set; }
    public int MaxHealth { get; set; }
    public int Damage { get; set; }
    public int GoldCoins { get; set; }

    public Mercenary(string name, int level, int maxHealth, int damage)
    {
        Name = name;
        Level = level;
        ExperiencePoints = 0;
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        Damage = damage;
        GoldCoins = 0;
    }

    public override string ToString()
    {
        return $"{Name} (lvl {Level}, xp {ExperiencePoints}, hp {CurrentHealth}/{MaxHealth}, dmg {Damage}, gold {GoldCoins})";
    }
}

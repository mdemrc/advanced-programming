namespace MageGuildLibrary.Models;

// represents a single spell that a mage can cast
public class Spell
{
    public string Name { get; set; }
    public SpellType Type { get; set; }
    public int ManaCost { get; set; }
    public int Cooldown { get; set; }
    public int Effect { get; set; }

    public Spell(string name, SpellType type, int manaCost, int cooldown, int effect)
    {
        Name = name;
        Type = type;
        ManaCost = manaCost;
        Cooldown = cooldown;
        Effect = effect;
    }

    public override string ToString()
    {
        return $"{Name} [{Type}] mana: {ManaCost}, cooldown: {Cooldown}s, effect: {Effect}";
    }

    // Equals and GetHashCode use ToString so Distinct() works correctly
    public override bool Equals(object obj)
    {
        if (obj is not Spell other) return false;
        return ToString() == other.ToString();
    }

    public override int GetHashCode()
    {
        return ToString().GetHashCode();
    }
}

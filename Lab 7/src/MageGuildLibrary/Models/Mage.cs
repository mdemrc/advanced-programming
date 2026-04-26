namespace MageGuildLibrary.Models;

// represents a mage that belongs to the guild
public class Mage
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int ExperiencePoints { get; set; }
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Intelligence { get; set; }
    public int CurrentHealth { get; set; }
    public int MaxHealth { get; set; }
    public int CurrentMana { get; set; }
    public int MaxMana { get; set; }
    public int Damage { get; set; }
    public int PhysicalResistance { get; set; }
    public int FireResistance { get; set; }
    public int FrostResistance { get; set; }
    public int PoisonResistance { get; set; }
    public SpellBook SpellBook { get; set; }

    public Mage(string name, int level, int experiencePoints,
                int strength, int dexterity, int intelligence,
                int currentHealth, int maxHealth,
                int currentMana, int maxMana,
                int damage,
                int physicalResistance, int fireResistance,
                int frostResistance, int poisonResistance,
                SpellBook spellBook)
    {
        Name = name;
        Level = level;
        ExperiencePoints = experiencePoints;
        Strength = strength;
        Dexterity = dexterity;
        Intelligence = intelligence;
        CurrentHealth = currentHealth;
        MaxHealth = maxHealth;
        CurrentMana = currentMana;
        MaxMana = maxMana;
        Damage = damage;
        PhysicalResistance = physicalResistance;
        FireResistance = fireResistance;
        FrostResistance = frostResistance;
        PoisonResistance = poisonResistance;
        SpellBook = spellBook;
    }

    // sum of all resistances, useful for special mission query
    public int TotalResistance =>
        PhysicalResistance + FireResistance + FrostResistance + PoisonResistance;

    public override string ToString()
    {
        return $"{Name} (lvl {Level}, exp {ExperiencePoints}) " +
               $"STR {Strength}, DEX {Dexterity}, INT {Intelligence} | " +
               $"HP {CurrentHealth}/{MaxHealth}, MP {CurrentMana}/{MaxMana}, DMG {Damage} | " +
               $"resist phys {PhysicalResistance}, fire {FireResistance}, frost {FrostResistance}, poison {PoisonResistance} | " +
               $"spells: {SpellBook.Count}";
    }
}

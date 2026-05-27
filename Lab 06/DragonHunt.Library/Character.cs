using System;

namespace DragonHunt.Library
{
    // base class for every character in the game
    public abstract class Character : IComparable<Character>
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int ExperiencePoints { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public int CurrentHealth { get; set; }
        public int MaxHealth { get; set; }
        public int Damage { get; set; }
        public int DamageResistance { get; set; }

        protected Character() { }

        protected Character(string name, int level, int experiencePoints,
            int strength, int dexterity, int intelligence,
            int currentHealth, int maxHealth, int damage, int damageResistance)
        {
            Name = name;
            Level = level;
            ExperiencePoints = experiencePoints;
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
            CurrentHealth = currentHealth;
            MaxHealth = maxHealth;
            Damage = damage;
            DamageResistance = damageResistance;
        }

        // damage dealt per round, can be overridden
        public virtual int RoundDamage => Damage + Strength / 2;

        public bool IsDead => CurrentHealth <= 0;

        // increase damage when picking up a weapon
        public virtual void Arm(int extraDamage)
        {
            Damage += extraDamage;
        }

        // increase resistance when wearing armor
        public virtual void PutOnArmor(int extraResistance)
        {
            DamageResistance += extraResistance;
        }

        // take some damage, resistance reduces it
        public virtual void TakeDamage(int incomingDamage)
        {
            int finalDamage = incomingDamage - DamageResistance;
            if (finalDamage < 0) finalDamage = 0;
            CurrentHealth -= finalDamage;
            if (CurrentHealth < 0) CurrentHealth = 0;
        }

        // upgrade attributes, restore hp, override in subclasses for custom growth
        public virtual void LevelUp()
        {
            Level++;
            Strength += 2;
            Dexterity += 2;
            Intelligence += 2;
            MaxHealth += 10;
            CurrentHealth = MaxHealth;
        }

        // exp threshold formula
        public static int ExperienceForNextLevel(int currentLevel)
        {
            return currentLevel * 100;
        }

        // gain exp and level up if threshold reached
        public void GainExperience(int amount)
        {
            ExperiencePoints += amount;
            while (ExperiencePoints >= ExperienceForNextLevel(Level))
            {
                LevelUp();
            }
        }

        public int CompareTo(Character other)
        {
            if (other == null) return 1;
            return Level.CompareTo(other.Level);
        }

        public override string ToString()
        {
            return $"{GetType().Name} {Name} | Lvl {Level} | HP {CurrentHealth}/{MaxHealth} " +
                   $"| STR {Strength} DEX {Dexterity} INT {Intelligence} " +
                   $"| DMG {Damage} RES {DamageResistance} | EXP {ExperiencePoints}";
        }
    }
}

using System;

namespace DragonHunt.Library
{
    public class Archer : Character
    {
        // chance in percent to fully avoid damage
        public int DodgeChance { get; set; }

        private static readonly Random Rng = new Random();

        public Archer(string name)
            : base(name, 1, 0, 7, 12, 7, 40, 40, 6, 2)
        {
            DodgeChance = 25;
        }

        public override int RoundDamage => Damage + Dexterity;

        public override void TakeDamage(int incomingDamage)
        {
            // roll the dice for a dodge
            if (Rng.Next(0, 100) < DodgeChance)
            {
                return;
            }
            base.TakeDamage(incomingDamage);
        }

        public override void LevelUp()
        {
            Level++;
            Strength += 1;
            Dexterity += 4;
            Intelligence += 1;
            MaxHealth += 8;
            CurrentHealth = MaxHealth;
            if (DodgeChance < 60) DodgeChance += 2;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Dodge {DodgeChance}%";
        }
    }
}

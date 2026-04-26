namespace DragonHunt.Library
{
    public class Wizard : Character
    {
        public int CurrentMana { get; set; }
        public int MaxMana { get; set; }

        public Wizard(string name)
            : base(name, 1, 0, 5, 7, 14, 30, 30, 5, 1)
        {
            CurrentMana = 50;
            MaxMana = 50;
        }

        // wizard damage scales with intelligence
        public override int RoundDamage => Damage + Intelligence;

        public override void LevelUp()
        {
            Level++;
            Strength += 1;
            Dexterity += 1;
            Intelligence += 4;
            MaxHealth += 6;
            CurrentHealth = MaxHealth;
            MaxMana += 15;
            CurrentMana = MaxMana;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Mana {CurrentMana}/{MaxMana}";
        }
    }
}

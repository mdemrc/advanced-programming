namespace DragonHunt.Library
{
    public class Warrior : Character
    {
        public int AttacksPerRound { get; set; }

        // simple constructor, hard coded stats for a starting warrior
        public Warrior(string name)
            : base(name, 1, 0, 12, 8, 6, 50, 50, 8, 4)
        {
            AttacksPerRound = 2;
        }

        // warrior hits multiple times per round
        public override int RoundDamage => (Damage + Strength / 2) * AttacksPerRound;

        public override void LevelUp()
        {
            Level++;
            Strength += 4;
            Dexterity += 1;
            Intelligence += 1;
            MaxHealth += 15;
            CurrentHealth = MaxHealth;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Attacks/round {AttacksPerRound}";
        }
    }
}

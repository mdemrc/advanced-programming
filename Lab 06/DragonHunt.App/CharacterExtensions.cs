using DragonHunt.Library;

namespace DragonHunt.App
{
    // extra helpers for character classes
    public static class CharacterExtensions
    {
        // drink a potion of full healing
        public static void DrinkFullHealingPotion(this Character character)
        {
            character.CurrentHealth = character.MaxHealth;
        }

        // wizard regenerates mana, capped at max
        public static void RegenerateMana(this Wizard wizard, int amount)
        {
            wizard.CurrentMana += amount;
            if (wizard.CurrentMana > wizard.MaxMana)
            {
                wizard.CurrentMana = wizard.MaxMana;
            }
        }

        // remove a weapon, lower damage
        public static void Disarm(this Character character, int amount)
        {
            character.Damage -= amount;
            if (character.Damage < 0) character.Damage = 0;
        }

        // remove armor, lower resistance
        public static void TakeOffArmor(this Character character, int amount)
        {
            character.DamageResistance -= amount;
            if (character.DamageResistance < 0) character.DamageResistance = 0;
        }
    }
}

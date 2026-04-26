using MageGuildLibrary.Models;

namespace MageGuildApp;

// builds the demo guild with the most renowned mages of Sisharp
public static class GuildFactory
{
    public static MageGuild BuildDemoGuild()
    {
        var guild = new MageGuild();

        // common spells used across mages
        var fireball = new Spell("Fireball", SpellType.Offensive, 25, 3, 80);
        var frostbolt = new Spell("Frostbolt", SpellType.Offensive, 20, 2, 60);
        var lightning = new Spell("Lightning Strike", SpellType.Offensive, 30, 4, 100);
        var poisonCloud = new Spell("Poison Cloud", SpellType.Offensive, 35, 5, 70);
        var arcaneBlast = new Spell("Arcane Blast", SpellType.Offensive, 40, 6, 120);

        var shield = new Spell("Mana Shield", SpellType.Defensive, 30, 8, 150);
        var stoneSkin = new Spell("Stone Skin", SpellType.Defensive, 25, 6, 100);
        var reflect = new Spell("Spell Reflect", SpellType.Defensive, 35, 10, 80);
        var ironWill = new Spell("Iron Will", SpellType.Defensive, 20, 5, 60);

        var heal = new Spell("Healing Touch", SpellType.Healing, 20, 3, 70);
        var greaterHeal = new Spell("Greater Heal", SpellType.Healing, 40, 6, 150);
        var renew = new Spell("Renew", SpellType.Healing, 15, 4, 40);

        // Gandalf the well known one
        var gandalfBook = new SpellBook { fireball, lightning, shield, heal, arcaneBlast, stoneSkin };
        var gandalf = new Mage("Gandalf", 12, 5400,
            18, 14, 28,
            180, 180, 200, 200,
            45, 20, 25, 15, 10,
            gandalfBook);

        var merlinBook = new SpellBook { fireball, frostbolt, shield, heal, greaterHeal, renew, arcaneBlast };
        var merlin = new Mage("Merlin", 15, 7200,
            16, 18, 30,
            220, 220, 260, 260,
            50, 22, 28, 20, 18,
            merlinBook);

        var morganaBook = new SpellBook { poisonCloud, frostbolt, reflect, ironWill };
        var morgana = new Mage("Morgana", 8, 2900,
            12, 22, 24,
            140, 140, 160, 160,
            38, 14, 12, 18, 25,
            morganaBook);

        var saurmanBook = new SpellBook { fireball, lightning, arcaneBlast, stoneSkin, reflect };
        var saurman = new Mage("Saruman", 10, 3800,
            14, 16, 26,
            160, 160, 180, 180,
            42, 18, 20, 16, 12,
            saurmanBook);

        var elaraBook = new SpellBook { heal, greaterHeal, renew, shield };
        var elara = new Mage("Elara", 6, 1500,
            10, 12, 22,
            110, 110, 140, 140,
            25, 10, 14, 14, 16,
            elaraBook);

        // a fainted mage so the Any() query returns true
        var thoricBook = new SpellBook { ironWill, frostbolt };
        var thoric = new Mage("Thoric", 4, 800,
            22, 11, 14,
            0, 90, 60, 80,
            30, 16, 8, 10, 6,
            thoricBook);

        var lyraBook = new SpellBook { fireball, frostbolt, poisonCloud, lightning, arcaneBlast, shield, heal };
        var lyra = new Mage("Lyra", 14, 6500,
            15, 19, 27,
            200, 200, 240, 240,
            48, 20, 24, 22, 20,
            lyraBook);

        guild.Recruit(gandalf);
        guild.Recruit(merlin);
        guild.Recruit(morgana);
        guild.Recruit(saurman);
        guild.Recruit(elara);
        guild.Recruit(thoric);
        guild.Recruit(lyra);

        return guild;
    }
}

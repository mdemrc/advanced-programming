using System.Text;

namespace MageGuildLibrary.Models;

// records used as projection results in some queries
public record MageSpellArsenal(string Name, int SpellCount, int Mana);
public record MageVersatility(string Name, int Level, double AverageStat);
public record SpellTypeCount(SpellType Type, int Count);
public record MagePowerInfo(string Name, int Level);
public record MageMissionInfo(string Name, int Level, int TotalResistance,
                              int Physical, int Fire, int Frost, int Poison);

// the guild aggregates a list of mages and exposes LINQ based queries
public class MageGuild
{
    public List<Mage> Members { get; } = new List<Mage>();

    // add a new mage to the guild
    public void Recruit(Mage mage)
    {
        Members.Add(mage);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine("Mage guild members:");
        foreach (var m in Members)
        {
            sb.AppendLine(m.ToString());
        }
        return sb.ToString();
    }

    // 1) all mages sorted ascending by name
    public IEnumerable<Mage> GetAllMages()
    {
        return Members.OrderBy(m => m.Name);
    }

    // 2) mages above given level sorted by level
    public IEnumerable<Mage> GetExperiencedMages(int minLevel)
    {
        return Members
            .Where(m => m.Level > minLevel)
            .OrderBy(m => m.Level);
    }

    // 3) intelligence > 20 and level <= maxLevel, sorted by intelligence desc
    public IEnumerable<Mage> GetTalentedMages(int maxLevel)
    {
        return Members
            .Where(m => m.Intelligence > 20 && m.Level <= maxLevel)
            .OrderByDescending(m => m.Intelligence);
    }

    // 4) total mana of fighter mages above level 2 with dex > 10
    public int GetCombatMagesManaPotential()
    {
        return Members
            .Where(m => m.Level > 2 && m.Dexterity > 10)
            .Sum(m => m.MaxMana);
    }

    // 5) mages with the largest spell arsenal
    public IEnumerable<MageSpellArsenal> GetMagesWithBiggestArsenal(int minSpellCount)
    {
        return Members
            .Where(m => m.SpellBook.Count >= minSpellCount)
            .Select(m => new MageSpellArsenal(m.Name, m.SpellBook.Count, m.MaxMana))
            .OrderByDescending(r => r.SpellCount);
    }

    // 6) most versatile mages by average of str, dex, int
    public IEnumerable<MageVersatility> GetMostVersatileMages()
    {
        return Members
            .Select(m => new MageVersatility(
                m.Name,
                m.Level,
                (m.Strength + m.Dexterity + m.Intelligence) / 3.0))
            .OrderByDescending(r => r.AverageStat);
    }

    // 7) mages who have learned the most spells
    public IEnumerable<string> GetMagesWithMostSpells()
    {
        if (Members.Count == 0) return Enumerable.Empty<string>();
        // first find the max spell count
        int maxSpells = Members.Max(m => m.SpellBook.Count);
        // then pick mages with that count
        return Members
            .Where(m => m.SpellBook.Count == maxSpells)
            .Select(m => m.Name);
    }

    // 8) all spells across the guild without duplicates
    public IEnumerable<Spell> GetAllUniqueSpells()
    {
        return Members
            .SelectMany(m => m.SpellBook)
            .Distinct();
    }

    // 9) unique spells of a given type from all mages
    public IEnumerable<Spell> GetUniqueSpellsByType(SpellType type)
    {
        return Members
            .SelectMany(m => m.SpellBook)
            .Where(s => s.Type == type)
            .Distinct();
    }

    // 10) spells of given type from a specific mage
    public IEnumerable<Spell> GetMageSpellsByType(string mageName, SpellType type)
    {
        var mage = Members.Single(m => m.Name == mageName);
        return mage.SpellBook.Where(s => s.Type == type);
    }

    // 11) count of unique spells per type across the guild
    public IEnumerable<SpellTypeCount> GetSpellCountsByType()
    {
        return Members
            .SelectMany(m => m.SpellBook)
            .Distinct()
            .GroupBy(s => s.Type)
            .Select(g => new SpellTypeCount(g.Key, g.Count()));
    }

    // 12) count of spells per type for a specific mage
    public IEnumerable<SpellTypeCount> GetMageSpellCountsByType(string mageName)
    {
        var mage = Members.Single(m => m.Name == mageName);
        return mage.SpellBook
            .GroupBy(s => s.Type)
            .Select(g => new SpellTypeCount(g.Key, g.Count()));
    }

    // 13) most powerful mages with skip and take
    public IEnumerable<MagePowerInfo> GetMostPowerfulMages(int skip, int take)
    {
        return Members
            .OrderByDescending(m => m.Level)
            .ThenByDescending(m => m.ExperiencePoints)
            .Skip(skip)
            .Take(take)
            .Select(m => new MagePowerInfo(m.Name, m.Level));
    }

    // 14) check if every mage has full health and full mana
    public bool AreAllReadyForTournament()
    {
        return Members.All(m => m.CurrentHealth == m.MaxHealth
                             && m.CurrentMana == m.MaxMana);
    }

    // 15) check if any mage has fainted
    public bool DidAnyoneFaint()
    {
        return Members.Any(m => m.CurrentHealth == 0);
    }

    // 16) top three mages above given level by total resistance
    public IEnumerable<MageMissionInfo> GetBestForSpecialMission(int minLevel)
    {
        return Members
            .Where(m => m.Level > minLevel)
            .OrderByDescending(m => m.TotalResistance)
            .Take(3)
            .Select(m => new MageMissionInfo(
                m.Name, m.Level, m.TotalResistance,
                m.PhysicalResistance, m.FireResistance,
                m.FrostResistance, m.PoisonResistance));
    }
}

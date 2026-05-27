namespace PotionBrewLib.Models;

public class Brewer
{
    public string Name { get; set; }
    public int SkillLevel { get; set; }
    public PotionEffect Specialization { get; set; }
    public int PotionsBrewed { get; set; }
    public decimal GoldEarned { get; set; }

    public Brewer()
    {
    }

    public Brewer(string name, int skillLevel, PotionEffect specialization)
    {
        Name = name;
        SkillLevel = skillLevel;
        Specialization = specialization;
        PotionsBrewed = 0;
        GoldEarned = 0;
    }

    public bool CanBrew(Potion potion)
    {
        int requiredLevel = potion.Rarity switch
        {
            Rarity.Common => 1,
            Rarity.Uncommon => 3,
            Rarity.Rare => 5,
            Rarity.Legendary => 8,
            _ => 1
        };
        return SkillLevel >= requiredLevel;
    }

    public override string ToString()
    {
        return $"{Name} (Lvl {SkillLevel}) - Spec: {Specialization} - Brews: {PotionsBrewed} (Earned: {GoldEarned}g)";
    }
}

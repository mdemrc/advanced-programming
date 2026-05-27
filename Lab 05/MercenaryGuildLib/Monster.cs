namespace MercenaryGuildLib;

// represents a monster a mercenary will face
public class Monster
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }

    public Monster(string name, int health, int damage)
    {
        Name = name;
        Health = health;
        Damage = damage;
    }

    public override string ToString()
    {
        return $"{Name} (hp {Health}, dmg {Damage})";
    }
}

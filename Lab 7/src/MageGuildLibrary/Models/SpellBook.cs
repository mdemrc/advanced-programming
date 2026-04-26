using System.Text;

namespace MageGuildLibrary.Models;

// a spell book is just a strongly typed list of spells
public class SpellBook : List<Spell>
{
    public override string ToString()
    {
        var sb = new StringBuilder();
        // this refers to the list itself
        foreach (var spell in this)
        {
            sb.AppendLine(spell.ToString());
        }
        return sb.ToString();
    }
}

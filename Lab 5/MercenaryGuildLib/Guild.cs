namespace MercenaryGuildLib;

// the main guild that holds mercenaries and quests
public class Guild
{
    public string Name { get; set; }

    private List<Mercenary> mercenaries = new List<Mercenary>();
    private List<Quest> quests = new List<Quest>();

    // events that outside code can subscribe to
    public event MercenaryAction OnMercenaryHired;
    public event QuestAction OnQuestAdded;
    public event MercenaryQuestAction OnQuestCompleting;
    public event MercenaryQuestAction OnQuestCompleted;

    public Guild(string name)
    {
        Name = name;
    }

    // adds a mercenary, names must be unique
    public void HireMercenary(Mercenary mercenary)
    {
        if (mercenaries.Any(m => m.Name == mercenary.Name))
            throw new DuplicateMercenaryException(mercenary.Name);

        mercenaries.Add(mercenary);
        OnMercenaryHired?.Invoke(mercenary);
    }

    // registers a quest, names must be unique
    public void AddQuest(Quest quest)
    {
        if (quests.Any(q => q.Name == quest.Name))
            throw new DuplicateQuestException(quest.Name);

        quests.Add(quest);
        OnQuestAdded?.Invoke(quest);
    }

    // sends a mercenary on a quest
    public void SendOnQuest(string mercenaryName, string questName)
    {
        Mercenary mercenary = FindMercenary(mercenaryName)
            ?? throw new MercenaryNotFoundException(mercenaryName);

        Quest quest = FindQuest(questName)
            ?? throw new QuestNotFoundException(questName);

        OnQuestCompleting?.Invoke(mercenary, quest);

        // simple combat simulation
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\n>> {mercenary.Name} sets out on '{quest.Name}' to fight {quest.Monster.Name}...");
        Console.ResetColor();

        int monsterHp = quest.Monster.Health;
        int mercHp = mercenary.CurrentHealth;

        // mercenary attacks first each round
        while (monsterHp > 0 && mercHp > 0)
        {
            monsterHp -= mercenary.Damage;
            if (monsterHp <= 0) break;
            mercHp -= quest.Monster.Damage;
        }

        mercenary.CurrentHealth = Math.Max(0, mercHp);

        if (monsterHp <= 0 && mercHp > 0)
        {
            // success
            mercenary.ExperiencePoints += quest.ExperienceReward;
            mercenary.GoldCoins += quest.GoldReward;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"   Victory! {mercenary.Name} defeated {quest.Monster.Name}.");
            Console.WriteLine($"   Earned {quest.ExperienceReward} xp and {quest.GoldReward} gold. Hp left: {mercenary.CurrentHealth}/{mercenary.MaxHealth}");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"   Defeat! {mercenary.Name} was beaten by {quest.Monster.Name}. Hp left: {mercenary.CurrentHealth}/{mercenary.MaxHealth}");
            Console.ResetColor();
        }

        OnQuestCompleted?.Invoke(mercenary, quest);
    }

    // run a custom action on every mercenary
    public void ForEachMercenary(MercenaryAction action)
    {
        foreach (Mercenary m in mercenaries)
            action(m);
    }

    // run a custom action on every quest
    public void ForEachQuest(QuestAction action)
    {
        foreach (Quest q in quests)
            action(q);
    }

    // search helpers using Find / FindAll with lambdas
    public Mercenary FindMercenary(string name)
    {
        return mercenaries.Find(m => m.Name == name);
    }

    public List<Mercenary> FindStrongMercenaries(int minLevel, int minMaxHealth)
    {
        return mercenaries.FindAll(m => m.Level > minLevel || m.MaxHealth > minMaxHealth);
    }

    public Quest FindQuest(string name)
    {
        return quests.Find(q => q.Name == name);
    }

    public List<Quest> FindQuestsByLocationAndDifficulty(string location, QuestDifficulty difficulty)
    {
        return quests.FindAll(q => q.Location == location && q.Difficulty == difficulty);
    }

    public override string ToString()
    {
        return $"Guild '{Name}' with {mercenaries.Count} mercenaries and {quests.Count} quests";
    }
}

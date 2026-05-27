using MercenaryGuildLib;

// helper to print colored lines
static void PrintColored(string text, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.WriteLine(text);
    Console.ResetColor();
}

static void PrintHeader(string title)
{
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("=== " + title + " ===");
    Console.ResetColor();
}

// build a guild with some content
Guild guild = new Guild("Iron Hand Guild");

// event handlers attached BEFORE adding things, so they fire
guild.OnMercenaryHired += m =>
    PrintColored($"[event] new mercenary hired: {m.Name}", ConsoleColor.Magenta);

guild.OnQuestAdded += q =>
    PrintColored($"[event] new quest registered: {q.Name} ({q.Difficulty})", ConsoleColor.Magenta);

guild.OnQuestCompleting += (m, q) =>
    PrintColored($"[event] {m.Name} is preparing for '{q.Name}'...", ConsoleColor.DarkYellow);

guild.OnQuestCompleted += (m, q) =>
{
    if (m.CurrentHealth > 0)
        PrintColored($"[event] {m.Name} returned alive from '{q.Name}'. Total gold: {m.GoldCoins}", ConsoleColor.DarkGreen);
    else
        PrintColored($"[event] {m.Name} did not survive '{q.Name}'.", ConsoleColor.DarkRed);
};

PrintHeader("Hiring mercenaries");
guild.HireMercenary(new Mercenary("Aldric", 3, 80, 15));
guild.HireMercenary(new Mercenary("Brina", 5, 70, 20));
guild.HireMercenary(new Mercenary("Cedric", 1, 50, 8));
guild.HireMercenary(new Mercenary("Dara", 7, 120, 25));

PrintHeader("Registering quests");
guild.AddQuest(new Quest("Goblin Cleanup", "Clear goblins from the farm.",
    "Greenfield", QuestDifficulty.Easy, new Monster("Goblin", 30, 5), 50, 20));
guild.AddQuest(new Quest("Wolf Pack", "Hunt down a wolf pack.",
    "Darkwood", QuestDifficulty.NotSoEasy, new Monster("Alpha Wolf", 60, 10), 100, 40));
guild.AddQuest(new Quest("Troll Bridge", "Defeat the troll under the bridge.",
    "Darkwood", QuestDifficulty.Hard, new Monster("Bridge Troll", 150, 18), 250, 120));
guild.AddQuest(new Quest("Dragon Lair", "Slay the ancient red dragon.",
    "Mount Doom", QuestDifficulty.NightmarishlyHard, new Monster("Red Dragon", 500, 50), 2000, 1500));

// using delegates passed to ForEach methods
PrintHeader("All mercenaries");
guild.ForEachMercenary(m => PrintColored(" - " + m, ConsoleColor.White));

PrintHeader("All quests with their monsters");
guild.ForEachQuest(q => PrintColored($" - {q.Name} -> monster: {q.Monster}", ConsoleColor.White));

// search tests
PrintHeader("Searching: mercenary 'Brina'");
Mercenary found = guild.FindMercenary("Brina");
if (found != null) PrintColored(found.ToString(), ConsoleColor.Yellow);

PrintHeader("Searching: mercenaries with level > 2 OR maxHealth > 100");
foreach (Mercenary m in guild.FindStrongMercenaries(2, 100))
    PrintColored(" * " + m, ConsoleColor.Yellow);

PrintHeader("Searching: quest 'Troll Bridge'");
Quest q1 = guild.FindQuest("Troll Bridge");
if (q1 != null) PrintColored(q1.ToString(), ConsoleColor.Yellow);

PrintHeader("Searching: quests in Darkwood with NotSoEasy difficulty");
foreach (Quest q in guild.FindQuestsByLocationAndDifficulty("Darkwood", QuestDifficulty.NotSoEasy))
    PrintColored(" * " + q, ConsoleColor.Yellow);

// duplicate exception test
PrintHeader("Trying to hire a duplicate mercenary");
try
{
    guild.HireMercenary(new Mercenary("Aldric", 1, 10, 1));
}
catch (DuplicateMercenaryException ex)
{
    PrintColored("caught: " + ex.Message, ConsoleColor.Red);
}

// send mercenaries on quests
PrintHeader("Sending mercenaries on quests");
guild.SendOnQuest("Brina", "Goblin Cleanup");
guild.SendOnQuest("Dara", "Troll Bridge");
guild.SendOnQuest("Cedric", "Dragon Lair");

PrintHeader("Final mercenary state");
guild.ForEachMercenary(m => PrintColored(" - " + m, ConsoleColor.White));

Console.WriteLine();
PrintColored(guild.ToString(), ConsoleColor.Cyan);

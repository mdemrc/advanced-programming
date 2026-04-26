namespace MercenaryGuildLib;

// thrown when a mercenary with the same name is already in the guild
public class DuplicateMercenaryException : Exception
{
    public DuplicateMercenaryException(string name)
        : base($"Mercenary with name '{name}' is already in the guild.") { }
}

// thrown when a quest with the same name is already registered
public class DuplicateQuestException : Exception
{
    public DuplicateQuestException(string name)
        : base($"Quest with name '{name}' is already registered.") { }
}

// thrown when a mercenary cannot be found
public class MercenaryNotFoundException : Exception
{
    public MercenaryNotFoundException(string name)
        : base($"Mercenary '{name}' was not found in the guild.") { }
}

// thrown when a quest cannot be found
public class QuestNotFoundException : Exception
{
    public QuestNotFoundException(string name)
        : base($"Quest '{name}' was not found in the guild.") { }
}

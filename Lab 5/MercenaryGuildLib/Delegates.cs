namespace MercenaryGuildLib;

// delegates used by the guild for actions and events

// action that takes a mercenary and returns nothing
public delegate void MercenaryAction(Mercenary mercenary);

// action that takes a quest and returns nothing
public delegate void QuestAction(Quest quest);

// action that takes both a mercenary and a quest
public delegate void MercenaryQuestAction(Mercenary mercenary, Quest quest);

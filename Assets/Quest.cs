using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public string questName;
    public string questDescription;
    public bool isCompleted;

    public Quest(string name, string description)
    {
        questName = name;
        questDescription = description;
        isCompleted = false;
    }
}

public class QuestLog
{
    private List<Quest> quests = new List<Quest>();

    public void AddQuest(string name, string description)
    {
        Quest newQuest = new Quest(name, description);
        quests.Add(newQuest);
    }

    public void MarkQuestAsCompleted(string questName)
    {
        Quest quest = quests.Find(q => q.questName.Equals(questName, StringComparison.OrdinalIgnoreCase));
        if (quest != null)
        {
            quest.isCompleted = true;
        }
    }

    public void DisplayQuestLog()
    {
        Console.WriteLine("Quest Log:");
        foreach (Quest quest in quests)
        {
            string status = quest.isCompleted ? " (Completed)" : " (Incomplete)";
            Console.WriteLine($"{quest.questName}: {quest.questDescription}{status}");
        }
    }
}

class Program
{
    static void Main()
    {
        QuestLog questLog = new QuestLog();


        questLog.AddQuest("Swine and dine, the pork-fect adventure", "Assist the pig, Piggy to find the ultimate feast in the whimsical Sylvanwood forest.");
        questLog.AddQuest("Snout of this world, the swine-tillating task", "Help Sir Oinksalot to uncover the stolen prized truffle collection, his extraordinary, snout-worthy treasures");


        questLog.MarkQuestAsCompleted("Swine and dine, the pork-fect adventure");
        questLog.MarkQuestAsCompleted("Snout of this world, the swine-tillating task");

        questLog.DisplayQuestLog();
    }
}

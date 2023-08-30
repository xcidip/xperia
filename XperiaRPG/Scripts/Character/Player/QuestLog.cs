using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using XperiaRPG.Scripts.Character.Player;
using XperiaRPG.Scripts.Character.Player.CharacterCreation;
using XperiaRPG.Scripts.Characters;
using XperiaRPG.Scripts.Items;
using XperiaRPG.Scripts.Skills;

namespace XperiaRPG.Scripts.Character.Player
{
    public class QuestLog
    {
        public List<Quest> List { get; set; }
        private QuestDifficultyList QuestDifficultyList { get; set; }
        private FishItemList FishItemList { get; set; }

        public QuestLog()
        {
            QuestDifficultyList = new QuestDifficultyList();
            FishItemList = new FishItemList();
            List = new List<Quest>
            {
                //todo
                new Quest("First Quest","Kill 10 wolves around here","kill",
                    "Norwyn","Norwyn",0,1,QuestDifficultyList.Lookup("Easy"),"unstarted",
                    new List<Objective>
                    {
                        new KillObjective("wolf",10),
                    }),
                new Quest("Second Quest","Bring me 5 trouts","fetch","Norwyn","Norwyn",0,2,QuestDifficultyList.Lookup("Easy"),"unstarted",
                    new List<Objective>
                    {
                        new GatherObjective(new ItemStack(5,FishItemList.Lookup("Trout"))),
                    }),
                new Quest("Third Quest","Deliver these items to their owners","delivery","Norwyn","these people",0,0,QuestDifficultyList.Lookup("Easy"),"unstarted",
                    new List<Objective>
                    {
                        new DeliveryObjective(new ItemStack(1,FishItemList.Lookup("Trout")),"Dubois"),
                        new DeliveryObjective(new ItemStack(1,FishItemList.Lookup("Trout")),"NorwynBrother"),
                    }),
                // quest ideas: 
                // receive a sword and kill a boss with it, remove sword after completing
            };
        }
    }

    public class Quest
    {
        public string Name { get; set; }
        public string Description { get; set; } // what is this quest about
        public int MinLevel { get; set; } // min level to be able to take the quest
        public int RecommendedLevel { get; set; } // recommended level to complete the level
        public QuestDifficulty QuestDifficulty { get; set; } // easy(green)/medium(yellow)/hard(red)/insane(white black)
        // recommended level                                       -3          -2 - +2     +3 - +5          +6
        public string State { get; set; } // finished, started, not taken, locked
        public string FromWho { get; set; } // whoToFind gave you the quest
        public string ToWho { get; set; } // whoToFind to go to to complete the quest
        public List<Objective> Objectives { get; set; } // list of things to do
        public string Type { get; set; } // fetch/kill/delivery/puzzle/hybrid/typing/...

        public Quest(string name, string description, string type, string fromWho, string toWho, int minLevel,
            int recommendedLevel, QuestDifficulty questDifficulty, string state, List<Objective> objectives)
        {
            Name = name;
            Description = description;
            Type = type;
            FromWho = fromWho;
            ToWho = toWho;
            MinLevel = minLevel; 
            RecommendedLevel = recommendedLevel;
            QuestDifficulty = questDifficulty;
            State = state;
            Objectives = objectives;
        }
    }

    public class QuestLine
    {
        public string Name { get; set; }
        public int Progress { get; set; } // 1 of 4, this will store the number the quest line is on right now
        public List<Quest> List { get; set; }

        public QuestLine(string name, List<Quest> list)
        {
            Name = name;
            Progress = Progress;
            List = list;
        }
    }


    public abstract class Objective
    {
        public string EnemyToKill { get; protected set; }
        public int HowManyToKill { get; protected set; }
        public ItemStack ItemStack { get; protected set; }
        public string DeliverTo { get; protected set; }
        public string WhoToFind { get; protected set; }
    }
    public class KillObjective : Objective // boss or 10 golbins etc.
    {
        public KillObjective(string enemyToKill, int howManyToKill)
        {
            EnemyToKill = enemyToKill;
            HowManyToKill = howManyToKill;
        }
    }
    public class GatherObjective : Objective // bring item/itemStack to an npc
    {
        public GatherObjective(ItemStack itemStack)
        {
            ItemStack = itemStack;
        }
    }
    public class DeliveryObjective : Objective // bring this item i gave you to this npc, and then return to me
    {
        public DeliveryObjective(ItemStack itemStack,string deliverTo)
        {
            ItemStack = itemStack;
            DeliverTo = deliverTo;
        }
    }
    public class SearchObjective : Objective // find and npc in a cave for example
    {
        public SearchObjective(string whoToFind)
        {
            WhoToFind = whoToFind;
        }
    }
    public class QuestDifficulty // easy(green)/medium(yellow)/hard(red)/insane(white black)
    {
        public string Name { get; set; }
        public int LevelDiffBottom { get; set; }
        public int LevelDiffTop { get; set; }
        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColor BackgroundColor { get; set; }

        public QuestDifficulty(string name, int levelDiffBottom, int levelDiffTop, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            Name = name;
            LevelDiffBottom = levelDiffBottom;
            LevelDiffTop = levelDiffTop;
            ForegroundColor = foregroundColor;
            BackgroundColor = backgroundColor;
        }
    }


    public class QuestDifficultyList
    {
        public List<QuestDifficulty> List { get; set; }

        public QuestDifficultyList()
        {
            List = new List<QuestDifficulty>
            {
                new QuestDifficulty("Easy",-99,-3,ConsoleColor.Green,ConsoleColor.Yellow),
                new QuestDifficulty("Medium",-2,2,ConsoleColor.Green,ConsoleColor.Yellow),
                new QuestDifficulty("Hard",3,5,ConsoleColor.Green,ConsoleColor.Yellow),
                new QuestDifficulty("Insane",6,8,ConsoleColor.Green,ConsoleColor.Yellow),
                new QuestDifficulty("Leeroy",9,99,ConsoleColor.Green,ConsoleColor.Yellow),
            };
        }

        public QuestDifficulty Lookup(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            return List.FirstOrDefault(a => a?.Name == name);
        }
    }
}

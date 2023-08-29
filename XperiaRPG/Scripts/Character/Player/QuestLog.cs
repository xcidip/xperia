using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XperiaRPG.Scripts.Character.Player.CharacterCreation;

namespace XperiaRPG.Scripts.Character.Player
{
    public class QuestLog
    {
        public List<Quest> List { get; set; }

        public QuestLog()
        {
            List = new List<Quest>
            {
                new Quest {}
                // quest ideas: 
                // recieve a sword and kill a boss with it, remove sword after completing
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
        public string FromWho { get; set; } // who gave you the quest
        public string ToWho { get; set; } // who to go to to complete the quest
        public List<Objective> Objectives { get; set; } // list of things to do
        public string Type { get; set; } // fetch/kill/delivery/puzzle/hybrid/typing/...

        public Quest()
        {
            // todo
        }
    }

    public class QuestLine
    {
        public string Name { get; set; }
        public int Progress { get; set; } // 1 of 4, this will store the number the quest line is on right now
        public List<Quest> List { get; set; }

        public QuestLine()
        {
            // todo
        }
    }


    public abstract class Objective
    {
        protected Objective()
        {
            // todo find all variables that are shared between objectives
        }
    }

    public class KillObjective : Objective // boss or 10 golbins etc.
    {
        //todo
    }

    public class GatherObjective : Objective // bring item/itemStack to an npc
    {
        //todo
    }

    public class DeliveryObjective : Objective // bring this item i gave you to this npc
    {
        //todo
    }

    public class SearchObjective : Objective // find and npc in a cave for example
    {
        //todo
    }

    public class QuestDifficulty // easy(green)/medium(yellow)/hard(red)/insane(white black)
    {
        public string Name { get; set; }
        public int IfWhatLevelDifference { get; set; }
        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColor BackgroundColor { get;set; }

        public QuestDifficulty(string name, int ifWhatLevelDifference, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            Name = name;
            IfWhatLevelDifference = ifWhatLevelDifference;
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
                //todo
            };
        }
    }
}

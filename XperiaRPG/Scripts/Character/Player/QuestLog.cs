using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using XperiaRPG.Scripts.Character.Attributes;
using XperiaRPG.Scripts.Character.Player;
using XperiaRPG.Scripts.Character.Player.CharacterCreation;
using XperiaRPG.Scripts.Characters;
using XperiaRPG.Scripts.Items;
using XperiaRPG.Scripts.Skills;
using XperiaRPG.Scripts.Skills.Gathering;
using XperiaRPG.Scripts.UI;

namespace XperiaRPG.Scripts.Character.Player
{
    public class Quest
    {
        #region Variables
        public string Name { get; set; }
        public string Description { get; set; } // what is this quest about
        public int MinLevel { get; set; } // minimal level to start the quest
        public int RecommendedLevel { get; set; } // recommended level to complete the level
        public string State { get; set; } // undelivered, started, unstarted, hidden
        public string FromWho { get; set; } // who to find when wanting to deliver the quest
        public List<Objective> Objectives { get; set; } // list of things to do
        public string Type { get; set; } // fetch/kill/delivery/puzzle/hybrid/typing/...
        public Reward Reward { get; set; } // what you get from quest items/skills xp/stats
        public List<SkillRequirement> SkillRequirements { get; set; } // skills needed to start the quest
        #endregion
        
        public Quest(string name, string description, string type, string fromWho, int minLevel,
            int recommendedLevel, List<Objective> objectives, Reward reward,List<SkillRequirement> skillRequirements)
        {
            Name = name;
            Description = description;
            Type = type;
            FromWho = fromWho;
            MinLevel = minLevel;
            RecommendedLevel = recommendedLevel;
            State = "unstarted";
            Objectives = objectives;
            Reward = reward;
            SkillRequirements = skillRequirements;
        }
    }
    public class QuestLog
    {
        #region Variables
        private List<Quest> List { get; }
        private FishItemList FishItemList { get; set; }
        private ArmorItemList ArmorItemList { get; set; }
        #endregion

        #region Quest Log
        public QuestLog()
        {
            FishItemList = new FishItemList();
            ArmorItemList = new ArmorItemList();
            List = new List<Quest>
            {
                new Quest("First Quest", "Kill 10 wolves around here", "kill",
                    "Norwyn", 0, 1,
                    new List<Objective>
                    {
                        new KillObjective("wolf", 10),
                    }, 
                    new Reward
                    {
                        AttBonus = new AttBonus("Strength",2,"points")
                    },
                    new List<SkillRequirement>()
                    ),
                new Quest("Second Quest", "Bring me 5 trouts", "fetch",  "Norwyn", 0, 2,
                    new List<Objective>
                    {
                        new GatherObjective(new ItemStack(5, FishItemList.Lookup("Trout"))),
                    },
                    new Reward
                    {
                        ItemStack = new ItemStack(1,ArmorItemList.Lookup("Wizard's Hat")),
                    },
                    new List<SkillRequirement>()
                    ),
                new Quest("Third Quest", "Deliver these items to their owners", "delivery", "these people", 0,
                    0,
                    new List<Objective>
                    {
                        new DeliveryObjective(new ItemStack(1, FishItemList.Lookup("Trout")), "Dubois"),
                        new DeliveryObjective(new ItemStack(1, FishItemList.Lookup("Trout")), "NorwynBrother"),
                    },
                    new Reward
                    {
                        ItemStack = new ItemStack(5, FishItemList.Lookup("Trout")),
                    },
                    new List<SkillRequirement>
                    {
                        new SkillRequirement("Fishing",5),
                    }
                    ),
                // quest ideas: 
                // receive a sword and kill a boss with it, remove sword after completing
            };
        }
        #endregion

        #region Methods

        #region Quest State
        public void StartQuest(string name,Player player)
        {
            var quest = Lookup(name);
            if (quest.State == "started" || quest.State == "finished")
            {
                Console.WriteLine("Quest already started!");
                Choice.PressEnter();
                return;
            }

            if (QuestRequirementCheck(name, player))
            {
                Console.WriteLine("Not eligible for quest");
            }
            else
            {
                quest.State = "started";
                Console.WriteLine($"Quest started: \"{name}\" !");
            }
            Choice.PressEnter();
        }
        public void FinishQuest(string name)
        {
            Lookup(name).State = "undelivered";
        }
        public bool IsQuestFinished(string name)
        {
            return Lookup(name).State == "undelivered";
        }
        public void HideQuest(string name)
        {
            Lookup(name).State = "hidden";
        }
        #endregion

        #region Quest Completion
        public void CheckQuestCompletion(string name, Player player) // check for completed objectives
        {
            // todo
        }
        public void GiveQuestReward(string name, Player player)
        {
            var quest = Lookup(name);

            // xp/points to skill/stat
            if (quest.Reward.AttBonus != null) player.ChangeAttributeValue(quest.Reward.AttBonus, true);

            // item 
            if (quest.Reward.ItemStack != null) player.Inventory.AddItemStack(quest.Reward.ItemStack);

            // hide quest from quest log
            HideQuest(name);
        }

        #endregion
        public void QuestNpc(string questName, Player player)
        {
            if (player.QuestLog.IsQuestFinished(questName))
            {
                // todo remove quest items from inventory
                player.QuestLog.GiveQuestReward(questName, player);
                return;
            }
            player.QuestLog.StartQuest(questName,player);
        }
        public bool QuestRequirementCheck(string questName, Player player)
        {
            var everythingOkay = true;
            foreach (var requirement in Lookup(questName).SkillRequirements)
            {
                var yourSkill = player.Skills.Lookup(requirement.SkillName);
                if (yourSkill.Level < requirement.Value)
                {
                    Console.WriteLine($"{yourSkill.Value} {requirement.SkillName} is too low you need at least: {requirement.Value}");
                    everythingOkay = false;
                }
                if (!everythingOkay) Choice.PressEnter();
            }
            return everythingOkay;
        }
        public Quest Lookup(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            return List.Find(a => a?.Name == name);
        }
        public void Print()
        {
            Utility.PrintQuestLog();
        }
        #endregion
    }
    
    public class Reward
    {
        public ItemStack ItemStack { get; set; }
        public AttBonus AttBonus { get; set; }
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
}

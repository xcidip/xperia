using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XperiaRPG.Scripts.Character.Attributes;
using XperiaRPG.Scripts.Items;

namespace XperiaRPG.Scripts.Misc
{
    public class Reward
    {
        public ItemStack ItemStack { get; set; }
        public AttBonus AttBonus { get; set; }
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
        public DeliveryObjective(ItemStack itemStack, string deliverTo)
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

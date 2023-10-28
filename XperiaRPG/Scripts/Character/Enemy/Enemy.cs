using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using XperiaRPG.Scripts.Character.Attributes;
using XperiaRPG.Scripts.Character.Player.CharacterCreation;
using XperiaRPG.Scripts.Items;

namespace XperiaRPG.Scripts.Characters
{
    public class Enemy : Character.Character
    {
        public string Name { get; set; }
        public PlayerSetting Profession { get; set; }
        public PlayerSetting Race { get; set; }
        public string PrefferedFightingStyle { get; set; } // Dice/Memory/Slider/Typing
        public CombatStatList CombatStats { get; set; }
        public List<Drop> DropTable { get; set; }
        public Enemy(string name, PlayerSetting profession, PlayerSetting race, Stats stats, string fightingStyle, List<Drop> dropTable) 
        {
            Name = name;
            Profession = profession;
            Race = race;
            PrefferedFightingStyle = fightingStyle;
            Stats = stats;
            CombatStats = new CombatStatList(stats,Profession.MainStat);
            DropTable = dropTable;
        }

        public void DecreaseHP(int amount)
        {
            CombatStats.DecreaseHP(amount);
        }

    }

    public class Drop
    {
        public ItemStack ItemStack { get; set; }
        public int DropChance { get; set; }
        public Drop(int dropChance, ItemStack itemStack)
        {
            ItemStack = itemStack;
            DropChance = dropChance;
        }
    }

    public class EnemyList
    {
        List<Enemy> List { get; }
        ProfessionList ProfessionList;
        EnemyRaceList EnemyRaceList;
        FoodItemList FoodItemList;
        public EnemyList()
        {
            ProfessionList = new ProfessionList();
            EnemyRaceList = new EnemyRaceList();
            FoodItemList = new FoodItemList();
            List = new List<Enemy>
            {
                new Enemy("Rat",ProfessionList.Lookup("Warrior"),EnemyRaceList.Lookup("Rodent"),new Stats(10,2,1,1,1,2,1,1,1), "Dice", new List<Drop>
                {
                    new Drop(50, new ItemStack(1,FoodItemList.Lookup("Cooked Shrimp"))),
                }),
                new Enemy("Skeleton mage",ProfessionList.Lookup("Mage"),EnemyRaceList.Lookup("Undead"),new Stats(10,2,1,1,1,2,5,1,1), "Slider", new List<Drop>
                {
                    new Drop(50, new ItemStack(1,FoodItemList.Lookup("Cooked Shrimp"))),
                }),
                new Enemy("Small goblin",ProfessionList.Lookup("Hunter"),EnemyRaceList.Lookup("Goblin"),new Stats(10,10,1,1,1,2,1,4,1), "Typing", new List<Drop>
                {
                    new Drop(50, new ItemStack(1,FoodItemList.Lookup("Cooked Shrimp"))),
                }),
            };

        }
        public Enemy Lookup(string name)
        {
            return List.Find(a => a.Name == name);
        }
    }
}
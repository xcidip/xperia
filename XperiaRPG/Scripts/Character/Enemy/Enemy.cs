using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using XperiaRPG.Scripts.Character.Attributes;
using XperiaRPG.Scripts.Character.Player.CharacterCreation;

namespace XperiaRPG.Scripts.Characters
{
    public class Enemy : Character.Character
    {
        public string Name { get; set; }
        public PlayerSetting Profession { get; set; }
        public PlayerSetting Race { get; set; }
        public string PrefferedFightingStyle { get; set; } // Dice/Memory/Slider/Typing
        public CombatStatList CombatStats { get; set; }
        public Enemy(string name, PlayerSetting profession, PlayerSetting race, Stats stats, string fightingStyle) 
        {
            Name = name;
            Profession = profession;
            Race = race;
            PrefferedFightingStyle = fightingStyle;
            Stats = stats;
            CombatStats = new CombatStatList(stats,Profession.MainStat);
        }

        public void DecreaseHP(int amount)
        {
            CombatStats.DecreaseHP(amount);
        }

    }

    public class EnemyList
    {
        List<Enemy> List { get; }
        ProfessionList ProfessionList;
        EnemyRaceList EnemyRaceList;
        public EnemyList()
        {
            ProfessionList = new ProfessionList();
            EnemyRaceList = new EnemyRaceList();
            List = new List<Enemy>
            {
                new Enemy("Rat",ProfessionList.Lookup("Warrior"),EnemyRaceList.Lookup("Rodent"),new Stats(10,2,1,1,1,2,1,1,1), "Dice"),
                new Enemy("Skeleton mage",ProfessionList.Lookup("Mage"),EnemyRaceList.Lookup("Undead"),new Stats(10,2,1,1,1,2,5,1,1), "Slider"),
                new Enemy("Small goblin",ProfessionList.Lookup("Hunter"),EnemyRaceList.Lookup("Goblin"),new Stats(10,2,1,1,1,2,1,4,1), "Typing"),
            };

        }
        public Enemy Lookup(string name)
        {
            return List.Find(a => a.Name == name);
        }
    }
}
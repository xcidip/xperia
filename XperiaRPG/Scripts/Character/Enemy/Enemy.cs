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
        public Enemy(string name, PlayerSetting profession, PlayerSetting race, Stats stats) 
        {
            Name = name;
            Profession = profession;
            Race = race;
            
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
                new Enemy("Rat",ProfessionList.Lookup("Warrior"),EnemyRaceList.Lookup("Rodent"),new Stats(1,1,1,1,1,1,1,1,1)),
                new Enemy("Skeleton mage",ProfessionList.Lookup("Mage"),EnemyRaceList.Lookup("Undead"),new Stats(1,1,1,1,1,1,1,1,1)),
                new Enemy("Small goblin",ProfessionList.Lookup("Hunter"),EnemyRaceList.Lookup("Goblin"),new Stats(1,1,1,1,1,1,1,1,1)),
            };

        }
        public Enemy Lookup(string name)
        {
            return List.Find(a => a.Name == name);
        }
    }
}
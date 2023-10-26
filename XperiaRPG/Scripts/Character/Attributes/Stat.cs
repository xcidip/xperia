using System;
using System.Collections.Generic;
using System.Linq;
using XperiaRPG.Scripts.Character.Player;
using XperiaRPG.Scripts.Misc;
using XperiaRPG.Scripts.UI;

namespace XperiaRPG.Scripts.Character.Attributes
{
    public class Stat : Attribute
    {
        
        public Stat(string name, string shortName, int points,string description) : base(name, shortName, description)
        {
            
            Points = points;
        }
    }
    
    public class Stats
    {
        private List<Stat> List { get; }

        public Stats(int stamina, int defense, int natureRes, int frostRes, int fireRes, int strength,int intellect, int agility, int luck)
        {
            List = new List<Stat>
            {
                //offense
                new Stat("Strength","Str", strength,"is for increasing damage for melee professions"),
                new Stat("Intellect","Int", intellect,"is for increasing damage for magic professions"),
                new Stat("Agility","Agi", agility,"is for increasing damage for ranged professions"),

                //defense
                new Stat("Stamina","Stm", stamina,"is for increasing Health (1 Stm - 2 HP)"),
                new Stat("Defense","Def", defense,"is for increasing damage resistance"),
                new Stat("NatureRes","NaR", natureRes,"is for increasing resistance against nature damage"),
                new Stat("FrostRes","FrR", frostRes,"is for increasing resistance against frost attacks"),
                new Stat("FireRes","FiR", fireRes,"is for increasing resistance against fire attacks"),
                
                //both
                new Stat("Luck","Lck", luck,"is for increasing critical rate of your attacks"),
            };
        }

        public Stat Lookup(string name)
        {
            return List.Find(a => a?.Name == name);
        }
        
        public void AddPoints(string name, int amount)
        {
            Lookup(name).Points += amount;
        }
        public void Explain()
        {
            foreach (var stat in List)
            {
                Console.WriteLine($"{stat.ShortName} - {stat.Name} - {stat.Description}");
            }
        }

        public void Print()
        {
            var attributeList = List.Cast<Attribute>().ToList();
            var columns = GlobalVariables.Columns * 2;
            if (GlobalVariables.Columns >= 4) columns = 9;
            if (GlobalVariables.Columns == 3) columns = 5;

            Utility.PrintAttributes(attributeList,16,columns,"stats","| {0,-9}: {3,-4}");
        }
    }
}

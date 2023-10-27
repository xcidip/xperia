using System.Collections.Generic;
using System.Linq;
using XperiaRPG.Scripts.Misc;
using XperiaRPG.Scripts.UI;

namespace XperiaRPG.Scripts.Character.Attributes
{
    public class CombatStat : Attribute
    {
        public CombatStat(string name, string shortName, double value,int percentBonus, string description) : base(name, shortName, description)
        {
            PercentBonus = percentBonus;
            Value = value;
        }
    }

    public class CombatStatList
    {
        private List<CombatStat> List {get;}

        public CombatStatList(Stats yourStats, string mainStat /* StatList enemyStats*/)
        {
            List = new List<CombatStat>
            {
                new CombatStat("Health","Hp ",yourStats.Lookup("Stamina").Points * 2, 0,""),
                new CombatStat("Evasion","Evs", 0, 0, ""), //todo count depending on enemy stats
                new CombatStat("MaxDmg","Max",yourStats.Lookup(mainStat).Points, 0, ""), // todo count max damage from stats
                new CombatStat("MinDmg","Min",yourStats.Lookup(mainStat).Points * 0.2, 0, ""), // 1/5 of max dmg
            };
        }

        public CombatStat Lookup(string name)
        {
            return List.Find(x => x.Name == name);
        }

        public void DecreaseHP(int amount)
        {
            Lookup("Health").Value -= amount;
        }

        public void Update(Stats myStats, Stats enemyStats)
        {

        }

        public void Print()
        {
            var attributeList = List.Cast<Attribute>().ToList();

            Utility.PrintAttributes(attributeList, 16, 4, "CombatStats", "| {0,-9}: {5,-4}");
        }
    }
}

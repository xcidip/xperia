using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XperiaRPG.Scripts.Attributes
{
    public class BattleAttribute : Attribute
    {
        public BattleAttribute(string name, string shortName, double value,int percentBonus) : base(name, shortName)
        {
            PercentBonus = percentBonus;
            Value = value;
        }
    }

    public class BattleAttributeList
    {
        private List<BattleAttribute> List {get;}

        public BattleAttributeList(StatList playerStatList /* StatList enemyStatList*/)
        {
            List = new List<BattleAttribute>
            {
                new BattleAttribute("Health","Hp ",playerStatList.Lookup("Stamina").Points * 2,0),
                new BattleAttribute("CritChance","Crt",playerStatList.Lookup("Luck").Points * 10,0), // 1 luck = 10% crit chance
                new BattleAttribute("DmgReduction","Crt",playerStatList.Lookup("Defense").Points * 10,0), //todo count depending on enemy stats
                new BattleAttribute("MinDmg","Crt",playerStatList.Lookup("Defense").Points * 10,0), // todo count min damage from stats
                new BattleAttribute("MaxDmg","Crt",playerStatList.Lookup("Defense").Points * 10,0), // todo count max damage from stats
            };
        }
    }
}

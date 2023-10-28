using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
                new CombatStat("CombatLvl","CLv", 1, 0, "Combat level - averages all combat stats"),
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

        #region Combat Stat manipulation
        public void DecreaseHP(int amount)
        {
            Lookup("Health").Value -= amount;
        }

        public void Update(Stats myStats, Stats enemyStats)
        {
            Lookup("CombatLvl").Value = myStats.CombatLevel();
            Lookup("Evasion").Value = CalculateEvasionChance(enemyStats.CombatLevel(),myStats.CombatLevel(), myStats.Lookup("Defense").Points);
        }
        public void ResetAfterCombat()
        {
            Lookup("Evasion").Value = 0;
        }
        public void ResetHealth(Stats stats)
        {
            Lookup("Health").Value = stats.Lookup("Stamina").Points * 2;
        }
        public void ResetAll(Stats stats)
        {
            ResetHealth(stats);
            stats.CombatLevel();
            ResetAfterCombat();
        }
        #endregion

        static double CalculateEvasionChance(double enemyCombatLevel, double yourCombatLevel, int yourDefense)
        {
            // customize these parameters based on the specific mechanics of your game
            double baseEvasionChance = 5; // a base value for evasion chance
            double combatLevelDifferenceFactor = 0.5; // modify this factor to adjust the impact of combat level difference
            double defenseFactor = 0.3; // modify this factor to adjust the impact of defense

            // calculate the difference in combat levels
            double combatLevelDifference = yourCombatLevel - enemyCombatLevel;

            // adjust evasion chance based on combat level difference and defense
            double adjustedEvasionChance = baseEvasionChance + combatLevelDifference * combatLevelDifferenceFactor + yourDefense * defenseFactor;

            // ensure the evasion chance is within a valid range (0 to 100)
            adjustedEvasionChance = Math.Max(0, Math.Min(100, adjustedEvasionChance));

            return adjustedEvasionChance;
        }



        public void Print()
        {
            var attributeList = List.Cast<Attribute>().ToList();

            Utility.PrintAttributes(attributeList, 16, 5, "Combat-Stats", "| {0,-9}: {5,-4}");
        }
    }
}

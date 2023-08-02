﻿using System;
using System.Collections.Generic;
using XperiaRPG.Scripts.Attributes;
using XperiaRPG.Scripts.Items;

namespace XperiaRPG.Scripts.Character.Player.Inventory
{
    public enum GearSlot
    {
        Head,
        Chest,
        Legs,
        MainHand,
        OffHand,
        Pickaxe,
        FishingRod,
        Mount,
        // Add more slots as needed
    }

    public class Gear
    {
        private readonly Dictionary<GearSlot, Item> _gear;

        public Gear()
        {
            _gear = new Dictionary<GearSlot, Item>();
        }

        public void Equip(Item item, Characters.Inventory.Inventory itemInventory, StatList stats, SkillList skillList)
        {
            const bool addRemove = true;
            if (item == null) return;
            UnequipArmor(item, itemInventory, stats, skillList);
            _gear[item.GearSlot] = item;
            AddBonus(addRemove, item, stats, skillList);
            Console.WriteLine(item.Name + " Equipped!");
            if (item.Quantity == 1)
            {
                itemInventory.RemoveItem(item); // Remove the armor from ItemInventory
            }
            else
            {
                item.Reduce();
            }
        }

        private void UnequipArmor(Item item, Characters.Inventory.Inventory inventory, StatList statList, SkillList skillList)
        {
            const bool addRemove = false;
            if (!_gear.TryGetValue(item.GearSlot, out var armorItem)) return; // if not present return;
            if (armorItem != null) inventory.AddItem(armorItem); // if present put back to inventory
            _gear.Remove(item.GearSlot);
            AddBonus(addRemove, armorItem, statList, skillList);
            Console.WriteLine(item.Name + " Unequipped!");
        }

        private static void AddBonus(bool addRemove, Item item, StatList statList, SkillList skillList)
        {
            var i = 1;
            if (addRemove == false) i = -1;

            if (item.AttributeBonusList == null) return;

            var bonusList = item.AttributeBonusList;
            foreach (var bonus in bonusList)
            {
                var name = bonus.Name;
                var amount = bonus.Amount * i;
                var unit = bonus.Unit;

                if (skillList.Lookup(name) != null)
                {
                    if (unit == "%")
                    {
                        skillList.AddPercentBonus(name, amount);
                        return;
                    }
                    skillList.AddXp(name, amount);
                    return;
                }

                if (statList.Lookup(name) == null) return;
                statList.AddPoints(name, amount);
            }
        }

        // skillList and statList for shortName of skill/stat
        public void Print(SkillList skillList, StatList statList)
        {
            Console.WriteLine("+---SLOTS----+-----------------------------+-----------------------------------------+");

            // armor
            foreach (GearSlot slot in Enum.GetValues(typeof(GearSlot)))
            {

                Console.Write($"| {slot,-10} | ");
                if (_gear.TryGetValue(slot, out var item))
                {
                    Console.Write($"{item?.Name,-28}| ");
                    string bonuses = null;
                    if (item != null)
                        foreach (var bonus in item.AttributeBonusList)
                        {
                            var shortName = bonus.Name;
                            if (skillList.Lookup(bonus.Name) != null) shortName = skillList.Lookup(bonus.Name).ShortName;
                            if (statList.Lookup(bonus.Name) != null) shortName = statList.Lookup(bonus.Name).ShortName;

                            if (bonus.Unit == "points")
                            {
                                bonuses += $"{shortName + ":" + bonus.Amount} ";
                            }
                            else
                            {
                                var plusMinus = "+";
                                if (bonus.Amount < 0)
                                {
                                    plusMinus = "0";
                                }
                                bonuses += $"{shortName + ":"+ plusMinus + bonus.Amount + bonus.Unit} ";
                            }
                        }

                    Console.Write($"{bonuses,-40}|");
                    Console.Write("\n");
                }
                else
                {
                    Console.Write($"{"",-28}| {"",40}|\n");
                }
            }

            Console.WriteLine("+------------+-----------------------------+-----------------------------------------+");
        }
    }

}
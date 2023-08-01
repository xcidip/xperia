using System;
using System.Collections.Generic;
using System.Net;
using XperiaRPG.Scripts.Attributes;
using XperiaRPG.Scripts.Items;

namespace XperiaRPG.Scripts.Characters.Inventory
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

        public void Equip(Item item, Inventory itemInventory, StatList stats, SkillList skillList)
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

        private void UnequipArmor(Item item, Inventory inventory, StatList statList, SkillList skillList)
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
                if (unit == "%")
                {
                    statList.AddPercentBonus(name, amount);
                    return;
                }
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
                    if (item != null)
                        foreach (var bonus in item.AttributeBonusList)
                        {
                            var shortName = bonus.Name;
                            if (skillList.Lookup(bonus.Name) != null) shortName = skillList.Lookup(bonus.Name).ShortName;
                            if (statList.Lookup(bonus.Name) != null) shortName = statList.Lookup(bonus.Name).ShortName;
                            Console.Write(bonus.Unit == "points"
                                ? $"{shortName + ": " + bonus.Amount} "
                                : $"{shortName + ": " + bonus.Amount + bonus.Unit} ");
                        }

                    Console.Write("\n");
                }
                else
                {
                    Console.Write($"{"",-28}|\n");
                }
            }

            Console.WriteLine("+------------+-----------------------------+-----------------------------------------+");
        }
    }

}
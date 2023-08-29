﻿using System;
using System.Collections.Generic;
using XperiaRPG.Scripts.Attributes;
using XperiaRPG.Scripts.Items;
using XperiaRPG.Scripts.UI;

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
        private readonly Dictionary<GearSlot, Item> _gear = new Dictionary<GearSlot, Item>();


        public void Equip(Item item, Player player)
        {
            var statList = player.Stats;
            var skillList = player.Skills;
            var characterInfo = player.CharacterInfo;
            var inventory = player.Inventory;

            if (player.Level < item.RequiredLevel)
            {
                Console.WriteLine("Player level too low. {0} level required!", item.RequiredLevel);
                Choice.PressEnter();
                return;
            }

            if (item.Profession != "all")
            {
                if (characterInfo[1].Name != item.Profession)
                {
                    Console.WriteLine("Wrong item - Only {0} can equip this", item.Profession);
                    Choice.PressEnter();
                    return;
                }
            }

            const bool addRemove = true;
            UnequipArmor(item.GearSlot, player);
            _gear[item.GearSlot] = item;
            AddBonus(addRemove, item, statList, skillList);
            Console.WriteLine(item.Name + " Equipped!");
            inventory.RemoveItem(item); // Remove the armor from ItemInventory
            Choice.PressEnter();
        }

        private void UnequipArmor(GearSlot gearSlot, Player player)
        {
            var inventory = player.Inventory;
            var statList = player.Stats;
            var skillList = player.Skills;
            const bool addRemove = false;
            if (!_gear.TryGetValue(gearSlot, out var armorItem)) return; // if not present return;
            if (armorItem != null) inventory.AddItemStack(new ItemStack(1,armorItem)); // if present put back to inventory
            _gear.Remove(gearSlot);
            AddBonus(addRemove, armorItem, statList, skillList);
            Console.WriteLine($"Unequipped item from {gearSlot} slot");
        }

        private static void AddBonus(bool addRemove, Item item, Stats stats, Attributes.Skills skills)
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

                if (skills.Lookup(name) != null)
                {
                    if (unit == "%")
                    {
                        skills.AddPercentBonus(name, amount);
                        return;
                    }
                    skills.AddXp(name, amount);
                    return;
                }

                if (stats.Lookup(name) == null) return;
                stats.AddPoints(name, amount);
            }
        }

        // skillList and statList for shortName of skill/stat
        public void Print(Attributes.Skills skills, Stats stats)
        {
            Console.WriteLine("+---SLOTS----+--------ITEM-NAME------------+---------------BONUSES-------------------+");

            // armor
            foreach (GearSlot slot in Enum.GetValues(typeof(GearSlot)))
            {

                Console.Write($"| {slot,-10} | ");
                if (_gear.TryGetValue(slot, out var item))
                {
                    // item name
                    InventoryUtils.PrintColored("{0,-28}",item);
                    Console.Write("| ");

                    string bonuses = null;
                    if (item != null)
                        foreach (var bonus in item.AttributeBonusList)
                        {
                            var shortName = bonus.Name;
                            if (skills.Lookup(bonus.Name) != null) shortName = skills.Lookup(bonus.Name).ShortName;
                            if (stats.Lookup(bonus.Name) != null) shortName = stats.Lookup(bonus.Name).ShortName;

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
                                bonuses += $"{shortName + ":" + plusMinus + bonus.Amount + bonus.Unit} ";
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


        public void GearMenu(Player player)
        {
            while (true)
            {
                var statList = player.Stats;
                var skillList = player.Skills;

                // (1) print all armor with numbers
                Print(skillList, statList);

                // (2) choose which item to interact with
                Console.WriteLine($"Which slot?" +
                    "\n(0) EXIT" +
                    "\n(1) Head" +
                    "\n(2) Chest" +
                    "\n(3) Legs" +
                    "\n(4) MainHand" +
                    "\n(5) OffHand" +
                    "\n(6) Pickaxe" +
                    "\n(7) FishingRod" +
                    "\n(8) Mount"
                );
                var choice2 = Choice.NumberRangeValidation(0, 8);
                if (choice2 == 0) return; // Exit

                Console.WriteLine("What to do?\n(0) EXIT\n(1) Unequip\n(2) Examine");
                var choice1 = Choice.NumberRangeValidation(0, 2);
                if (choice1 == 0) return; // Exit

                var gearSlotMappings = new Dictionary<int, GearSlot>
                {
                    { 1, GearSlot.Head },
                    { 2, GearSlot.Chest },
                    { 3, GearSlot.Legs },
                    { 4, GearSlot.MainHand },
                    { 5, GearSlot.OffHand },
                    { 6, GearSlot.Pickaxe },
                    { 7, GearSlot.FishingRod },
                    { 8, GearSlot.Mount }
                };

                if (gearSlotMappings.TryGetValue(choice2, out var gearSlot))
                {
                    if (choice1 == 2)
                    {
                        _gear.TryGetValue(gearSlot, out var item);
                        InventoryUtils.ItemExamine(item);
                    }
                    else
                    {
                        UnequipArmor(gearSlot, player);
                    }
                }

                Console.Clear();
            }

        }

    }

}
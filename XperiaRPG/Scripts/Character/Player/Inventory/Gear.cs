using System;
using System.Collections.Generic;
using XperiaRPG.Scripts.Character.Attributes;
using XperiaRPG.Scripts.Items;
using XperiaRPG.Scripts.Misc;
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
            if (Checks.EquipCheck(player, item)) return;
            
            // unequip
            UnequipArmor(item.GearSlot, player);
            
            // equip
            _gear[item.GearSlot] = item;
            
            // add bonus
            AddBonus(player,item, true);
            Console.WriteLine(item.Name + " Equipped!");
            
            // Remove from Inventory
            player.Inventory.RemoveItem(item); 
            Choice.PressEnter();
        }
        private void UnequipArmor(GearSlot gearSlot, Player player)
        {
            if (!_gear.TryGetValue(gearSlot, out var armorItem)) return; // if not present return;
            if (armorItem != null) player.Inventory.AddItemStack(new ItemStack(1,armorItem)); // if present put back to inventory
            _gear.Remove(gearSlot); // remove from gear
            AddBonus(player,armorItem,false); // remove bonus
            Console.WriteLine($"Unequipped item from {gearSlot} slot");
        }

        private static void AddBonus(Player player, Item item, bool addOrRemove)
        {
            foreach (var bonus in item.AttributeBonusList)
            {
                player.ChangeAttributeValue(bonus,addOrRemove);
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
                // (1) print all armor with numbers
                Print(player.Skills, player.Stats);

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
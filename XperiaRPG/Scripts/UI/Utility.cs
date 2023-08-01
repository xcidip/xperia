using System;
using System.Collections.Generic;
using System.Linq;
using XperiaRPG.Scripts.Attributes;
using XperiaRPG.Scripts.Character.Player;
using XperiaRPG.Scripts.CharacterCreation;
using XperiaRPG.Scripts.Characters.Inventory;
using XperiaRPG.Scripts.Items;
using Attribute = XperiaRPG.Scripts.Attributes.Attribute;

namespace XperiaRPG.Scripts.UI
{
    public static class Utility
    {
        private static void PrintBorder(int columns, int lengthOfColumn)
        {
            for (var i = 0; i < columns; i++)
            {
                Console.Write("+");
                for (var j = 0; j < lengthOfColumn; j++) Console.Write("-");
            }

            Console.Write("+\n");
        }

        public static void PrintAttributes(IEnumerable<Attribute> list, int columns, int lengthOfColumn, string format)
        {
            var attributes = list.ToList();
            var numOfItems = attributes.Count();

            PrintBorder(columns, lengthOfColumn);
            var i = 0;

            foreach (var attribute in attributes)
            {
                Console.Write(format, attribute.Name, attribute.Level, attribute.Xp, attribute.Points);

                i++;
                if (i % columns != 0 && i != numOfItems) continue;

                var remainingItemsInRow = i % columns;
                var blankSpaces = remainingItemsInRow == 0 ? 0 : columns - remainingItemsInRow;

                // Print the blank spaces for the remaining items in the row
                for (var j = 0; j < blankSpaces; j++)
                {
                    Console.Write($"|{new string(' ', lengthOfColumn)}");
                }

                Console.WriteLine("|");
            }

            PrintBorder(columns, lengthOfColumn);
        }

        public static PlayerSetting PrintCharacterCreationSetting(ChoiceList choiceList, string format)
        {
            var list = choiceList.List;
            var length = list.Count;

            var i = 1;
            foreach (var choice in list)
            {
                string bonus = null;
                if (choice.AttributeBonus != null)
                {
                    bonus = choice.AttributeBonus.Bonus();
                }

                Console.Write($"{"(" + i + ")",-4}");
                Console.WriteLine(format,
                    choice.Name, //0 Name
                    bonus, //1 Attribute Bonus
                    choice.ArmorType + " armor", //2 Type of armor
                    choice.Value * 100 + "%", //3 DifficultyValue
                    choice.Description, //4 Description
                    choice.Lore, //5 Lore
                    choice.HowToPlay //6 how to play
                );
                i++;
            }

            var action = Choice.NumberRangeValidation(1, length);
            for (var j = 0; j < length; j++)
            {
                if (action == j + 1)
                {
                    return list[j];
                }
            }

            return null;
        }


        public static void PrintInventory(IEnumerable<Item> list, int columns, int lengthOfColumn, string format)
        {
            var itemList = list.ToList();
            var numOfItems = itemList.Count();

            if (numOfItems == 0)
            {
                Console.WriteLine(
                    "+-------------------------------+\n" +
                    "|      Empty like my soul       |\n" +
                    "+-----------INVENTORY-----------+"
                );
                return;
            }

            PrintBorder(columns, lengthOfColumn);
            var i = 0;

            foreach (var item in itemList)
            {
                Console.Write($"{"| (" + (i+1) + ")",-4}");
                Console.Write(format,
                    item.Name + " " + item.Quantity + "x"); //0

                i++;
                if (i % columns != 0 && i != numOfItems) continue;

                var remainingItemsInRow = i % columns;
                var blankSpaces = remainingItemsInRow == 0 ? 0 : columns - remainingItemsInRow;

                // Print the blank spaces for the remaining items in the row
                for (var j = 0; j < blankSpaces; j++)
                {
                    Console.Write($"|{new string(' ', lengthOfColumn)}");
                }

                Console.WriteLine("|");
            }

            PrintBorder(columns, lengthOfColumn);
        }
    }

    public static class InventoryUtils
    {
        public static void InventoryAction(int columns, Player player)
        {
            var inventory = player.Inventory;
            var gear = player.Gear;
            var statList = player.StatList;
            var skillList = player.SkillList;
            
            while (true)
            {
                // length of stats
                var statColumns = 2;
                if (columns >= 2) statColumns = 5;
                // length of skills
                var skillColumns = 1;
                if (columns >= 2) skillColumns = 2;
                if (columns >= 3) skillColumns = 4;


                gear.Print(skillList,statList);
                statList.Print(statColumns);
                skillList.Print(skillColumns);
                inventory.Print(columns);

                var itemCount = inventory.List.Count;
                Console.WriteLine($"Which item do you want to Interact with? (0) - ({itemCount}) (0)Exit");
                var index = Choice.NumberRangeValidation(0, itemCount) - 1;
                if (index == -1) return;
                var item = inventory.List[index];
                Console.WriteLine($"\nItem Selected: {item.Name}");

                switch (item)
                {
                    case Armor armor:
                    {
                        Console.WriteLine("What do you want to do with this armor piece?");
                        Console.WriteLine("(1) Equip\n" +
                                          "(2) Examine\n" +
                                          "(3) Remove from inventory\n" +
                                          "(4) Leave this menu");
                        var whatToDo = Choice.NumberRangeValidation(1, 4);
                        switch (whatToDo)
                        {
                            case 1:
                                gear.Equip(armor, inventory, statList, skillList);
                                break;
                            case 2:
                                Console.WriteLine(
                                    $"\nName: {armor.Name}\nDescription: {armor.Description}\nQuantity: {armor.Quantity}x");
                                // todo display armor bonuses
                                Choice.PressEnter();
                                break;
                            case 3:
                                inventory.List.RemoveAt(index);
                                Console.WriteLine(item.Name + "removed from inventory");
                                break;
                            case 4:
                                break;
                        }

                        break;
                    }
                    case Potion potion:
                    {
                        Console.WriteLine("What do you want to do with this Potion?");
                        Console.WriteLine("(1) Use\n" +
                                          "(2) Examine\n" +
                                          "(3) Remove from inventory\n" +
                                          "(4) Leave this menu");
                        var whatToDo = Choice.NumberRangeValidation(1, 3);
                        switch (whatToDo)
                        {
                            case 1:
                                potion.Use();
                                break;
                            case 2:
                                Console.WriteLine(
                                    $"\nName: {potion.Name}\nDescription: {potion.Description}\nQuantity: {potion.Quantity}x");
                                // todo display what that potion does
                                Choice.PressEnter();
                                break;
                            case 3:
                                inventory.List.RemoveAt(index);
                                Console.WriteLine(item.Name + "removed from inventory");
                                break;
                            case 4:
                                break;
                        }

                        break;
                    }
                }
            }
        }
    }
}
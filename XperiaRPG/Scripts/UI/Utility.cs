using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using XperiaRPG.Scripts.Attributes;
using XperiaRPG.Scripts.Character.Player;
using XperiaRPG.Scripts.Character.Player.CharacterCreation;
using XperiaRPG.Scripts.CharacterCreation;
using XperiaRPG.Scripts.Characters.Inventory;
using XperiaRPG.Scripts.Items;
using XperiaRPG.Scripts.Skills;
using Attribute = XperiaRPG.Scripts.Attributes.Attribute;

namespace XperiaRPG.Scripts.UI
{
    public static class Utility
    {
        public static void PrintBorder(int columns, int lengthOfColumn)
        {
            for (var i = 0; i < columns; i++)
            {
                Console.Write("+");
                for (var j = 0; j < lengthOfColumn; j++) Console.Write("-");
            }

            Console.Write("+\n");
        }

        public static int CalculateLevelFromXp(int xp)
        {
            var number = Math.Floor(Math.Sqrt(xp) / 2) - 3;
            if (number < 0) return 1;
            return (int)number;
        }

        public static void PrintAttributes(IEnumerable<Attribute> list, int columns, int lengthOfColumn,string headerName ,string format)
        {
            var attributes = list.ToList();
            var numOfItems = attributes.Count();

            Utility.PrintBorder(columns, lengthOfColumn);
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.WriteLine($"+-{headerName}");
            var i = 0;

            foreach (var attribute in attributes)
            {
                Console.Write(format, 
                    attribute.Name, //0
                    CalculateLevelFromXp(attribute.Xp),//1
                    attribute.Xp,//2
                    attribute.Points, //3
                    "+" + attribute.PercentBonus + "%"//4
                    );

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

    }

    public static class InventoryUtils
    {
        public static void PrintInventoryHeader(int columns,int lengthOfColumn,int numOfItems, int inventorySize)
        {
            Utility.PrintBorder(columns, lengthOfColumn);
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.WriteLine($"+-----INVENTORY {numOfItems + "/" + inventorySize}");
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
            PrintInventoryHeader(columns,lengthOfColumn,numOfItems,30);

            var i = 0;

            foreach (var item in itemList)
            {
                Console.Write($"{"| (" + (i + 1) + ")",-4}");
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

            Utility.PrintBorder(columns, lengthOfColumn);
        }
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


                gear.Print(skillList,statList);
                statList.Print(statColumns);
                skillList.Print(columns);
                inventory.Print(columns);

                var itemCount = inventory.List.Count;
                Console.WriteLine($"Which item do you want to Interact with? (0) - ({itemCount}) (0)Exit");
                var index = Choice.NumberRangeValidation(0, itemCount) - 1;
                if (index == -1) return;
                var item = inventory.List[index];
                Console.WriteLine($"\nItem Selected: {item.Name}");

                switch (item)
                {
                    case Armor itemObj:
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
                                gear.Equip(itemObj, player);
                                break;
                            case 2:
                                itemObj.Examine();
                                Choice.PressEnter();
                                break;
                            case 3:
                                inventory.List.RemoveAt(index);
                                Console.WriteLine(itemObj.Name + "removed from inventory");
                                break;
                            case 4:
                                break;
                        }

                        break;
                    }
                    case Potion itemObj:
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
                                itemObj.Use();
                                break;
                            case 2:
                                itemObj.Examine();
                                Choice.PressEnter();
                                break;
                            case 3:
                                inventory.List.RemoveAt(index);
                                Console.WriteLine(itemObj.Name + "removed from inventory");
                                break;
                            case 4:
                                break;
                        }

                        break;
                    }
                    case Weapon itemObj:
                    {
                        Console.WriteLine("What do you want to do with this weapon?");
                        Console.WriteLine("(1) Equip\n" +
                                          "(2) Examine\n" +
                                          "(3) Remove from inventory\n" +
                                          "(4) Leave this menu");
                        var whatToDo = Choice.NumberRangeValidation(1, 4);
                        switch (whatToDo)
                        {
                            case 1:
                                gear.Equip(itemObj,player);
                                break;
                            case 2:
                                itemObj.Examine();
                                Choice.PressEnter();
                                break;
                            case 3:
                                inventory.List.RemoveAt(index);
                                Console.WriteLine(itemObj.Name + "removed from inventory");
                                break;
                            case 4:
                                break;
                        }

                        break;
                    }
                    case Equipable itemObj:
                    {
                        Console.WriteLine("What do you want to do with this item?");
                        Console.WriteLine("(1) Equip\n" +
                                          "(2) Examine\n" +
                                          "(3) Remove from inventory\n" +
                                          "(4) Leave this menu");
                        var whatToDo = Choice.NumberRangeValidation(1, 4);
                        switch (whatToDo)
                        {
                            case 1:
                                gear.Equip(itemObj, player);
                                break;
                            case 2:
                                itemObj.Examine();
                                Choice.PressEnter();
                                break;
                            case 3:
                                inventory.List.RemoveAt(index);
                                Console.WriteLine(itemObj.Name + "removed from inventory");
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

    public static class SkillUtils
    {
        public static void PrintMenuHeader(int columns, int lengthOfColumn, string header)
        {
            Utility.PrintBorder(columns, lengthOfColumn);
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.WriteLine($"+-----{header.ToUpper()}");
        }
        public static void PrintCraftingMenu(string header,int columns, int lengthOfColumn, CookingRecipeList cookingRecipeList)
        {
            /*
            +------------------------------------------------+------------------------------------------------+
            | Cooked Shrimp - 1x Shrimp 1x Knife             | Cooked Trout - 1x Trout 1x Shrimp              |
            | Cooked Trout - 1x Trout 1x Shrimp              | Cooked Shrimp - 1x Shrimp 1x Knife             |
            +------------------------------------------------+------------------------------------------------+
             */
            var list = cookingRecipeList.List;
            var numOfItems = list.Count();

            if (numOfItems == 0)
            {
                Console.WriteLine(
                    "+-------------------------------+\n" +
                    "|     No recipes available      |\n" +
                    $"+------------------------------+{header.ToUpper()}"
                );
                return;
            }

            //top
            PrintMenuHeader(columns, lengthOfColumn, header);

            var i = 0;

            foreach (var item in list)
            {
                Console.Write($"{"| (" + (i + 1) + ")",-4}");
                Console.Write(format,
                    item.Name + " " + item. + "x"); //0

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

                //bottom
                Utility.PrintBorder(columns, lengthOfColumn);
        }
    }
}
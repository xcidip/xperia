using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using XperiaRPG.Scripts.Attributes;
using XperiaRPG.Scripts.Character.Player;
using XperiaRPG.Scripts.Character.Player.CharacterCreation;
using XperiaRPG.Scripts.Character.Player.Inventory;
using XperiaRPG.Scripts.CharacterCreation;
using XperiaRPG.Scripts.Items;
using XperiaRPG.Scripts.Skills;
using Attribute = XperiaRPG.Scripts.Attributes.Attribute;
using Console = System.Console;

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

        public static void PrintAttributes(IEnumerable<Attribute> list, int columns, int lengthOfColumn,
            string headerName, string format)
        {
            var attributes = list.ToList();
            var numOfItems = attributes.Count();

            Utility.PrintBorder(columns, lengthOfColumn);
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.WriteLine($"+-{headerName.ToUpper()}");
            var i = 0;

            foreach (var attribute in attributes)
            {
                Console.Write(format,
                    attribute.Name, //0
                    CalculateLevelFromXp(attribute.Xp), //1
                    attribute.Xp, //2
                    attribute.Points, //3
                    "+" + attribute.PercentBonus + "%" //4
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

        public static void Action(int columns, Player player)
        {
            var inventory = player.Inventory;
            var invLength = inventory.List.Count;
            var gear = player.Gear;
            var statList = player.Stats;
            var skillList = player.Skills;

            while (true)
            {
                // length of stats
                var statColumns = 2;
                if (columns >= 2) statColumns = 5;


                gear.Print(skillList, statList);
                statList.Print(statColumns);
                skillList.Print(columns);
                inventory.Print(columns);


                var choice = Choice.InventoryActionInput(invLength);
                switch (choice)
                {
                    // tell more about what stats & skills does
                    case "a":
                        Console.Clear();
                        statList.Print(statColumns);
                        statList.Explain();

                        Choice.PressEnter();

                        skillList.Print(columns);
                        skillList.Explain();

                        Choice.PressEnter();
                        break;
                    // 1) what skill 2) show recipes 3) craft
                    case "c":
                        var craftingSkillList = skillList.QueryByTypeList("Crafting");
                        var i = 1;
                        Console.Clear();
                        foreach (var skill in craftingSkillList)
                        {
                            Console.WriteLine($"({i}) {skill.Name}");
                            i++;
                        }
                        var whatSkill = craftingSkillList[Choice.NumberRangeValidation(1,craftingSkillList.Count)];



                        Console.ReadLine();
                        break;
                    // show gear menu (unequip, examine gear)
                    case "g":

                        break;
                    // Interact with items
                    default:
                        if (int.TryParse(choice, out var number))
                        {
                            var item = inventory.List[number];
                            Console.WriteLine($"\nItem Selected: {item.Name}");

                            ItemInteraction.ItemInteract(item, player, number);
                            break;
                        }

                        Console.WriteLine("You found the easter egg. Type just one number not whole option next time");
                        Choice.PressEnter();
                        continue;
                        
                }


            }
        }
    }
    public class Action
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public Action(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
    public class ActionList
    {
        public List<Action> List { get; set; }

        public ActionList(int invLength)
        {
            List = new List<Action>
            {
                new Action($"0-{invLength}", "Item"),
                new Action("a", "Attributes"),
                new Action("c", "Crafting"),
                new Action("g", "Gear"),
            };
        }
        public Action Lookup(string key)
        {
            return List.FirstOrDefault(a => a?.Key == key);
        }
    }

}
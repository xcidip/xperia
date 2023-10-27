using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using XperiaRPG.Scripts.Character.Attributes;
using XperiaRPG.Scripts.Character.NPC;
using XperiaRPG.Scripts.Character.Player;
using XperiaRPG.Scripts.Character.Player.CharacterCreation;
using XperiaRPG.Scripts.Character.Player.Inventory;
using XperiaRPG.Scripts.Items;
using XperiaRPG.Scripts.Misc;
using Attribute = XperiaRPG.Scripts.Character.Attributes.Attribute;
using Console = System.Console;

namespace XperiaRPG.Scripts.UI
{
    public static class MathUtility
    {
        public static int ConvertXpToLevel(double xp)
        {
            if (xp <= 0)
            {
                return 1; // Level is 0 when XP is 0 or negative.
            }

            var xpNeededForNextLevel = 83.0; // Starting XP needed for level 1.
            var level = 1;

            while (xp >= xpNeededForNextLevel)
            {
                xp -= xpNeededForNextLevel;
                xpNeededForNextLevel *= 1.104; // Increase by 10.4%
                level++;
            }

            return level;
        }
    }

    public static class BorderUtility
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

        public static void PrintHeaderBorder(string headerName, int columns, int lengthOfColumn)
        {
            PrintBorder(columns, lengthOfColumn);
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.WriteLine($"+-{headerName.ToUpper()}");
        }
    }
    public static class Utility
    {        
        public static void PrintAttributes(IEnumerable<Attribute> list, int lengthOfColumn, int columns,
            string headerName, string format)
        {
            var attributes = list.ToList();
            var numOfItems = attributes.Count();

            BorderUtility.PrintHeaderBorder(headerName,columns,lengthOfColumn);

            var i = 0;

            foreach (var attribute in attributes)
            {
                Console.Write(format,
                    attribute.Name, //0
                    attribute.Level, //1
                    attribute.Xp, //2
                    attribute.Points, //3
                    "+" + attribute.PercentBonus + "%", //4
                    attribute.Value //5
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

            BorderUtility.PrintBorder(columns, lengthOfColumn);
        }

        public static void PrintQuestLog(List<Quest> List)
        {
            BorderUtility.PrintHeaderBorder("quest log",1,60);
            foreach (var quest in List)
            {
                // display only unifinished quests
                if (quest.State == "started" || quest.State == "undelivered")
                {
                    Console.WriteLine($"Name: {quest.Name}\nDescription: {quest.Description} \nFrom: {quest.FromWho} \nMinLevel: {quest.MinLevel} RecommendedLvl {quest.RecommendedLevel} \nState: {quest.State}");

                    Console.WriteLine("Objectives:");
                    foreach (var objective in quest.Objectives)
                    {
                        switch (objective)
                        {
                            case KillObjective killObjective:
                                Console.Write("\tKill these: ");
                                Console.WriteLine($"{killObjective.HowManyToKill}x {killObjective.EnemyToKill}");
                                break;
                            case GatherObjective gatherObjective:
                                Console.Write("\tBring me this: ");
                                Console.WriteLine($"{gatherObjective.ItemStack.Quantity}x {gatherObjective.ItemStack.Name}");
                                break;
                            case DeliveryObjective deliveryObjective:
                                Console.Write("\tDeliver these: ");
                                Console.WriteLine($"{deliveryObjective.ItemStack.Quantity}x {deliveryObjective.ItemStack.Name} to {deliveryObjective.DeliverTo}");
                                break;
                            case SearchObjective searchObjective:
                                Console.Write("\tFind this person: ");
                                Console.WriteLine($"{searchObjective.WhoToFind}");
                                break;
                        }                     
                    }
                    Console.WriteLine("Reward: ");
                    if (quest.Reward.Items != null)
                    {
                        Console.WriteLine("Items: ");
                        foreach (var item in quest.Reward.Items)
                        {
                            Console.WriteLine($"\t\t{item.Quantity}x {item.Name}");
                        }
                    }
                    if (quest.Reward.AttBonuses != null)
                    {
                        Console.WriteLine("\tAttribute bonuses: ");
                        foreach (var attBonus in quest.Reward.AttBonuses)
                        {
                            Console.WriteLine($"\t\t+{attBonus.Amount} {attBonus.Unit} to {attBonus.Name}");
                        }
                    }
                }
                
            }
        }

        public static PlayerSetting PrintCharacterCreationSetting(ChoiceList choiceList, string format)
        {
            var list = choiceList.List;
            var length = list.Count;

            var i = 1;
            foreach (var choice in list)
            {
                string bonus = null;
                if (choice.AttBonus != null)
                {
                    bonus = choice.AttBonus.Bonus();
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
}
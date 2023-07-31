using System;
using System.Collections.Generic;
using System.Linq;
using XperiaRPG.Scripts.CharacterCreation;
using Attribute = XperiaRPG.Scripts.Attributes.Attribute;

namespace XperiaRPG.Scripts.UI
{
    public static class Utility
    {
        private static void PrintBorder(int columns,int lengthOfColumn)
        {
            for (var i = 0; i < columns; i++)
            {
                Console.Write("+");
                for (var j = 0; j < lengthOfColumn; j++) Console.Write("-");
            }
            Console.Write("+\n");
        }

        public static void PrintAttributes(IEnumerable<Attribute> list,int columns, int lengthOfColumn, string format)
        {
            var attributes = list.ToList();
            var numOfItems = attributes.Count();
            
            PrintBorder(columns,lengthOfColumn);
            var i = 0;

            foreach (var attribute in attributes)
            {
                Console.Write(format, attribute.Name, attribute.Level, attribute.Value);

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
}
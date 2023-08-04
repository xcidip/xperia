using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XperiaRPG.Scripts.Skills;

namespace XperiaRPG.Scripts.UI
{
    public static class SkillUtils
    {
        public static void PrintMenuHeader(int columns, int lengthOfColumn, string header)
        {
            Utility.PrintBorder(columns, lengthOfColumn);
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.WriteLine($"+-----{header.ToUpper()}");
        }

        public static void PrintCraftingMenu(string header, int columns, int lengthOfColumn, string format,
            RecipeList recipeList)
        {
            /*
            +------------------------------------------------+------------------------------------------------+
            | Cooked Shrimp    - 1x Shrimp 1x Knife          | Cooked Trout      - 1x Trout 1x Shrimp         |
            | Cooked Trout     - 1x Trout 1x Shrimp          | Cooked Shrimp     - 1x Shrimp 1x Knife         |
            +------------------------------------------------+------------------------------------------------+
             */
            var list = recipeList.List;
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

            foreach (var recipe in list)
            {
                Console.Write($"{"| (" + (i + 1) + ") ",-4}");
                Console.Write(format,
                    recipe.Name); //0
                Console.Write("- ");
                var itemsNeeded = recipe.List.Aggregate("", (current, item) => current + $"{item.Quantity}x {item.Name}");
                Console.Write($"{itemsNeeded,-23}");
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

    }
}

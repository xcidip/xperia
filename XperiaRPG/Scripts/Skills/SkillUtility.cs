using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using XperiaRPG.Scripts.Character.Player;
using XperiaRPG.Scripts.Items;
using XperiaRPG.Scripts.Misc;
using XperiaRPG.Scripts.UI;

namespace XperiaRPG.Scripts.Skills
{
    public class Recipe
    {
        public string Name { get; set; } // Name of recipe (name of Result)
        public int RequiredLevel { get; set; } // level required for crafting this recipe
        public List<ItemStack> List { get; set; } // list of items needed for making
        public Item Result { get; set; } // result of the recipe
        public int Xp { get; set; }
        public string WhatSkill { get; set; }


        public Recipe(string whatSkill,Item result, int xp, int requiredLevel, List<ItemStack> list)
        {
            WhatSkill = whatSkill;
            Name = result.Name; // name of recipe is the results name (result.name)
            List = list;
            Xp = xp;
            Result = result;
            RequiredLevel = requiredLevel;
        }
    }

    public abstract class RecipeList
    {
        public List<Recipe> List { get; set; }

        protected RecipeList() { }

        public Recipe Lookup(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            return List.FirstOrDefault(a => a?.Name == name);
        }
    }

    

    public static class SkillUtils
    {
        public static void PrintCraftingMenu(string header, RecipeList recipeList)
        {
            /*
            +-COOKING------------------------------------------------------------------------+
            | (1) Cooked Shrimp(10xp) = 1x Knife 1x Trout 1x Shrimp 1x Flour                 |
            | (2) Cooked Trout(10xp) = 1x Knife 1x Trout 1x Shrimp 1x Flour                  |
            +--------------------------------------------------------------------------------+
             */
            if (recipeList.List.Count == 0) { Utility.Error("No recipes!"); return; }

            const int columnsLength = 85;
            var columns = (int)1;
            if (GlobalVariables.Columns >= 4) columns = 2;

            BorderUtility.PrintHeaderBorder(header, columns,columnsLength);

            var i = 0;
            foreach (var recipe in recipeList.List)
            {
                Console.Write($"{"| (" + (i + 1) + ") ",-4}"); // (1)
                
                var itemsNeeded = recipe.List.Aggregate("", (current, item) => current + $"{item.Quantity}x {item.Name} ");
                Console.Write($"{recipe.Result.Name + "(" + recipe.Xp + "xp) = " + itemsNeeded,-(columnsLength-5)}");
                i++;

                if (i % columns != 0 && i != recipeList.List.Count) continue;

                var remainingItemsInRow = i % columns;
                var blankSpaces = remainingItemsInRow == 0 ? 0 : columns - remainingItemsInRow;

                // Print the blank spaces for the remaining items in the row
                for (var j = 0; j < blankSpaces; j++)
                {
                    Console.Write($"|{new string(' ', columnsLength)}");
                }

                Console.WriteLine("|");
            }
            BorderUtility.PrintBorder(columns, columnsLength);
        }

    }

    public static class Traveling
    {
        public static void Travel(int seconds)
        {
            Console.Clear();
            for (var i = 0; i < seconds*2; i++)
            {
                Console.WriteLine($"Travel time {i/2}/{seconds} seconds");
                //Console.SetCursorPosition(0, Console.CursorTop);
                Console.SetCursorPosition(Console.CursorLeft + i, Console.CursorTop);
                Console.WriteLine("   __o ");
                Console.SetCursorPosition(Console.CursorLeft + i, Console.CursorTop);
                Console.WriteLine(" _ \\<_ ");
                Console.SetCursorPosition(Console.CursorLeft + i, Console.CursorTop);
                Console.WriteLine("(_)/(_)");

                Console.Write("-------");
                for (var j = 0; j < seconds*2; j++)
                {
                    Console.Write("-");
                }
                Console.Write("finish");

                Thread.Sleep(500);
                
                Console.Clear();
            }
        }
    }
}

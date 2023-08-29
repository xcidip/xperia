using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using XperiaRPG.Scripts.Items;
using XperiaRPG.Scripts.UI;

namespace XperiaRPG.Scripts.Skills
{
    public class Recipe
    {
        public string Name { get; set; } // Name of recipe (name of Result)
        public int RequiredLevel { get; set; } // level required for crafting this recipe
        public List<ItemStack> List { get; set; } // list of items needed for making
        public Item Result { get; set; } // result of the recipe


        public Recipe(Item result, int requiredLevel, List<ItemStack> list)
        {
            Name = result.Name; // name of recipe is the results name (result.name)
            List = list;
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

    public class ProfessionTool : Item
    {

        public ProfessionTool(string name, string description, int price, (ConsoleColor Foreground, ConsoleColor Background) colors)
            : base(name, description, price, colors)
        {
            
        }

        public override void Examine()
        {

        }

        public override void Use()
        {

        }

    }

    public class ProfessionToolItemList : ItemList
    {
        public ProfessionToolItemList()
        {
            List = new List<Item>
            {
                new ProfessionTool("Knife","Used for cutting in Cooking",2, Rarity.Common),
            };
        }
    }

    public static class SkillUtils
    {
        public static void PrintMenuHeader(int columns,int lengthOfColumn, string header)
        {
            Utility.PrintBorder(columns,lengthOfColumn);
            Console.SetCursorPosition(5, Console.CursorTop - 1);
            Console.WriteLine($"{header.ToUpper()}");
        }

        public static void PrintCraftingMenu(string header, int lengthOfColumn, string format,
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
            PrintMenuHeader(GlobalVariables.Columns,lengthOfColumn, header);

            var i = 0;

            foreach (var recipe in list)
            {
                Console.Write($"{"| (" + (i + 1) + ") ",-4}");
                Console.Write(format,
                    recipe.Name); //0
                Console.Write("- ");
                var itemsNeeded = recipe.List.Aggregate("", (current, item) => current + $"{item.Quantity}x {item.Name} ");
                Console.Write($"{itemsNeeded,-23}");
                i++;
                if (i % GlobalVariables.Columns != 0 && i != numOfItems) continue;

                var remainingItemsInRow = i % GlobalVariables.Columns; 
                var blankSpaces = remainingItemsInRow == 0 ? 0 : GlobalVariables.Columns - remainingItemsInRow;

                // Print the blank spaces for the remaining items in the row
                for (var j = 0; j < blankSpaces; j++)
                {
                    Console.Write($"|{new string(' ', lengthOfColumn)}");
                }

                Console.WriteLine("|");
            }
            Utility.PrintBorder(GlobalVariables.Columns,lengthOfColumn);
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

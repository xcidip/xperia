using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XperiaRPG.Scripts.Items;
using XperiaRPG.Scripts.UI;

namespace XperiaRPG.Scripts.Skills
{
    public class Recipe
    {
        public string Name { get; set; } // Name of recipe (name of Result)
        public int RequiredLevel { get; set; } // level required for crafting this recipe
        public List<Item> List { get; set; } // list of items needed for making
        public Item Result { get; set; } // result of the recipe


        public Recipe(Item result, int requiredLevel, List<Item> list)
        {
            Name = result.Name; // name of recipe is the results name (result.name)
            List = list;
            Result = result;
            RequiredLevel = requiredLevel;
        }
    }

    public abstract class RecipeList
    {
        public List<Recipe> List { get; set; } = new List<Recipe>();

        protected RecipeList() { }

        public Recipe Lookup(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            return List.FirstOrDefault(a => a?.Name == name);
        }
    }

    public class ProfessionTool : Item
    {

        public ProfessionTool(int quantity, string name, string description, int price)
            : base(quantity, name, description, price)
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
                new ProfessionTool(1,"Knife","Used for cutting in Cooking",2),
            };
        }
    }

    public static class SkillUtils
    {
        public static void PrintMenuHeader(int lengthOfColumn, string header)
        {
            Utility.PrintBorder(lengthOfColumn);
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
            PrintMenuHeader(lengthOfColumn, header);

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
            Utility.PrintBorder(lengthOfColumn);
        }

    }
}

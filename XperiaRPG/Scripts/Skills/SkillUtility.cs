using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XperiaRPG.Scripts.Items;

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

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using XperiaRPG.Scripts.Items;

namespace XperiaRPG.Scripts.Skills
{
    public class Cooking
    {
    }

    public class Recipe
    {
        public string Name { get; set; } // Name of recipe (name of Food)
        public string Description { get; set; }
        public List<string> List { get; set; } // list of ingredients needed for making
        public Food Food { get; set; } // result of the recipe
        public int RequiredLevel { get; set; } // cooking level required for crafting this recipe


        public Recipe(Food food,int requiredLevel, string description, List<string> list)
        {
            Name = food.Name; // name of recipe is the results name (food.name)
            Description = description;
            List = list;
            Food = food;
            RequiredLevel = requiredLevel;
        }
    }

    public class RecipeList
    {
        public List<Recipe> List { get; set; }

        public RecipeList(FoodList foodList)
        {
            List = new List<Recipe>
            {
                new Recipe((Food)foodList.Lookup("Cooked Shrimp"),0,"Well made Cooked Shrimp",new List<string>
                {
                    "Shrimp"
                })
            };
        }
    }

    public class Ingredient : Item
    {
        public Ingredient(int quantity, string name, string description, int price)
            : base(quantity, name, description, price)
        {

        }


        public override void Use()
        {

        }

        public override void Examine()
        {

        }
    }

    public class IngredientList : ListOfItems
    {
        public IngredientList()
        {
            List = new List<Item>
            {
                new Ingredient(1,"Flour","Flour from the local wheat farm", 5),
            };
        }
    }

    public class Food : Item
    {
        public Food(int quantity, string name, string description, int price)
            : base(quantity, name, description, price)
        {

        }


        public override void Use()
        {
            // eat
        }

        public override void Examine()
        {

        }
    }

    public class FoodList : ListOfItems
    {
        public FoodList()
        {
            List = new List<Item>
            {
                new Food(1,"Cooked fish", "Nice tasteful fish by Arnold", 20),
            };
        }
    }

    

}

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
        /*
         * 1) select a recipe from a list by (num)
         * 2) Check if have Items needed for the recipe
         * 3) Remove consumed items (not knife for example)
         * 4) Add finished Result
         */




        public Cooking()
        {

        }

        public static void Print()
        {
            //todo 
        }
    }

    


    public class CookingRecipeList : RecipeList
    {
        public CookingRecipeList(ItemList fishItemList, ItemList foodItemList, MaterialItemList materialItemList)
        {
            List = new List<Recipe>
            {
                new Recipe(foodItemList.Lookup("Cooked Shrimp"),
                    0,
                    new List<Item>
                    {
                        fishItemList.Lookup("Shrimp")
                    }),
                new Recipe(foodItemList.Lookup("Cooked Trout"),
                    5,
                    new List<Item>
                    {
                        fishItemList.Lookup("Trout")
                    }),
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
            //todo 
        }
    }

    public class FoodItemList : ItemList
    {
        public FoodItemList()
        {
            List = new List<Item>
            {
                new Food(1,"Cooked Shrimp", "Nice tasteful fish by Arnold", 10),
                new Food(1,"Cooked Trout", "Nice tasteful fish by Arnold", 15),
            };
        }
    }

}

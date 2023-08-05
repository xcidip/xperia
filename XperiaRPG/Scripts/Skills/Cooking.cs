﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using XperiaRPG.Scripts.Items;
using XperiaRPG.Scripts.UI;

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
        public FishItemList FishItemList { get; set; }
        public MaterialItemList MaterialItemList { get; set; }
        public FoodItemList FoodItemList { get; set; }
        public static CookingRecipeList CookingRecipeList { get; set; }
        

        public Cooking()
        {
            FishItemList = new FishItemList();
            MaterialItemList = new MaterialItemList();
            FoodItemList = new FoodItemList();
            CookingRecipeList = new CookingRecipeList(FishItemList, FoodItemList, MaterialItemList);

        }

        public void Print()
        {
            SkillUtils.PrintCraftingMenu("Cooking", 2, 50, "{0,-20}", CookingRecipeList);
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
                    10,
                    new List<Item>
                    {
                        fishItemList.Lookup("Trout")
                    }),
                new Recipe(foodItemList.Lookup("Cooked Salmon"),
                    20,
                    new List<Item>
                    {
                        fishItemList.Lookup("Salmon")
                    }),
                new Recipe(foodItemList.Lookup("Cooked Tuna"),
                    30,
                    new List<Item>
                    {
                        fishItemList.Lookup("Tuna")
                    }),
                new Recipe(foodItemList.Lookup("Cooked Crayfish"),
                    40,
                    new List<Item>
                    {
                        fishItemList.Lookup("Crayfish")
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
                new Food(1,"Cooked Shrimp", "Nice tasteful fish by Arnold", 20),
                new Food(1,"Cooked Trout", "Nice tasteful fish by Arnold", 25),
                new Food(1,"Cooked Salmon", "Nice tasteful fish by Arnold", 35),
                new Food(1,"Cooked Tuna", "Nice tasteful fish by Arnold", 45),
                new Food(1,"Cooked Crayfish", "Nice tasteful fish by Arnold", 50),
            };
        }
    }

}
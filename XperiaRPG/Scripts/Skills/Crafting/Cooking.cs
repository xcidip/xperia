﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using XperiaRPG.Scripts.Attributes;
using XperiaRPG.Scripts.Character.Player.Inventory;
using XperiaRPG.Scripts.Items;
using XperiaRPG.Scripts.Skills.Crafting;
using XperiaRPG.Scripts.UI;

namespace XperiaRPG.Scripts.Skills
{
    public class Cooking : CraftingSkill
    {
        /*
         * 1) select a recipe from a list by (num)
         * 2) Check if have Items needed for the recipe
         * 3) Remove consumed items (not knife for example)
         * 4) Add finished Result
         */
        public Cooking()
        {
            RecipeList = new CookingRecipeList();
        }

        public override void Print()
        {
            SkillUtils.PrintCraftingMenu("Cooking", 50, "{0,-20}", RecipeList);
        }
    }

    


    public class CookingRecipeList : RecipeList
    {
        public FishItemList FishItemList;
        public FoodItemList FoodItemList;
        public MaterialItemList MaterialItemList;
        public CookingRecipeList()
        {
            FishItemList = new FishItemList();
            FoodItemList = new FoodItemList();
            MaterialItemList = new MaterialItemList();

            List = new List<Recipe>
            {
                new Recipe("Cooking",
                    FoodItemList.Lookup("Cooked Shrimp"),
                    5,0,
                    new List<ItemStack>
                    {
                        new ItemStack(1, FishItemList.Lookup("Shrimp")),
                    }),
                new Recipe("Cooking",
                    FoodItemList.Lookup("Cooked Trout"),
                    10,10,
                    new List<ItemStack>
                    {
                        new ItemStack(1, FishItemList.Lookup("Trout")),
                    }),
                new Recipe("Cooking",
                    FoodItemList.Lookup("Cooked Salmon"),
                    15,20,
                    new List<ItemStack>
                    {
                        new ItemStack(1, FishItemList.Lookup("Salmon")),
                    }),
                new Recipe("Cooking", 
                    FoodItemList.Lookup("Cooked Tuna"),
                    25,30,
                    new List<ItemStack>
                    {
                        new ItemStack(1, FishItemList.Lookup("Tuna")),
                    }),
                new Recipe("Cooking",
                    FoodItemList.Lookup("Cooked Crayfish"),
                    30,40,
                    new List<ItemStack>
                    {
                        new ItemStack(1, FishItemList.Lookup("Crayfish")),
                    }),
            };
        }
    }



    public class Food : Item
    {
        public Food(string name, string description, int price, (ConsoleColor Foreground, ConsoleColor Background) colors)
            : base(name, description, price, colors)
        {

        }


        public override void Use()
        {
            // eat
        }

        public new void Examine()
        {
            //todo heal value
        }
    }

    public class FoodItemList : ItemList
    {
        public FoodItemList()
        {
            List = new List<Item>
            {
                new Food("Cooked Shrimp", "Nice tasteful fish by Arnold", 20, Rarity.Common),
                new Food("Cooked Trout", "Nice tasteful fish by Arnold", 25, Rarity.Common),
                new Food("Cooked Salmon", "Nice tasteful fish by Arnold", 35, Rarity.Uncommon),
                new Food("Cooked Tuna", "Nice tasteful fish by Arnold", 45, Rarity.Uncommon),
                new Food("Cooked Crayfish", "Nice tasteful fish by Arnold", 50, Rarity.Rare),
            };
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XperiaRPG.Scripts.Character.Player.Inventory;
using XperiaRPG.Scripts.Items;
using XperiaRPG.Scripts.Skills.Crafting;
using XperiaRPG.Scripts.UI;

namespace XperiaRPG.Scripts.Skills
{
    public abstract class CraftingSkill
    {
        public RecipeList RecipeList { get; protected set; }
        public MaterialItemList MaterialItemList { get; protected set; }
        public FoodItemList FoodItemList { get; protected set; }
        public FishItemList FishItemList { get; protected set; }
        public HerbItemList HerbItemList { get; protected set; }
        public PotionItemList PotionItemList { get; protected set; }
        public ArmorItemList ArmorItemList { get; protected set; }

        protected CraftingSkill()
        {
        }

        public void Craft(Recipe recipe, Inventory inv)
        {
            // Have enough resources in inventory for that recipe?
            foreach (var stack in recipe.List) // check each stack
            {
                // count how many of that item is in the inventory
                var itemNum = 0;
                foreach (var item in inv.List) // check for each item occurence
                {
                    if (item.Name == stack.Name && item.Name != null) itemNum++;
                }

                // if you dont have the required item in your inventory at all
                if (itemNum == 0) { Console.WriteLine($"You dont have: {stack.Name}"); return; }

                // if there is more in the recipe than in inventory
                if (stack.Quantity > itemNum) { Console.WriteLine($"You need {stack.Quantity - itemNum} of {stack.Name}"); return; }
            }

            // remove items from inv
            foreach (var stack in recipe.List)
            {
                for (var i= 0; i < stack.Quantity; i++) 
                {
                    inv.RemoveItem(inv.Lookup(stack.Item.Name));
                }
            }

            // add result
            inv.AddItem(new ItemStack(1, recipe.Result));


            Choice.PressEnter();
        }
        public void WhatToCraft(Inventory inv)
        {
            Console.WriteLine("What do you want to craft 0 - EXIT");
            var choice = Choice.NumberRangeValidation(0, RecipeList.List.Count);
            if (choice == 0) return;
            Craft(RecipeList.List[choice - 1], inv);
        }

        public void Print()
        {
            SkillUtils.PrintCraftingMenu("Cooking", 50, "{0,-20}", RecipeList);
        }
    }
}

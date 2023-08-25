using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XperiaRPG.Scripts.Character.Player.Inventory;
using XperiaRPG.Scripts.UI;

namespace XperiaRPG.Scripts.Skills
{
    public abstract class CraftingSkill
    {
        public RecipeList RecipeList { get; protected set; }

        protected CraftingSkill()
        {
        }

        public void Craft(Recipe recipe, Inventory inv)
        {
            var thingsNeeded = recipe.List;
            foreach (var item in thingsNeeded)
            {
                if (inv.Lookup(item.Name) == null)
                {
                    Console.WriteLine($"{item.Name} is not in your inventory!");
                    return;
                }

            }
            foreach (var item in thingsNeeded)
            {
                inv.RemoveItem(inv.Lookup(item.Name));
            }
            inv.AddItem(recipe.Result);
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

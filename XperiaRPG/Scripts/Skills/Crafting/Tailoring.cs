﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XperiaRPG.Scripts.Items;

namespace XperiaRPG.Scripts.Skills.Crafting
{
    public class Tailoring : CraftingSkill
    {
        /*
         * 1) select a recipe from a list by (num)
         * 2) Check if have Items needed for the recipe
         * 3) Remove consumed items (not knife for example)
         * 4) Add finished Result
         */

        public Tailoring()
        {
            RecipeList = new TailoringRecipeList();
        }

    }

    public class TailoringRecipeList : RecipeList
    {
        MaterialItemList MaterialItemList;
        ArmorItemList ArmorItemList;
        
        public TailoringRecipeList()
        {
            List = new List<Recipe>
            {
                new Recipe(ArmorItemList.Lookup("Wizard's Coat"),
                    0,
                    new List<ItemStack>
                    {
                        new ItemStack(1,MaterialItemList.Lookup("Linen cloth")),
                    }),

                new Recipe(ArmorItemList.Lookup("Wizard's Skirt"),
                    0,
                    new List<ItemStack>
                    {
                        new ItemStack(1,MaterialItemList.Lookup("Linen cloth")),
                    }),
                
                new Recipe(ArmorItemList.Lookup("Wizard's Hat"),
                    0,
                    new List<ItemStack>
                    {
                        new ItemStack(1,MaterialItemList.Lookup("Linen cloth")),
                    }),
            };
        }
    }
}

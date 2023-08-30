using System;
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
        public override void Print()
        {
            SkillUtils.PrintCraftingMenu("Tailoring", 50, "{0,-20}", RecipeList);
        }
    }

    public class TailoringRecipeList : RecipeList
    {
        public MaterialItemList MaterialItemList;
        public Armor.ArmorItemList ArmorItemList;
        
        public TailoringRecipeList()
        {
            MaterialItemList = new MaterialItemList();
            ArmorItemList = new Armor.ArmorItemList();
            List = new List<Recipe>
            {
                new Recipe("Tailoring",
                    ArmorItemList.Lookup("Wizard's Coat"),
                    10,0,
                    new List<ItemStack>
                    {
                        new ItemStack(1,MaterialItemList.Lookup("Linen cloth")),
                    }),

                new Recipe("Tailoring",
                    ArmorItemList.Lookup("Wizard's Skirt"),
                    10,0,
                    new List<ItemStack>
                    {
                        new ItemStack(1,MaterialItemList.Lookup("Linen cloth")),
                    }),
                
                new Recipe("Tailoring",
                    ArmorItemList.Lookup("Wizard's Hat"),
                    10, 0,
                    new List<ItemStack>
                    {
                        new ItemStack(1,MaterialItemList.Lookup("Linen cloth")),
                    }),
            };
        }
    }
}

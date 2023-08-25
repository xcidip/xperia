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
            MaterialItemList = new MaterialItemList();
            ArmorItemList = new ArmorItemList();
            RecipeList = new TailoringRecipeList(MaterialItemList,ArmorItemList);
        }

    }

    public class TailoringRecipeList : RecipeList
    {
        public TailoringRecipeList(MaterialItemList materialItemList, ArmorItemList armorItemList)
        {
            List = new List<Recipe>
            {
                new Recipe(armorItemList.Lookup("Wizard's Coat"),
                    0,
                    new List<Item>
                    {
                        materialItemList.Lookup("Linen cloth"),
                    }),

                new Recipe(armorItemList.Lookup("Wizard's Skirt"),
                    0,
                    new List<Item>
                    {
                        materialItemList.Lookup("Linen cloth"),
                    }),
                
                new Recipe(armorItemList.Lookup("Wizard's Hat"),
                    0,
                    new List<Item>
                    {
                        materialItemList.Lookup("Linen cloth"),
                    }),
            };
        }
    }
}

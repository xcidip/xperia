﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XperiaRPG.Scripts.Skills.Crafting
{
    public class Alchemy : CraftingSkill
    {
        public Alchemy()
        {
            RecipeList = new AlchemyRecipeList();
        }
        public override void Print()
        {
            SkillUtils.PrintCraftingMenu("Alchemy", RecipeList);
        }
    }

    public class Cooking : CraftingSkill
    {
        public Cooking()
        {
            RecipeList = new CookingRecipeList();
        }

        public override void Print()
        {
            SkillUtils.PrintCraftingMenu("Cooking", RecipeList);
        }
    }
    public class Tailoring : CraftingSkill
    {
        public Tailoring()
        {
            RecipeList = new TailoringRecipeList();
        }
        public override void Print()
        {
            SkillUtils.PrintCraftingMenu("Tailoring",RecipeList);
        }
    }
}

using System;
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

    public class Smithing : CraftingSkill
    {
        public Smithing()
        {
            RecipeList = new SmithingRecipeList();
        }
        public override void Print()
        {
            SkillUtils.PrintCraftingMenu("Smithing", RecipeList);
        }
    }
    public class Lthrworking : CraftingSkill
    {
        public Lthrworking()
        {
             RecipeList = new LthrworkingRecipeList();
        }
        public override void Print()
        {
            SkillUtils.PrintCraftingMenu("Lthrworking", RecipeList);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XperiaRPG.Scripts.Character.Player;
using XperiaRPG.Scripts.Items;

namespace XperiaRPG.Scripts.Skills.Crafting
{
    public class Alchemy : CraftingSkill
    {
        /*
         * 1) select a recipe from a list by (num)
         * 2) Check if have Items needed for the recipe
         * 3) Remove consumed items (not knife for example)
         * 4) Add finished Result
         */
        
        public Alchemy()
        {
            RecipeList = new AlchemyRecipeList();
        }
        public override void Print()
        {
            SkillUtils.PrintCraftingMenu("Alchemy", 50, "{0,-20}", RecipeList);
        }
    }


    public class HerbItemList : ItemList
    {
        public HerbItemList()
        {
            List = new List<Item>
            {
                new Herb("Peacebloom","the most common herb there is",2, Rarity.Common),
                new Herb("Goldthorn","ouch stingy",5, Rarity.Common),
                new Herb("Sungrass","grass but shinier name", 10, Rarity.Uncommon),
            };
        }
    }
    public class Herb : Item
    {
        public Herb(string name, string description, int price, (ConsoleColor Foreground, ConsoleColor Background) colors)
            : base(name, description, price, colors)
        {

        }
        public override void Use(Player player)
        {

        }
    }
    
    public class AlchemyRecipeList : RecipeList
    {
        MaterialItemList MaterialItemList;
        HerbItemList HerbItemList;
        PotionItemList PotionItemList;
        public AlchemyRecipeList()
        {
            MaterialItemList = new MaterialItemList();
            HerbItemList = new HerbItemList();
            PotionItemList = new PotionItemList();

            List = new List<Recipe>
            {
                new Recipe("Alchemy",
                    PotionItemList.Lookup("Small HP potion"),
                    10,0,
                    new List<ItemStack>
                    {
                        new ItemStack(1,MaterialItemList.Lookup("Flask")),
                        new ItemStack(1,HerbItemList.Lookup("Peacebloom")),
                    }),

                new Recipe("Alchemy",
                    PotionItemList.Lookup("Medium HP potion"),
                    50,10,
                    new List<ItemStack>
                    {
                        new ItemStack(1,MaterialItemList.Lookup("Flask")),
                        new ItemStack(1,HerbItemList.Lookup("Goldthorn")),
                    }),

                new Recipe("Alchemy",
                    PotionItemList.Lookup("Large HP potion"),
                    100,0,
                    new List<ItemStack>
                    {
                        new ItemStack(1,MaterialItemList.Lookup("Flask")),
                        new ItemStack(1,HerbItemList.Lookup("Sungrass")),
                    }),
            };
        }
    }
    
}

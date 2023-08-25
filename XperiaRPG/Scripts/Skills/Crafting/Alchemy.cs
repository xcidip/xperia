using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            MaterialItemList = new MaterialItemList();
            HerbItemList = new HerbItemList();
            PotionItemList = new PotionItemList();
            RecipeList = new AlchemyRecipeList(MaterialItemList, HerbItemList, PotionItemList);
        }

    }


    public class HerbItemList : ItemList
    {
        public HerbItemList()
        {
            List = new List<Item>
            {
                new Herb(1,"Peacebloom","the most common herb there is",2),
                new Herb(1,"Goldthorn","ouch stingy",5),
                new Herb(1,"Sungrass","grass but shinier name", 10),
            };
        }
    }
    public class Herb : Item
    {
        public Herb(int quantity, string name, string description, int price)
            : base(quantity, name, description, price)
        {

        }
        public override void Use()
        {

        }

        public override void Examine()
        {
            //todo 
        }
    }
    
    public class AlchemyRecipeList : RecipeList
    {
        public AlchemyRecipeList(MaterialItemList materialItemList, HerbItemList herbItemList, PotionItemList potionItemList)
        {
            List = new List<Recipe>
            {
                new Recipe(potionItemList.Lookup("Small HP potion"),
                    0,
                    new List<Item>
                    {
                        materialItemList.Lookup("Flask"),
                        herbItemList.Lookup("Peacebloom"),
                    }),

                new Recipe(potionItemList.Lookup("Medium HP potion"),
                    10,
                    new List<Item>
                    {
                        materialItemList.Lookup("Flask"),
                        herbItemList.Lookup("Goldthorn"),
                    }),

                new Recipe(potionItemList.Lookup("Large HP potion"),
                    0,
                    new List<Item>
                    {
                        materialItemList.Lookup("Flask"),
                        herbItemList.Lookup("Sungrass"),
                    }),
            };
        }
    }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XperiaRPG.Scripts.Character.Attributes;
using XperiaRPG.Scripts.Character.Player.Inventory;
using XperiaRPG.Scripts.Skills;
using XperiaRPG.Scripts.Skills.Crafting;
using XperiaRPG.Scripts.Skills.Gathering;

namespace XperiaRPG.Scripts.Items
{
    public class FoodItemList : ItemList
    {
        public FoodItemList()
        {
            List = new List<Item>
            {
                new Food("Cooked Shrimp",20, "Nice tasteful fish by Arnold", 20, Rarity.Common),
                new Food("Cooked Trout",30, "Nice tasteful fish by Arnold", 25, Rarity.Common),
                new Food("Cooked Salmon",40, "Nice tasteful fish by Arnold", 35, Rarity.Uncommon),
                new Food("Cooked Tuna",50, "Nice tasteful fish by Arnold", 45, Rarity.Uncommon),
                new Food("Cooked Crayfish",60, "Nice tasteful fish by Arnold", 50, Rarity.Rare),
            };
        }
    }

    public class FishItemList : ItemList
    {
        public FishItemList()
        {
            List = new List<Item>
            {
                new Fish("Shrimp", "Little shrimp, so easy to catch.", 5,15, Rarity.Common),
                new Fish("Trout", "Trout, so easy to catch.",10, 20, Rarity.Common),
                new Fish("Salmon", "Could be delicious if cooked.",15, 30, Rarity.Uncommon),
                new Fish("Tuna", "Tuna, so tasty.",20,40, Rarity.Uncommon),
                new Fish("Crayfish", $"Crusty Crayfish, not so easy to catch.",25, 45, Rarity.Rare),
            };
        }

    }

    public class ArmorItemList : ItemList
    {

        public ArmorItemList()
        {
            List = new List<Item>
            {
                new Armor(0, GearSlot.Chest, "Cloth", "Wizard's Coat", 200, "Belonged to an old wizard once",
                    new List<AttBonus>()
                    {
                        new AttBonus("Intellect", 3, "points"),
                        new AttBonus("Defense", 2, "points"),
                        new AttBonus("Agility", 1, "points")
                    }, Rarity.Uncommon),
                new Armor(0, GearSlot.Legs, "Cloth", "Wizard's Skirt", 200, "Belonged to an old wizard once",
                    new List<AttBonus>()
                    {
                        new AttBonus("Intellect", 2, "points"),
                        new AttBonus("Defense", 4, "points"),
                        new AttBonus("Agility", 2, "points")
                    }, Rarity.Uncommon),
                new Armor(0, GearSlot.Head, "Cloth", "Wizard's Hat", 200, "Belonged to an old wizard once",
                    new List<AttBonus>()
                    {
                        new AttBonus("Defense", 3, "points"),
                        new AttBonus("Intellect", 4, "points")
                    }, Rarity.Uncommon),
                new Armor(0, GearSlot.Head, "Cloth", "Arnold's test", 9999, "Belonged to an old wizard once",
                    new List<AttBonus>()
                    {
                        new AttBonus("Mining", 13034431, "xp"),
                        new AttBonus("Intellect", 4, "points")
                    }, Rarity.Uncommon),
            };
        }
    }

    public class PotionItemList : ItemList
    {
        public PotionItemList()
        {
            List = new List<Item>
            {
                new HealingPotion("Small HP potion","Heals for a small amount of health",20,10, Rarity.Common),
                new HealingPotion("Medium HP potion","Medium health potion for medium health pool",40,50, Rarity.Common),
                new HealingPotion("Large HP potion","Big boy healing",100,200, Rarity.Common),
            };
        }
    }

    public class BookItemList : ItemList
    {
        public BookItemList()
        {
            List = new List<Item>
            {
                new Book("Dev book 1","this book is about the books in this game",0,Rarity.Uncommon,
                    "The game\nWell hello, I see you can open books now, congratulations.\nYou know" +
                    " this is the first book I am writing in this game.\nToday is 30/8/23 and this project has 3.8k lines" +
                    " and I think I am about half way done with the game :) ...\nBye Bye, see you in the next book scattered across the game"),
            };
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

    public class MaterialItemList : ItemList
    {
        public MaterialItemList()
        {
            List = new List<Item>
            {
                new Material("Flour","Flour from the local wheat farm", 5, Rarity.Common),
                new Material("Flask","Flask for alchemy for example",5, Rarity.Common),
                new Material("Linen cloth","Cloth for making cloth armor", 5, Rarity.Common),
                // iron bar...
                // herbs maybe??
            };
        }
    }

    public class ProfessionToolItemList : ItemList
    {
        public ProfessionToolItemList()
        {
            List = new List<Item>
            {
                new ProfessionTool("Knife","Used for cutting in Cooking",2, Rarity.Common),
            };
        }
    }

    public class WeaponItemList : ItemList
    {


        public WeaponItemList()
        {
            List = new List<Item>
            {
                new Weapon( 0, GearSlot.MainHand, "Melee", "Arnold's Sword",150, "Best of the swords",
                    new List<AttBonus>()
                    {
                        new AttBonus("Strength", 4, "points"),
                        new AttBonus("Defense", 2, "points"),
                    }, Rarity.Common),
                new Weapon(0, GearSlot.OffHand, "Melee", "Arnold's Iron Shield",150, "Best of the iron shields",
                    new List<AttBonus>()
                    {
                        new AttBonus("Defense", 4, "points"),
                        new AttBonus("NatureRes", 3, "points"),
                    }, Rarity.Common),
                new Weapon(0, GearSlot.MainHand, "Magic", "Arnold's Staff",150, "Best of the staffs",
                    new List<AttBonus>()
                    {
                        new AttBonus("Intellect", 4, "points"),
                        new AttBonus("Defense", 2, "points"),
                    }, Rarity.Common),
                new Weapon(0, GearSlot.OffHand, "Magic", "Arnold's Tome",150, "Best of the Tomes",
                    new List<AttBonus>()
                    {
                        new AttBonus("Intellect", 5, "points"),
                    }, Rarity.Common),
            };
        }

    }

}

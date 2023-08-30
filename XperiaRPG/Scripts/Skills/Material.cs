using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XperiaRPG.Scripts.Character.Player;
using XperiaRPG.Scripts.Items;

namespace XperiaRPG.Scripts.Skills
{
    // basic materials for all professions
    public class Material : Item
    {
        public Material(string name, string description, int price, (ConsoleColor Foreground, ConsoleColor Background) colors)
            : base(name, description, price, colors)
        {

        }


        public override void Use(Player player)
        {

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
}

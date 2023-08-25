using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XperiaRPG.Scripts.Items;

namespace XperiaRPG.Scripts.Skills
{
    // basic materials for all professions
    public class Material : Item
    {
        public Material(int quantity, string name, string description, int price)
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

    public class MaterialItemList : ItemList
    {
        public MaterialItemList()
        {
            List = new List<Item>
            {
                new Material(1,"Flour","Flour from the local wheat farm", 5),
                new Material(1,"Flask","Flask for alchemy for example",5),
                new Material(1,"Linen cloth","Cloth for making cloth armor", 5),
                // iron bar...
                // herbs maybe??
            };
        }
    }

    public class Ingredient : Item
    {
        public Ingredient(int quantity, string name, string description, int price)
            : base(quantity, name, description, price)
        {

        }

        public override void Use()
        {

        }

        public override void Examine()
        {
            // todo
        }
    }
}

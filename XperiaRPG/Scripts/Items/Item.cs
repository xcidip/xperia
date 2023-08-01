using System.Collections.Generic;
using XperiaRPG.Scripts.Attributes;
using XperiaRPG.Scripts.Characters.Inventory;

namespace XperiaRPG.Scripts.Items
{
    public abstract class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int RequiredLevel { get; set; }
        public int Price { get; set; }
        public GearSlot GearSlot { get; set; } // mount, pickaxe, head slot...
        public List<AttributeBonus> AttributeBonusList { get; set; }
        
        // protected = cannot be called outside of this class
        protected Item(int quantity, string name, string description, int price)
        {
            Quantity = quantity;
            Description = description;
            Name = name;
            Price = price;
        }

        // Abstract method for using an item (to be implemented by derived classes)
        public abstract void Use();
        public void Reduce()
        {
            Quantity--;
        }
    }

    public abstract class Database
    {
        protected Database()
        {
        }
    }
}
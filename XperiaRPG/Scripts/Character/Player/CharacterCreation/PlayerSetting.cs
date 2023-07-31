using System.Collections.Generic;
using XperiaRPG.Scripts.Attributes;

namespace XperiaRPG.Scripts.CharacterCreation
{
    public abstract class PlayerSetting
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public string Description { get; set; }

        public string Lore { get; set; }
        public AttributeBonus AttributeBonus { get; set; }
        public string HowToPlay { get; set; }
        public string ArmorType { get; set; }
        
        protected PlayerSetting(string name)
        {
            Name = name;
        }
    }
    
    public abstract class ChoiceList
    {
        public List<PlayerSetting> List { get; set; }
   
        protected ChoiceList()
        {
            List = new List<PlayerSetting>();
        }
    }
}


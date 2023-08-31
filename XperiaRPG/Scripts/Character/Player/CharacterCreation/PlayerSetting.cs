using System;
using System.Collections.Generic;
using System.Linq;
using XperiaRPG.Scripts.Character.Attributes;

namespace XperiaRPG.Scripts.Character.Player.CharacterCreation
{
    public abstract class PlayerSetting
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public string Description { get; set; }

        public string Lore { get; set; }
        public AttBonus AttBonus { get; set; }
        public string HowToPlay { get; set; }
        public string ArmorType { get; set; }
        public string WeaponStyle { get; set; }
        
        protected PlayerSetting(string name)
        {
            Name = name;
        }
    }
    public abstract class ChoiceList
    {
        public List<PlayerSetting> List { get; set; } = new List<PlayerSetting>();

        public PlayerSetting Lookup(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            return (PlayerSetting)List.FirstOrDefault(a => a?.Name == name);

        }
    }
}


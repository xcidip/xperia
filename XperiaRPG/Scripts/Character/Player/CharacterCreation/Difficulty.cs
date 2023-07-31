using System;
using System.Collections.Generic;
using System.Linq;

namespace XperiaRPG.Scripts.CharacterCreation
{
    public class Difficulty : PlayerSetting
    {
        public Difficulty(string name, double value, string description) 
            :base(name)
        {
            Description = description;
            Value = value;
        }
    }
    public class DifficultyList : ChoiceList
    {
        public DifficultyList()
        {

            List = new List<PlayerSetting>
            {
                new Difficulty("Easy", 0.75, "Bob plays Easy, don't be like Bob"),
                new Difficulty("Medium", 1.0, "For those who doesn't want to grind"),
                new Difficulty("Hard", 1.3, "I want to have a real challenge"),
                new Difficulty("Asian", 1.6, "Medium difficulty but for Asians"),
                new Difficulty("Godlike", 2.0, "You will hopefully kill a butterfly"),
                new Difficulty("Pure", 1.3, "For the real experience (no race, suffix & profession bonus, Hardcore)")
            };

        }
    
        public Difficulty Lookup(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            return (Difficulty)List.FirstOrDefault(a => a?.Name == name);
            
        }
    }
}
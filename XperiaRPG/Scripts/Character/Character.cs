using XperiaRPG.Scripts.Attributes;
using XperiaRPG.Scripts.Character.Player.CharacterCreation;
using XperiaRPG.Scripts.CharacterCreation;

namespace XperiaRPG.Scripts.Character
{
    public abstract class Character
    {
        public Name Name { get; set; }
        public Profession Profession { get; set; }
        public Race Race { get; set; }
        
        public Stats Stats { get; set; }

        protected Character()
        {
            
        }
    }
}
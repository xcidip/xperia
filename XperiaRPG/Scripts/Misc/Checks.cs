using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XperiaRPG.Scripts.Character.Player;
using XperiaRPG.Scripts.Items;
using XperiaRPG.Scripts.UI;

namespace XperiaRPG.Scripts.Misc
{
    public static class Checks
    {
        public static bool EquipCheck(Player player, Item item)
        {
            if (item.ArmorType != null)
            {
                if (ArmorTypeCheck(player.CharacterInfo[1].ArmorType, item.ArmorType)) return true;
            }

            if (item.WeaponStyle != null)
            {
                if (WeaponStyleCheck(player.CharacterInfo[1].WeaponStyle, item.WeaponStyle)) return true;
            }
            if (LevelCheck(player.Skills.Lookup("PLAYER").Level, item.RequiredLevel)) return true;

            return false;
        }
        public static bool LevelCheck(int level, int requiredLevel)
        {
            if (requiredLevel < level) return false;
            Console.WriteLine($"Player level too low. {requiredLevel} level required!");
            Choice.PressEnter();
            return true;
        }
        public static bool WeaponStyleCheck(string yourStyle, string weaponStyle)
        {
            if (weaponStyle == "all") return false;

            if (yourStyle == weaponStyle) return false;
            
            Console.WriteLine($"Wrong weapon - you can only equip {yourStyle} weapons");
            Choice.PressEnter();
            return true;
        }
        public static bool ArmorTypeCheck(string yourArmorType, string armorType)
        {
            if (armorType == "all") return false;

            if (yourArmorType == armorType) return false;

            Console.WriteLine($"Wrong armor - you can only equip {yourArmorType} armor");
            Choice.PressEnter();
            return true;
        }
    }
}

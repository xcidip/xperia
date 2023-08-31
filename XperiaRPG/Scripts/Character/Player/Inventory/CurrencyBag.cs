using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XperiaRPG.Scripts.Character.Player.CharacterCreation;

namespace XperiaRPG.Scripts.Character.Player.Inventory
{
    public class CurrencyBag
    {
        public RaceList RaceList;
        public Currency GoldCrowns { get; set; }
        public Currency GemShards { get; set; }
        public Currency IronBits { get; set; }
        public Currency TrollFangs { get; set; }

        public CurrencyBag()
        {
            RaceList = new RaceList();
            GoldCrowns = new Currency("Gold Crowns", "GCR",0, RaceList.Lookup("Human"), 
                "Gold Crowns are the standard currency used by humans in the game world. They are known for their stability and wide acceptance.");
            GemShards = new Currency("Gem Shards", "GMS", 0, RaceList.Lookup("Gnome"),
                "Gnomes, being skilled jewelers and miners, use Gem Shards as their currency. These small, enchanted gem fragments hold both monetary and magical value.");
            IronBits = new Currency("Iron Bits", "IRB", 0, RaceList.Lookup("Orc"),
                "Orcs, known for their craftsmanship in weapons and armor, use Iron Bits as currency. These small iron pieces are not only used for trade but also for forging powerful equipment.");
            TrollFangs = new Currency("Troll Fangs", "TFG", 0, RaceList.Lookup("Troll"),
                "Trolls, with their formidable strength and regenerative abilities, use Troll Fangs as currency. These fangs are highly valued and can be used in alchemical and magical concoctions.");
        }
    }

    public class Currency
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public int Value { get; set; }
        public PlayerSetting Race { get; set; }
        public string Lore { get; set; }

        public Currency(string name, string abbreviation, int value, PlayerSetting race, string lore)
        {
            Name = name;
            Abbreviation = abbreviation;
            Value = value;
            Race = race;
            Lore = lore;
        }
    }
}

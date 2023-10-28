using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XperiaRPG.Scripts.Characters;

namespace XperiaRPG.Scripts.Misc
{
    // World(xperia) > Zone(Ashenfire Valley) > GatheringSpot (flower forest)
    //                                        > Dungeon (skeleton's den)
    //                                        > City > District(Crafting district) > Location(Blacksmith, Quest giver)
    //                                               > Location(Blacksmith, Quest giver)
    //                                        > Village > Location(Blacksmith, Quest giver)

    public class Place
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class World : Place
    {
        public List<Zone> Zones { get; set; } // list of zones/biomes/cities/villages
    }

    public class Zone : Place
    {
        public List<GatheringSpot> GatheringPlaces { get; set; }
        public List<Dungeon> Dungeons { get; set; }
        public List<GatheringSpot> GatheringSpots { get; set; }
        public List<Village> Villages { get; set; } 
        public City City { get; set; }
    }

    public class City : Place // west,east,north,south / crafting,trade,quest districts
    {
        public List<District> Districts { get; set; }
        public List<Location> Locations { get; set; }
    }
    public class Village : Place
    {
        public List<Location> Locations { get; set; }
    }
    public class GatheringSpot : Place
    {
        //todo
    }
    public class Dungeon : Place
    {
        public List<Enemy> Enemies { get; set; }
    }
    public class District : Place
    {
        public List<Location> Locations { get; set; }
    }

    public class Location : Place
    {

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XperiaRPG.Scripts.Character.NPC;
using XperiaRPG.Scripts.Character.Player;
using XperiaRPG.Scripts.UI;

namespace XperiaRPG.Scripts.Misc
{
    public static class Tutorial
    {
        public static void Start(NpcList npcList, Player player)
        {
            Cutscenes.Intro();


            var norwyn = npcList.Lookup("Norwyn");

            norwyn.Talk(player);


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XperiaRPG.Scripts.UI
{
    public static class Cutscenes
    {
        public static void Intro()
        {
            Console.WriteLine("    ___ __ \r\n   (_  ( . ) )__                  '.    \\   :   /    .'\r\n     '(___(_____)      __           '.   \\  :  /   .'\r\n                     /. _\\            '.  \\ : /  .'\r\n                .--.|/_/__      -----____   _  _____-----\r\n_______________''.--o/___  \\_______________(_)___________\r\n       ~        /.'o|_o  '.|  ~                   ~   ~\r\n  ~            |/    |_|  ~'         ~\r\n               '  ~  |_|        ~       ~     ~     ~\r\n      ~    ~          |_|O  ~                       ~\r\n             ~     ___|_||_____     ~       ~    ~\r\n   ~    ~      .'':. .|_|A:. ..::''.\r\n             /:.  .:::|_|.\\ .:.  :.:\\   ~\r\n  ~         :..:. .:. .::..:  .:  ..:.       ~   ~    ~\r\n             \\.: .:  :. .: ..:: . ../\r\n    ~      ~      ~    ~    ~         ~\r\n               ~           ~    ~   ~             ~\r\n        ~         ~            ~   ~                 ~\r\n   ~                  ~    ~ ~                 ~");
            Console.WriteLine("You just woke up on a deserted island");
            Console.WriteLine("A man is approaching you");
            Console.WriteLine("he says: \"Hey, I am norwyn\" ");
            Choice.PressEnter();
        }
    }
}

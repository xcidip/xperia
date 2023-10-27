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

        public static void FightLost()
        {
            Console.WriteLine("__   _____  _   _   ____ ___ _____ ____  \r\n\\ \\ / / _ \\| | | | |  _ \\_ _| ____|  _ \\ \r\n \\ V / | | | | | | | | | | ||  _| | | | |\r\n  | || |_| | |_| | | |_| | || |___| |_| |\r\n  |_| \\___/ \\___/  |____/___|_____|____/ ");
            Choice.PressEnter();
        }

        public static void FightWon()
        {
            Console.WriteLine("__   _____  _   _  __        _____  _   _ \r\n\\ \\ / / _ \\| | | | \\ \\      / / _ \\| \\ | |\r\n \\ V / | | | | | |  \\ \\ /\\ / / | | |  \\| |\r\n  | || |_| | |_| |   \\ V  V /| |_| | |\\  |\r\n  |_| \\___/ \\___/     \\_/\\_/  \\___/|_| \\_|");
            Console.WriteLine("Enemy has been defeated. Congratulations!");
            Choice.PressEnter();
        }

        public static void NewLevel(string name, int value)
        {
            Console.WriteLine(" _   _ _______        __  _     _______     _______ _     \r\n| \\ | | ____\\ \\      / / | |   | ____\\ \\   / / ____| |    \r\n|  \\| |  _|  \\ \\ /\\ / /  | |   |  _|  \\ \\ / /|  _| | |    \r\n| |\\  | |___  \\ V  V /   | |___| |___  \\ V / | |___| |___ \r\n|_| \\_|_____|  \\_/\\_/    |_____|_____|  \\_/  |_____|_____|");
            Console.WriteLine($"You have reached {value} level in {name}. Congratulations!");
            if (value == 99)
            {
                Console.WriteLine("Woow, you maxed a skill, good job dude! That must have taken a lot of work.");
            }
            Choice.PressEnter();
        }
    }
}

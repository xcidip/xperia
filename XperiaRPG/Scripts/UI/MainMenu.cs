using System.Threading;
using System;
using XperiaRPG.Assets.Sprites;

namespace XperiaRPG.Scripts.UI
{
    public static class MainMenu
    {
        public static void Welcome(int speed)
        {
            var welcome = new WelcomeSprite();
            Thread.Sleep(speed);
            var spriteLength = welcome.StickMan.Length;
            for (var i = 0; i < spriteLength; i++)
            {
                Thread.Sleep(speed);
                Console.Clear();
                Console.WriteLine("Welcome to Xeloria RPG!\n");
                Console.WriteLine(welcome.StickMan[i]);
                if (i > 1) { Console.Write("\n(1) Start"); }
                if (i > 2) { Console.Write(" new"); }
                if (i > 3) { Console.Write(" game\n"); }
                if (i > 4) { Console.Write("(2)"); }
                if (i > 5) { Console.Write(" Load"); }
                if (i > 6) { Console.Write(" game\n"); }
                if (i > 7) { Console.Write("(3)"); }
                if (i > 8) { Console.Write(" Exit"); }

            }
        }

        public static void Exit()
        {
            Console.WriteLine("Exiting the program failed if you see this");
            Environment.Exit(0);
        }
    }
}
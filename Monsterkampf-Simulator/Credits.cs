using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsterkampf_Simulator
{
    internal class Credits
    {
        #region real credits
        private static string n = "Yannick           ";
        #endregion
        private static string[][] creditsText = {
            new string[] {//z0
            " ____ ____  _____ ____  _ _____ ____ ",//1
            "/   _Y  __\\/  __//  _ \\/ Y__ __Y ___\\",//2
            "|  / |  \\/||  \\  | | \\|| | / \\ |    \\",//3
            "|  \\_|    /|  /_ | |_/|| | | | \\___ |",//4
            "\\____|_/\\_\\\\____\\\\____/\\_/ \\_/ \\____/" //5
            },
            new string[] {//z1
            "Ideology:",//0
            "Coding:",//1
            "Art:",//2
            "Marketing:",//3
            "Direction:    "//4
            },
            new string[] {//z2
            "Thomas W. R. Cesar",//0
            }
        };
        private static int x1 = Lobby.CenterTextX(creditsText[0][0]);
        private static int x2 = Lobby.CenterTextX(creditsText[1][4] + creditsText[2][0]);//längste string + Name
        private static int y1 = Lobby.CenterTextY(-(creditsText[0].GetLength(0) + creditsText[1].GetLength(0) + 3) / 2);
        private static int y2 = y1 + creditsText[0].GetLength(0) + 3;
        private static ConsoleKeyInfo key;
        public static void PrintCredits()
        {
            Lobby.SetColors(false);
            Console.Clear();

            for (int i = 0; i < creditsText[0].GetLength(0); i++)
            {
                Lobby.PrintText(creditsText[0][i], Lobby.titelColor, x1, y1 + i);
            }
            for (int i = 0; i < creditsText[1].GetLength(0); i++ )
            {
                Lobby.PrintText(creditsText[1][i], Lobby.defaultFColor, x2, y2 + i);
                Lobby.PrintText(creditsText[2][0], Lobby.defaultFColor, x2 + creditsText[1][4].Length, y2 + i);
            }

            while (true)
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                {
                    for (int i = 0; i < creditsText[1].GetLength(0); i++)
                    {
                        Lobby.PrintText(n, Lobby.defaultFColor, x2 + creditsText[1][4].Length, y2 + i);
                    }
                    Console.CursorVisible = false;
                    Thread.Sleep(1000);
                    Lobby.GoBack("HowToPlay");
                }
                else
                    continue;
            }
        }
    }
}
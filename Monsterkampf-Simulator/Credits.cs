using Monsterkampf_Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsterkampf_Simulator
{
    internal class Credits : Screen
    {
        #region Variables
        private static string n;
        private static string[][] creditsText;
        private int[] x;
        private int[] y;
        private void SetValues()
        {
            n = "Yannick           ";
            creditsText = [
            [//z0
                " ____ ____  _____ ____  _ _____ ____ ",//1
                "/   _Y  __\\/  __//  _ \\/ Y__ __Y ___\\",//2
                "|  / |  \\/||  \\  | | \\|| | / \\ |    \\",//3
                "|  \\_|    /|  /_ | |_/|| | | | \\___ |",//4
                "\\____|_/\\_\\\\____\\\\____/\\_/ \\_/ \\____/" //5
            ],[//z1
                "Ideology:",//0
                "Coding:",//1
                "Art:",//2
                "Marketing:",//3
                "Direction:    "//4
            ],[//z2
                "Thomas W. R. Cesar"//0
            ]];
            x[0] = CenterTextX(creditsText[0][0]);
            x[1] = CenterTextX(creditsText[1][4] + creditsText[2][0]);//längste string + Name
            y[0] = CenterTextY(-(creditsText[0].GetLength(0) + creditsText[1].GetLength(0) + 3) / 2);
            y[1] = y[0] + creditsText[0].GetLength(0) + 3;
        }
        #endregion

        public override Screen Start()
        {
            SetValues();
            SetColors();
            Console.Clear();

            for (int i = 0; i < creditsText[0].GetLength(0); i++)
            {
                PrintText(creditsText[0][i], titelColor, x[0], y[0] + i);
            }
            for (int i = 0; i < creditsText[1].GetLength(0); i++)
            {
                PrintText(creditsText[1][i], defaultFColor, x[1], y[1] + i);
                PrintText(creditsText[2][0], defaultFColor, x[1] + creditsText[1][4].Length, y[1] + i);
            }

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                {
                    for (int i = 0; i < creditsText[1].GetLength(0); i++)
                    {
                        PrintText(n, defaultFColor, x[1] + creditsText[1][4].Length, y[1] + i);
                    }
                    Console.CursorVisible = false;
                    Thread.Sleep(1000);
                    return new Lobby();
                }
                else
                    continue;
            }
        }

    }
}
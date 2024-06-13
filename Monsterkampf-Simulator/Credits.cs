using Monsterkampf_Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsterkampf_Simulator
{
    internal class Credits : Lobby
    {
        #region real credits
        private static string n = "Yannick           ";
        #endregion
        private static string[][] creditsText;
        private int[] x;
        private int[] y;
        private ConsoleKeyInfo key;
        public void PrintCredits()
        {
            SetValues();
            lobby.SetColors();
            Console.Clear();

            for (int i = 0; i < creditsText[0].GetLength(0); i++)
            {
                lobby.PrintText(creditsText[0][i], lobby.titelColor, x[0], y[0] + i);
            }
            for (int i = 0; i < creditsText[1].GetLength(0); i++)
            {
                lobby.PrintText(creditsText[1][i], lobby.defaultFColor, x[1], y[1] + i);
                lobby.PrintText(creditsText[2][0], lobby.defaultFColor, x[1] + creditsText[1][4].Length, y[1] + i);
            }

            while (true)
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                {
                    for (int i = 0; i < creditsText[1].GetLength(0); i++)
                    {
                        lobby.PrintText(n, lobby.defaultFColor, x[1] + creditsText[1][4].Length, y[1] + i);
                    }
                    Console.CursorVisible = false;
                    Thread.Sleep(1000);
                    lobby.Return("Lobby");
                }
                else
                    continue;
            }
        }

        private void SetValues()
        {
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
            x[0] = lobby.CenterTextX(creditsText[0][0]);
            x[1] = lobby.CenterTextX(creditsText[1][4] + creditsText[2][0]);//längste string + Name
            y[0] = lobby.CenterTextY(-(creditsText[0].GetLength(0) + creditsText[1].GetLength(0) + 3) / 2);
            y[1] = y[0] + creditsText[0].GetLength(0) + 3;
        }
    }
}
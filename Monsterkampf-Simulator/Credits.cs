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
        private string n = "Yannick";
        #endregion
        private static string[] creditsText = { "Thomas W. R. Cesar",
            " ____ ____  _____ ____  _ _____ ____ ",//1
            "/   _Y  __\\/  __//  _ \\/ Y__ __Y ___\\",//2
            "|  / |  \\/||  \\  | | \\|| | / \\ |    \\",//3
            "|  \\_|    /|  /_ | |_/|| | | | \\___ |",//4
            "\\____|_/\\_\\\\____\\\\____/\\_/ \\_/ \\____/",//5
            "Ideology: ",//6
            "Coding: ",//7
            "Art: ",//8
            "Marketing: ",//9
            "Direction: "};//10
        public static void PrintCredits()
        {
            Lobby.SetColors(false);
            Console.Clear();

            for (int i = 0; i < creditsText.Length; i++)
            {

            }
        }
    }
}

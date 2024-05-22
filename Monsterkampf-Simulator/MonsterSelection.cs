using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsterkampf_Simulator
{
    internal class MonsterSelection
    {
        private static string[] selectionSettings = { "Player 1:", 
        "Choose your Monster by pressing the respective monster class number in your keyboard.",
        "(1)          (2)          (3)"};

        public static void PrintMonsterSelection() 
        {
            Lobby.SetColorsToDefault();
            Console.Clear();

            Lobby.PrintText(selectionSettings[0], Lobby.defaultFColor, Lobby.CenterText(selectionSettings[0]), 3);
            Lobby.PrintText(selectionSettings[1], Lobby.defaultFColor, Lobby.CenterText(selectionSettings[1]), 4);

            Console.ReadKey(false);

            Monster Orc = new Monster(1, 200, 20, 5, 3);
            Monster Troll = new Monster(2, 150, 15, 10, 5);
            Monster Goblin = new Monster(3, 100, 20, 0, 10);
        }
    }
}.

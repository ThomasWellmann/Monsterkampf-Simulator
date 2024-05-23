using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsterkampf_Simulator
{
    internal class MonsterSelection
    {
        public static int[] orc = { 1, 200, 20, 5, 3 };
        public static int[] troll = { 2, 175, 15, 10, 5 };
        public static int[] goblin = { 3, 150, 20, 0, 10 };
        public static int currentPlayer = 1;
        public static int player1Monster;
        public static int player2Monster;
        private static readonly string[] selectionSettings = { $"Player {currentPlayer}:",
        $"Choose your Monster by pressing the respective monster class number in your keyboard.",
        $"(1): Orc     (2): Troll   (3): Goblin    ",
        $"  HP: {orc[1]}      HP: {troll[1]}      HP: {goblin[1]}  ",
        $"  AP: {orc[2]}       AP: {troll[2]}       AP: {goblin[2]}   ",
        $"  DP: {orc[3]}        DP: {troll[3]}       DP: {goblin[3]}    ",
        $"  SP: {orc[4]}        SP: {troll[4]}        SP: {goblin[4]}   "};

        public static void PrintMonsterSelection()
        {
            Lobby.SetColorsToDefault();
            Console.Clear();

            PrintSelectionText();

            GetPlayerInput();
            currentPlayer++;

            PrintSelectionText();

            GetPlayerInput();
        }

        private static void PrintSelectionText()
        {
            int offSet = -8;

            for (int i = 0; i < 3; i++)
            {
                Lobby.PrintText(selectionSettings[i], Lobby.defaultFColor, Lobby.CenterTextX(selectionSettings[i]), Lobby.CenterTextY(offSet));
                offSet += 2;
            }
            Monster.DrawOrc(Lobby.CenterTextX(selectionSettings[2]) + 4, Lobby.CenterTextY(offSet));
            Monster.DrawTroll(Lobby.CenterTextX(selectionSettings[2]) + 17, Lobby.CenterTextY(offSet));
            Monster.DrawGoblin(Lobby.CenterTextX(selectionSettings[2]) + 30, Lobby.CenterTextY(offSet));
            offSet = 3;
            for (int i = 3; i < 7; i++)
            {
                Lobby.PrintText(selectionSettings[i], Lobby.defaultFColor, Lobby.CenterTextX(selectionSettings[i]), Lobby.CenterTextY(offSet));
                offSet++;
            }
        }

        private static void GetPlayerInput()
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.D1)
                {
                    Monster Orc = new Monster(orc[0], orc[1], orc[2], orc[3], orc[4]);
                    if (currentPlayer == 1)
                        player1Monster = orc[0];
                    else if (currentPlayer == 2 && player1Monster != orc[0])
                        player2Monster = orc[0];
                    break;
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    Monster Troll = new Monster(troll[0], troll[1], troll[2], troll[3], troll[4]);
                    if (currentPlayer == 1)
                        player1Monster = troll[0];
                    else if (currentPlayer == 2 && player1Monster != troll[0])
                        player2Monster = troll[0];
                    break;
                }
                else if (key.Key == ConsoleKey.D3)
                {
                    Monster Goblin = new Monster(goblin[0], goblin[1], goblin[2], goblin[3], goblin[4]);
                    if (currentPlayer == 1)
                        player1Monster = goblin[0];
                    else if (currentPlayer == 2 && player1Monster != goblin[0])
                        player2Monster = goblin[0];
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}

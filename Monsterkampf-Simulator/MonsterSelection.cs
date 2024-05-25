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
        public static int player1Monster = 0;
        public static int player2Monster = 0;
        public static ConsoleColor player1Color = ConsoleColor.Blue;
        public static ConsoleColor player2Color = ConsoleColor.Red;
        private static readonly string[] selectionSettings = {$"Player {currentPlayer}:",//0
        $"Choose your Monster by pressing the respective monster class number in your keyboard.",//1
        "You can not choose the same moster for both players",//2
        $"(1): Orc       (2): Troll     (3): Goblin    ",//3
        $"HP: {orc[1]}        HP: {troll[1]}        HP: {goblin[1]}    ",//4
        $"AP: {orc[2]}         AP: {troll[2]}         AP: {goblin[2]}     ",//5
        $"DP: {orc[3]}          DP: {troll[3]}         DP: {goblin[3]}      ",//6
        $"SP: {orc[4]}          SP: {troll[4]}          SP: {goblin[4]}     " };//7
        private static string[] chosenMonsterDisplay = {"Player 1:     ", "     Player 2:", //0/1
        " _    _______",//2
        "| |  / / ___/",//3
        "| | / /\\__ \\ ",//4
        "| |/ /___/ / ",//5
        "|___//____/  ",//6
        //
        " ___ ",//7
        "(_, )",//8
        "  // ",//9
        " (_) ",//10
        "  _  ",//11
        " (_) "};//12
        private static int x1 = Lobby.CenterTextX(chosenMonsterDisplay[0] + chosenMonsterDisplay[1] + chosenMonsterDisplay[2]) + 2;
        private static int x2 = Lobby.CenterTextX(chosenMonsterDisplay[0] + chosenMonsterDisplay[1] + chosenMonsterDisplay[2]) + 2 + chosenMonsterDisplay[0].Length + chosenMonsterDisplay[1].Length;
        private static int offSet;

        public static void PrintMonsterSelection()
        {
            Lobby.SetColorsToDefault();
            Console.Clear();

            Lobby.DrawMiddleLine();

            PlayerMonsterSelection();

            //ChangeMonsterStats();
        }

        private static void PlayerMonsterSelection()
        {
            PrintSelectionText();

            GetPlayerInput();
            currentPlayer++;

            PrintSelectionText();

            GetPlayerInput();
        }

        private static void PrintSelectionText()
        {
            offSet = -3;

            for (int i = 0; i < 4; i++)
            {
                Lobby.PrintText(selectionSettings[i], Lobby.defaultFColor, Lobby.CenterTextX(selectionSettings[i]), Lobby.CenterTextY(offSet));
                offSet += 2;
            }
            Monster.DrawMonster(Lobby.CenterTextX(selectionSettings[2]) + 6, Lobby.CenterTextY(offSet));
            Monster.DrawTroll(Lobby.CenterTextX(selectionSettings[2]) + 21, Lobby.CenterTextY(offSet));
            Monster.DrawGoblin(Lobby.CenterTextX(selectionSettings[2]) + 36, Lobby.CenterTextY(offSet));

            offSet = 10;
            for (int i = 4; i < 8; i++)
            {
                Lobby.PrintText(selectionSettings[i], Lobby.defaultFColor, Lobby.CenterTextX(selectionSettings[i]), Lobby.CenterTextY(offSet));
                offSet++;
            }

            offSet = -11;
            DisplayPlayer1(x1, Lobby.CenterTextY(offSet));
            DisplayPlayer2(x2, Lobby.CenterTextY(offSet));
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
                    {
                        player1Monster = orc[0];
                    }
                    else if (currentPlayer == 2 && player1Monster != orc[0])
                    {
                        player2Monster = orc[0];
                    }
                    break;
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    Monster Troll = new Monster(troll[0], troll[1], troll[2], troll[3], troll[4]);
                    if (currentPlayer == 1)
                    {
                        player1Monster = troll[0];
                    }
                    else if (currentPlayer == 2 && player1Monster != troll[0])
                    {
                        player2Monster = troll[0];
                    }
                    break;
                }
                else if (key.Key == ConsoleKey.D3)
                {
                    Monster Goblin = new Monster(goblin[0], goblin[1], goblin[2], goblin[3], goblin[4]);
                    if (currentPlayer == 1)
                    {
                        player1Monster = goblin[0];
                    }
                    else if (currentPlayer == 2 && player1Monster != goblin[0])
                    {
                        player2Monster = goblin[0];
                    }
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        public static void DisplayPlayer1(int _x, int _y)
        {
            if (player1Monster == orc[0])
                Monster.DrawMonster(_x, _y);
            else if (player1Monster == troll[0])
                Monster.DrawTroll(_x, _y);
            else if (player1Monster == goblin[1])
                Monster.DrawGoblin(_x, _y);
            else if (player1Monster == 0)
            {
                Lobby.PrintText(chosenMonsterDisplay[0], player1Color, x1, _y);
                _y++;
                for (int i = 7; i < 13; i++)
                {
                    Lobby.PrintText(chosenMonsterDisplay[i], player1Color, x1 + 2, _y);
                    _y++;
                }
            }
        }

        public static void DisplayPlayer2(int _x, int _y)
        {
            if (player2Monster == orc[0])
                Monster.DrawMonster(_x, _y);
            else if (player2Monster == troll[0])
                Monster.DrawTroll(_x, _y);
            else if (player2Monster == goblin[1])
                Monster.DrawGoblin(_x, _y);
            else if (player2Monster == 0)
            {
                Lobby.PrintText(chosenMonsterDisplay[1], player2Color, x2, _y);
                _y++;
                for (int i = 7; i < 13; i++)
                {
                    Lobby.PrintText(chosenMonsterDisplay[i], player2Color, x2 + 2, _y);
                    _y++;
                }
            }
        }

        public static string[] GetMonsterStats(int _monsterType)
        {
            if (_monsterType == 1)
            {
                string[] orcStats = { $"HP: {orc[1]}", $"AP: {orc[2]}", $"DP: {orc[3]}", $"SP: {orc[4]}" };
                return orcStats;
            }
            else if (_monsterType == 2)
            {
                string[] trollStats = { $"HP: {troll[1]}", $"AP: {troll[2]}", $"DP: {troll[3]}", $"SP: {troll[4]}" };
                return trollStats;
            }
            else if (_monsterType == 3)
            {
                string[] goblingStats = { $"HP: {goblin[1]}", $"AP: {goblin[2]}", $"DP: {goblin[3]}", $"SP: {goblin[4]}" };
                return goblingStats;
            }
            else
            {
                string[] strings = { "", "", "", "" };
                return strings;
            }
        }
    }
}

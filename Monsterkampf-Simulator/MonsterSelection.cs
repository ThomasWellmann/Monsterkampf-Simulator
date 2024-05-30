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
        public static int[] monsterPlayer = { 0, 0, 0 };
        public static ConsoleColor[] colorPlayer = { Lobby.defaultBColor, ConsoleColor.Blue, ConsoleColor.Red };
        private static string[] selectionSettings = {"",//0
        $"Choose your Monster by pressing the respective monster class number in your keyboard.",//1
        "You can not choose the same moster for both players",//2
        $"(1): Orc       (2): Troll     (3): Goblin",//3
        $"HP: {orc[1]}        HP: {troll[1]}        HP: {goblin[1]}",//4
        $"AP: {orc[2]}         AP: {troll[2]}         AP: {goblin[2]}",//5
        $"DP: {orc[3]}          DP: {troll[3]}         DP: {goblin[3]} ",//6
        $"AS: {orc[4]}          AS: {troll[4]}          AS: {goblin[4]}" };//7
        private static string[] chosenMonsterDisplay = {"Player 1:", "Player 2:", //0/1
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
        private static int x1 = Lobby.CenterTextX(chosenMonsterDisplay[0] + chosenMonsterDisplay[1] + chosenMonsterDisplay[2] + "    ");
        private static int x2 = x1 + chosenMonsterDisplay[0].Length + chosenMonsterDisplay[1].Length + 8;
        private static int offSet;

        public static void PrintMonsterSelection()
        {
            Lobby.windowSize[0] = Console.LargestWindowWidth / 2;
            Lobby.windowSize[1] = Console.LargestWindowHeight;
            Lobby.ResizeWindow();

            Lobby.SetColorsToDefault();
            Console.Clear();

            //Lobby.DrawMiddleLine();

            PlayerMonsterSelection();

            //ChangeMonsterStats();
            Loop();
        }

        private static void PlayerMonsterSelection()
        {
            PrintSelectionText();

            SelectMonster();
            currentPlayer++;

            PrintSelectionText();

            SelectMonster();

            PrintSelectionText();
        }

        private static void Loop()
        {
            while (true)
            {
                Console.ReadKey();
            }
        }

        private static void PrintSelectionText()
        {
            offSet = -1;

            Lobby.PrintText($"Player {currentPlayer}:", Lobby.defaultFColor, Lobby.CenterTextX($"Player {currentPlayer}:"), Lobby.CenterTextY(offSet - 2));
            for (int i = 1; i < 4; i++)
            {
                Lobby.PrintText(selectionSettings[i], Lobby.defaultFColor, Lobby.CenterTextX(selectionSettings[i]), Lobby.CenterTextY(offSet));
                offSet += 2;
            }
            for (int i = 0; i < 3; i++)
                Monster.DrawMonster(i + 1, Lobby.CenterTextX(selectionSettings[3]) + 3 + i * 15, Lobby.CenterTextY(offSet));


            offSet = 10;
            for (int i = 4; i < 8; i++)
            {
                Lobby.PrintText(selectionSettings[i], Lobby.defaultFColor, Lobby.CenterTextX(selectionSettings[i]), Lobby.CenterTextY(offSet));
                offSet++;
            }

            offSet = -11;
            DisplayPlayer(1, x1, Lobby.CenterTextY(offSet));
            DisplayPlayer(2, x2, Lobby.CenterTextY(offSet));
            for (int i = 2; i < 7; i++)
            {
                offSet++;
                Lobby.PrintText(chosenMonsterDisplay[i], Lobby.defaultFColor, Lobby.CenterTextX(chosenMonsterDisplay[i]), Lobby.CenterTextY(offSet));
            }
        }

        private static void SelectMonster()
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.D1)
                {
                    Monster Orc = new Monster(orc[0], orc[1], orc[2], orc[3], orc[4]);
                    if (currentPlayer == 1)
                    {
                        monsterPlayer[1] = orc[0];
                    }
                    else if (currentPlayer == 2 && monsterPlayer[1] != orc[0])
                    {
                        monsterPlayer[2] = orc[0];
                    }
                    break;
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    Monster Troll = new Monster(troll[0], troll[1], troll[2], troll[3], troll[4]);
                    if (currentPlayer == 1)
                    {
                        monsterPlayer[1] = troll[0];
                    }
                    else if (currentPlayer == 2 && monsterPlayer[1] != troll[0])
                    {
                        monsterPlayer[2] = troll[0];
                    }
                    break;
                }
                else if (key.Key == ConsoleKey.D3)
                {
                    Monster Goblin = new Monster(goblin[0], goblin[1], goblin[2], goblin[3], goblin[4]);
                    if (currentPlayer == 1)
                    {
                        monsterPlayer[1] = goblin[0];
                    }
                    else if (currentPlayer == 2 && monsterPlayer[1] != goblin[0])
                    {
                        monsterPlayer[2] = goblin[0];
                    }
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        public static void DisplayPlayer(int _player, int _x, int _y)
        {
            Lobby.PrintText(chosenMonsterDisplay[_player - 1], colorPlayer[_player], _x, _y);
            _y++;
            if (monsterPlayer[_player] == 0)
            {
                for (int i = 0; i < 6; i++)
                {
                    Lobby.PrintText(chosenMonsterDisplay[i + 7], colorPlayer[_player], _x + 2, _y + i);
                }
            }
            else
            {
                for (int i = 0; i < 6; i++)
                {
                    Lobby.PrintText(chosenMonsterDisplay[i + 7], Lobby.defaultBColor, _x + 2, _y + i);
                }
                _x++;
                _y++;
                if (monsterPlayer[_player] == orc[0])
                {
                    Monster.DrawMonster(orc[0], _x, _y);
                }
                else if (monsterPlayer[_player] == troll[0])
                {
                    Monster.DrawMonster(troll[0], _x, _y);
                }
                else if (monsterPlayer[_player] == goblin[1])
                {
                    Monster.DrawMonster(goblin[1], _x, _y);
                }
            }
        }

        public static string[] GetMonsterStats(int _monsterType)
        {
            if (_monsterType == 1)
            {
                string[] orcStats = { $"HP: {orc[1]}", $"AP: {orc[2]}", $"DP: {orc[3]}", $"AS: {orc[4]}" };
                return orcStats;
            }
            else if (_monsterType == 2)
            {
                string[] trollStats = { $"HP: {troll[1]}", $"AP: {troll[2]}", $"DP: {troll[3]}", $"AS: {troll[4]}" };
                return trollStats;
            }
            else if (_monsterType == 3)
            {
                string[] goblingStats = { $"HP: {goblin[1]}", $"AP: {goblin[2]}", $"DP: {goblin[3]}", $"AS: {goblin[4]}" };
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

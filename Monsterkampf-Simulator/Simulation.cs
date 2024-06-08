using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsterkampf_Simulator
{
    internal class Simulation
    {
        public static Monster[] monsterPlayer = { MonsterSettings.Orc, MonsterSettings.Troll, MonsterSettings.Goblin};
        private static int currentPlayer;
        private static int otherPlayer;
        private static int roundCount = 1;
        private static int cheater = 0;
        private static int saint = 0;
        private static bool draw = false;
        private static int x = Lobby.CenterTextX("") - 20;
        private static int y = Lobby.CenterTextY(0);
        private static ConsoleKeyInfo key;
        private static ConsoleColor winnerColor = ConsoleColor.Green;
        public static void PrintSimulation()
        {
            Lobby.SetColors(false);
            Console.Clear();

            GetStarted();
            CheckIfCheating();

            Console.CursorVisible = false;
            BattleLoop();
            PrintWinner();

            while (true)
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                    Lobby.GoBack("Simulation");
                else
                    continue;
            }
        }

        private static void GetStarted()
        {
            cheater = 0;
            saint = 0;
            draw = false;
            MonsterSettings.DisplayVS(false);
            currentPlayer = GetStarter();
            string[] starterText = { $"{monsterPlayer[GetStarter()].name} has more AS, meaning it will start attacking!", "3...", "2...", "1...", "Fight!" };
            for (int i = 0; i < starterText.GetLength(0); i++)
            {
                Lobby.PrintText(starterText[i], Lobby.defaultFColor, Lobby.CenterTextX(starterText[i]), y + i);
                Thread.Sleep(1000);
            }
            y += 6;
        }

        private static void BattleLoop()
        {
            while (true)
            {
                if (roundCount == 21)
                {
                    draw = true;
                    break;
                }

                string[] attackLog = Monster.Attack(monsterPlayer[currentPlayer], monsterPlayer[otherPlayer]);
                Lobby.PrintText($"Round {roundCount}:", MonsterSettings.colorPlayer[currentPlayer], x, y);
                Lobby.PrintText($"{monsterPlayer[currentPlayer].name} has {attackLog[2]}attacked {monsterPlayer[otherPlayer].name}.", Lobby.defaultFColor, x, y + 1);
                Lobby.PrintText($"{attackLog[0]} damage was done and {monsterPlayer[otherPlayer].name} has now {attackLog[1]} HP.", Lobby.defaultFColor, x, y + 2);

                if (currentPlayer != GetStarter())
                {
                    roundCount++;
                }

                for (int i = 0; i < 5; i++)
                {
                    y++;
                    Console.WriteLine();
                    Thread.Sleep(100);
                }

                if (attackLog[1] == "0")
                {
                    break;
                }
                    
                ChangePlayers();
            }
        }

        private static void CheckIfCheating()
        {
            string cheaterText = $"{monsterPlayer[cheater].name} cheated when choosing a grater DP than it's opponent AP. {monsterPlayer[saint].name} has won!";
            if (monsterPlayer[1].DP > monsterPlayer[2].AP)
            {
                cheater = 1;
                saint = 2;
            }
            else if (monsterPlayer[2].DP > monsterPlayer[1].AP)
            {
                cheater = 2;
                saint = 1;
            }
            if (cheater != 0)
            {
                Lobby.PrintText(cheaterText, Lobby.titelColor, Lobby.CenterTextX(cheaterText), Lobby.CenterTextY(1));
                Thread.Sleep(3000);
                Lobby.GoBack("Simulation");
            }
        }

        private static void PrintWinner()
        {
            string[] endGameText = { $"{monsterPlayer[currentPlayer].name} has won the battle and is walking home victorious!",
            $"The round cout is over and still, no one hit the ground yet. It's a draw!",
            $"Since the battle is over, there is nothing more here be seen.",
            $"You shall press \"ESC\" to return to the main menu."};
            Thread.Sleep(500);
            if (!draw)
            {
                Lobby.PrintText(endGameText[0], winnerColor, Lobby.CenterTextX(endGameText[0]), y);
            } 
            else
            {
                Lobby.PrintText(endGameText[1], Lobby.defaultFColor, Lobby.CenterTextX(endGameText[1]), y);
            }
            for (int i = 2; i < 4; i++)
            {
                y++;
                Thread.Sleep(500);
                Lobby.PrintText(endGameText[i], Lobby.defaultFColor, Lobby.CenterTextX(endGameText[i]), y);
            }
            for (int i = 0; i < Lobby.windowSize[1] / 2; i++)
            {
                Console.WriteLine();
                Thread.Sleep(50);
            }
        }

        private static int GetStarter()
        {
            if (monsterPlayer[1].AS > monsterPlayer[2].AS)
            {
                otherPlayer = 2;
                return 1;
            }
            else
            {
                otherPlayer = 1;
                return 2;
            }
        }

        private static void ChangePlayers()
        {
            if (currentPlayer == 1)
            {
                currentPlayer = 2;
                otherPlayer = 1;
            }
            else if (currentPlayer == 2)
            {
                currentPlayer = 1;
                otherPlayer = 2;
            }
        }
    }
}

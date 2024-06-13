using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsterkampf_Simulator
{
    internal class Simulation : Lobby
    {
        #region Variables
        public Monster[] monsterPlayer;
        private int currentPlayer;
        private int otherPlayer;
        private int roundCount = 1;
        private int cheater = 0;
        private int saint = 0;
        private bool draw = false;
        private int x;
        private int y;
        private ConsoleKeyInfo key;
        private ConsoleColor winnerColor = ConsoleColor.Green;
        private Random rnd = new Random();
        private bool sameAS;
        #endregion
        public void PrintSimulation()
        {
            monsterPlayer = [lobby.Orc, lobby.Orc, lobby.Orc];
            x = lobby.CenterTextX("") - 20;
            y = lobby.CenterTextY(0);
            lobby.SetColors(false);
            Console.Clear();

            StartSim();
            CheckIfCheating();

            Console.CursorVisible = false;
            BattleLoop();
            PrintWinner();

            while (true)
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                    lobby.Return("Simulation");
                else
                    continue;
            }
        }

        private void StartSim()
        {
            SetValues();
            monsterSettings.DisplayVS(false);
            string[] starterText = { $"Both monsters have the same AS, meaning {monsterPlayer[GetStarter()].name}, which was chosen randomly, will start attacking!",
                $"{monsterPlayer[GetStarter()].name} has more AS, meaning it will start attacking!",
                "3...", "2...", "1...", "Fight!"};

            lobby.PrintText(starterText[(sameAS) ? 0 : 1], lobby.defaultFColor, lobby.CenterTextX(starterText[(sameAS) ? 0 : 1]), y);
            Thread.Sleep(1000);
            y++;
            for (int i = 2; i < starterText.GetLength(0); i++)
            {
                Thread.Sleep(1000);
                lobby.PrintText(starterText[i], lobby.defaultFColor, lobby.CenterTextX(starterText[i]), y + i - 2);
            }
            y += 5;
        }

        private void SetValues()
        {
            currentPlayer = GetStarter();
            cheater = 0;
            saint = 0;
            sameAS = false;
            draw = false;
        }

        private void BattleLoop()
        {
            while (true)
            {
                if (roundCount == 21)
                {
                    draw = true;
                    break;
                }

                int[] attackLog = monsterPlayer[currentPlayer].Attack(monsterPlayer[otherPlayer]);
                string[] battleLoopText = { $"Round {roundCount}:", 
                    $"{monsterPlayer[currentPlayer].name} has {((attackLog[2] == 0) ? "" : "criticaly " )}attacked {monsterPlayer[otherPlayer].name}.",
                    $"{attackLog[0]} damage was done and {monsterPlayer[otherPlayer].name} has now {attackLog[1]} HP."};
                for (int i = 0; i < 3; i++)
                {
                    lobby.PrintText(battleLoopText[i], (i == 0) ? monsterSettings.colorPlayer[currentPlayer] : lobby.defaultFColor, x, y + i);
                }

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

                if (attackLog[1] == 0)
                {
                    break;
                }
                    
                ChangePlayers();
            }
        }

        private void CheckIfCheating()
        {
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
            string cheaterText = $"{monsterPlayer[cheater].name} cheated when choosing a grater DP than it's opponent AP. {monsterPlayer[saint].name} has won!";
            if (cheater != 0)
            {
                Console.Clear();
                lobby.PrintText(cheaterText, lobby.titelColor, lobby.CenterTextX(cheaterText), lobby.CenterTextY(1));
                Thread.Sleep(3000);
                lobby.Return("Simulation");
            }
        }

        private void PrintWinner()
        {
            string[] endGameText = { $"{monsterPlayer[currentPlayer].name} has won the battle and is walking home victorious!",
            $"The round cout is over and still, no one hit the ground yet. It's a draw!",
            $"Since the battle is over, there is nothing more here be seen.",
            $"You shall press \"ESC\" to return to the main menu."};
            Thread.Sleep(500);
            if (!draw)
            {
                lobby.PrintText(endGameText[0], winnerColor, lobby.CenterTextX(endGameText[0]), y);
            } 
            else
            {
                lobby.PrintText(endGameText[1], lobby.defaultFColor, lobby.CenterTextX(endGameText[1]), y);
            }
            for (int i = 2; i < 4; i++)
            {
                y++;
                Thread.Sleep(500);
                lobby.PrintText(endGameText[i], lobby.defaultFColor, lobby.CenterTextX(endGameText[i]), y);
            }
            for (int i = 0; i < lobby.windowSize[1] / 2; i++)
            {
                Console.WriteLine();
                Thread.Sleep(50);
            }
        }

        private int GetStarter()
        {
            if (monsterPlayer[1].AS > monsterPlayer[2].AS)
            {
                otherPlayer = 2;
                return 1;
            }
            else if (monsterPlayer[2].AS > monsterPlayer[1].AS)
            {
                otherPlayer = 1;
                return 2;
            }
            else
            {
                int rndStarter = rnd.Next(1, 3);
                otherPlayer = (rndStarter == 1) ? 2 : 1;
                sameAS = true;
                return rndStarter;
            }
        }

        private void ChangePlayers()
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

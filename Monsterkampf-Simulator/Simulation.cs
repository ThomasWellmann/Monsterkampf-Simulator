using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsterkampf_Simulator
{
    internal class Simulation : Screen
    {
        #region Variables
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
        private bool sameAS;
        private Monster[] chosenMonsters;

        public Random rnd = new Random(DateTime.Now.Millisecond);
        private void SetValues()
        {
            currentPlayer = GetStarter();
            cheater = 0;
            saint = 0;
            sameAS = false;
            draw = false;
        }
        #endregion
        public Simulation(Monster[] _chosenMonsters)
        {
            chosenMonsters = _chosenMonsters; 
        }
        public override Screen Start()
        {
            x = CenterTextX("") - 20;
            y = CenterTextY(0);
            SetColors(false);
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
                    return new Lobby();
                else
                    continue;
            }
        }

        private void StartSim()
        {
            SetValues();
            MonsterSettings.DisplayVS(false);
            string[] starterText = { $"Both Monsters have the same AS, meaning {chosenMonsters[GetStarter()].name}, which was chosen randomly, will start attacking!",
                $"{chosenMonsters[GetStarter()].name} has more AS, meaning it will start attacking!",
                "3...", "2...", "1...", "Fight!"};

            PrintText(starterText[(sameAS) ? 0 : 1], defaultFColor, CenterTextX(starterText[(sameAS) ? 0 : 1]), y);
            Thread.Sleep(1000);
            y++;
            for (int i = 2; i < starterText.GetLength(0); i++)
            {
                Thread.Sleep(1000);
                PrintText(starterText[i], defaultFColor, CenterTextX(starterText[i]), y + i - 2);
            }
            y += 5;
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

                int[] attackLog = chosenMonsters[currentPlayer].Attack(chosenMonsters[otherPlayer]);
                string[] battleLoopText = { $"Round {roundCount}:", 
                    $"{chosenMonsters[currentPlayer].name} has {((attackLog[2] == 0) ? "" : "criticaly " )}attacked {chosenMonsters[otherPlayer].name}.",
                    $"{attackLog[0]} damage was done and {chosenMonsters[otherPlayer].name} has now {attackLog[1]} HP."};
                for (int i = 0; i < 3; i++)
                {
                    PrintText(battleLoopText[i], (i == 0) ? colorPlayer[currentPlayer] : defaultFColor, x, y + i);
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

        private Screen CheckIfCheating()
        {
            if (chosenMonsters[1].DP > chosenMonsters[2].AP)
            {
                cheater = 1;
                saint = 2;
            }
            else if (chosenMonsters[2].DP > chosenMonsters[1].AP)
            {
                cheater = 2;
                saint = 1;
            }
            string cheaterText = $"{chosenMonsters[cheater].name} cheated when choosing a grater DP than it's opponent AP. {chosenMonsters[saint].name} has won!";
            if (cheater != 0)
            {
                Console.Clear();
                PrintText(cheaterText, titelColor, CenterTextX(cheaterText), CenterTextY(1));
                Thread.Sleep(3000);
                return new Lobby();
            }
            return null;
        }

        private void PrintWinner()
        {
            string[] endGameText = { $"{chosenMonsters[currentPlayer].name} has won the battle and is walking home victorious!",
            $"The round cout is over and still, no one hit the ground yet. It's a draw!",
            $"Since the battle is over, there is nothing more here be seen.",
            $"You shall press \"ESC\" to return to the main menu."};
            Thread.Sleep(500);
            if (!draw)
            {
                PrintText(endGameText[0], winnerColor, CenterTextX(endGameText[0]), y);
            } 
            else
            {
                PrintText(endGameText[1], defaultFColor, CenterTextX(endGameText[1]), y);
            }
            for (int i = 2; i < 4; i++)
            {
                y++;
                Thread.Sleep(500);
                PrintText(endGameText[i], defaultFColor, CenterTextX(endGameText[i]), y);
            }
            for (int i = 0; i < windowSize[1] / 2; i++)
            {
                Console.WriteLine();
                Thread.Sleep(50);
            }
        }

        private int GetStarter()
        {
            if (chosenMonsters[1].AS > chosenMonsters[2].AS)
            {
                otherPlayer = 2;
                return 1;
            }
            else if (chosenMonsters[2].AS > chosenMonsters[1].AS)
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

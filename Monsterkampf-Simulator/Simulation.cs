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
        private static string[] starterText = { $"{monsterPlayer[GetStarter()]} has more AS, meaning it will start attacking!", "3...", "2...", "1...", "Fight!" };
        private static int x = Lobby.CenterTextX("") - 20;
        private static int y = Lobby.CenterTextY(0);
        public static void PrintSimulation()
        {
            Lobby.SetColors(false);
            Console.Clear();

            MonsterSettings.DisplayVS(false);
            currentPlayer = GetStarter();
            for (int i = 0; i < starterText.GetLength(0); i++)
            {
                Lobby.PrintText(starterText[i], Lobby.defaultFColor, Lobby.CenterTextX(starterText[i]), y + i);
                Thread.Sleep(1000);
            }
            y += 6;
            while (true)
            {
                string[] attackLog = Monster.Attack(monsterPlayer[currentPlayer], monsterPlayer[otherPlayer]);
                Lobby.PrintText($"Round {roundCount}:", MonsterSettings.colorPlayer[currentPlayer], x, y);
                Lobby.PrintText($"{monsterPlayer[currentPlayer].name} has {attackLog[2]}attacked {monsterPlayer[otherPlayer].name}.", Lobby.defaultFColor, x, y + 1);
                Lobby.PrintText($"{attackLog[0]} damage was done and {monsterPlayer[otherPlayer].name} has now {attackLog[1]} HP.", Lobby.defaultFColor, x, y + 2);
                if (currentPlayer != GetStarter())
                    roundCount++;
                if (monsterPlayer[otherPlayer].HP <= 0 || roundCount >= 20)
                    break;
                y += 4;
                ChangePlayers();
                Thread.Sleep(500);
            }

            PrintWinner();
        }

        private static void PrintWinner()
        {
            if (monsterPlayer[otherPlayer].HP <= 0)
            {

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
                return 1;
            }
        }

        private static void ChangePlayers()
        {
            if (currentPlayer == 1)
            {
                currentPlayer = 2;
                otherPlayer = 1;
            }
            else
            {
                currentPlayer = 1;
                otherPlayer = 2;
            }
        }
    }
}

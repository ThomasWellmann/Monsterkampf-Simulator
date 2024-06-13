using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsterkampf_Simulator
{
    internal class HowToPlay : Lobby
    {
        #region Variables
        private string[][] howToPlayText;
        private int[] x;
        private int[] y;
        private int y2;
        private int y3;
        private int y4;
        private ConsoleKeyInfo key;
        #endregion

        private int offSet = 0;
        public void PrintHowToPlay()
        {
            SetValues();
            lobby.SetColors();
            Console.Clear();

            for (int i = 0; i < howToPlayText[0].GetLength(0); i++)
            {
                lobby.PrintText(howToPlayText[0][i], lobby.titelColor, lobby.CenterTextX(howToPlayText[0][0]), y[0] + i);
            }
            for (int i = 1; i < 5; i++)
            {
                int _x = 0;
                int _y = 0;
                if (i == 1) { _x = x[0]; _y = y2; }
                else if (i == 2) { _x = x[0]; _y = y3; }
                else if (i == 3) { _x = x[1]; _y = y2; }
                else if (i == 4) { _x = x[1]; _y = y3; }
                offSet = 0;
                for (int j = 0; j < howToPlayText[i].GetLength(0); j++)
                {
                    lobby.PrintText(howToPlayText[i][j], lobby.defaultFColor, _x, _y + offSet);
                    offSet += 2;
                }
            }
            lobby.PrintText(howToPlayText[5][0], lobby.defaultFColor, lobby.CenterTextX(howToPlayText[5][0]), y4);

            while (true)
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                    lobby.Return("Lobby");
                else
                    continue;
            }
        }

        private void SetValues()
        {
            howToPlayText = [
            [//z0
                " _______                   _______          ______ __              ",//0
                "|   |   |.-----.--.--.--. |_     _|.-----. |   __ \\  |.---.-.--.--.",//1
                "|       ||  _  |  |  |  |   |   |  |  _  | |    __/  ||  _  |  |  |",//2
                "|___|___||_____|________|   |___|  |_____| |___|  |__||___._|___  |",//3
                "                                                            |_____|",//4
            ],[//z1 links oben
                "Choose your Monster:",//0
                "▄ Press \"1\", \"2\" or \"3\" in your keyboard to select your Monster.",//1
                "▄ You can'i play as the same monster as your opponent.",//2
                "▄ You will be able to personalyze your Monster's values once you select one."//3
            ],[//z2 links unten
                "Changing it's values:",//0
                "▄ Press \"Enter\" to enter the value configuration or \"SpaceBar\" to start the simulation.",//1
                "▄ Once setting new values, press \"Enter\" to jump to the next one.",//2
                "▄ Press \"ESC\" to exit the configuration and save your changes.",//3
                "▄ Getting through all the values also saves the new ones.",//4
                "▄ Lowest possible value is \"1\", and the highest is \"999\".",//5
                "▄ We advise not to choose a DP grater than the enemy's AP. This is cheating!"//6
            ],[//z3 rechts oben
                "The Monsters:" ,//0
                "▄ Orc: Most health and damage, but low defense and attacks very slowly.",//1
                "▄ Troll: Middle ground with solid stats, but no critical chance.",//2
                "▄ Goblin: High critical chanse and damage over all, but very squishy.",//3
                "▄ On critical hit you do twice your damage. You can't change a Monster's critical chance.",//4
                "▄ New Monsters coming soon!"//5
            ],[//z4 rechts ulten
                "The simulation",//0
                "▄ The Monster with the most AS will attack first, but if they have the same, it will be random.",//1
                "▄ Once you press start, there is no coming back until one get's defeated (or 20 rounds has passed).",//2
                "▄ There is a detailed log of the fight as it happens.",//3
                "▄ The winner will be congratulated at the end of the fight.",//4
                "▄ If a cheater is found, he will lose the fight instantly."//5
            ],[//z5 Hinweis unten
                "You can press \"ESC\" at any time to get to the previous page.",//0
            ]];
            x[0] = lobby.CenterTextX("") - howToPlayText[2][1].Length - 3; //[2][1] ist der längste Text links
            x[1] = lobby.CenterTextX("") + 3;
            y[0] = lobby.CenterTextY(-(35 / 2));//y-Wert des Titels (35 ist wie viele Zeilen es in diese Seite gibt + Zeilenabstände)
            y[1] = y[0] + howToPlayText[0].GetLength(0) + 2;//1. y-Wert des Textes
            y[2] = y[1] + howToPlayText[3].GetLength(0) * 2 + 2;//2. y-Wert des Textes
            y[3] = y[2] + howToPlayText[2].GetLength(0) * 2 + 1;//y-Wert des Hinweises unten
        }
    }
}

using System.Drawing;
using System.Runtime.InteropServices;
namespace Monsterkampf_Simulator
{
    internal class Lobby : Screen
    {
        #region Variables
        private string[] gameTitel;
        private string[] lobbyText;
        private int offSet;
        private int selected;
        private void SetValues()
        {
            gameTitel = [
                        "   _____                             __                   __                              _____ ",
            "  /     \\    ____    ____    _______/  |_   ____ _______ |  | _______     _____  ______ _/ ____\\",
            " /  \\ /  \\  /  _ \\  /    \\  /  ___/\\   __\\_/ __ \\\\_  __ \\|  |/ /\\__  \\   /     \\ \\____ \\\\   __\\ ",
            "/    Y    \\(  <_> )|   |  \\ \\___ \\  |  |  \\  ___/ |  | \\/|    <  / __ \\_|  Y Y  \\|  |_> >|  |   ",
            "\\____|__  / \\____/ |___|  //____  > |__|   \\___  >|__|   |__|_ \\(____  /|__|_|  /|   __/ |__|   ",
            "        \\/              \\/      \\/             \\/             \\/     \\/       \\/ |__|           ",
            "                 _________ __                  __            __                                 ",
            "                /   _____/|__|  _____   __ __ |  |  _____  _/  |_  ____ _______                 ",
            "                \\_____  \\ |  | /     \\ |  |  \\|  |  \\__  \\ \\   __\\/  _ \\\\_  __ \\                ",
            "                /        \\|  ||  Y Y  \\|  |  /|  |__ / __ \\_|  | (  <_> )|  | \\/                ",
            "               /_______  /|__||__|_|  /|____/ |____/(____  /|__|  \\____/ |__|                   ",
            "                       \\/           \\/                   \\/                                     "];
            lobbyText = ["START", "HOW TO PLAY", "CREDITS"];
            selected = 0;
        }
        #endregion

        public override Screen Start()
        {
            SetValues();
            ResizeWindow(windowSize[0], windowSize[1]);
            SetColors();
            Console.Clear();
            Console.CursorVisible = true;

            PrintGameTitel();
            GetLobbyInput();

            if (selected == 0)
            {
                MonsterSettings monsterSettings = new MonsterSettings();
                return monsterSettings;
            }
            else if (selected == 1)
            {
                HowToPlay howToPlay = new HowToPlay();
                return howToPlay;
            }
            else if (selected == 2)
            {
                Credits credits = new Credits();
                return credits;
            }
            return this;
        }

        private void PrintGameTitel()
        {
            offSet = -7;
            for (int i = 0; i < 12; i++)
            {
                PrintText(gameTitel[i], ConsoleColor.Red, CenterTextX(gameTitel[i]), CenterTextY(offSet));
                offSet++;
            }
        }

        private void GetLobbyInput()
        {
            offSet = 7;
            selected = 0;
            for (int i = 0; i < 3; i++)
            {
                PrintText(lobbyText[i], defaultFColor, CenterTextX(lobbyText[i]), CenterTextY(offSet));
                offSet++;
            }
            offSet = 7;
            while (true)
            {
                SetColors(true);
                string toPrint = "<" + lobbyText[selected] + ">";
                PrintText(toPrint, selectedFColor, CenterTextX(toPrint), CenterTextY(offSet + selected));

                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow && selected > 0)
                {
                    PrintUnselected(" " + lobbyText[selected] + " ");
                    selected--;
                }
                else if (key.Key == ConsoleKey.DownArrow && selected < 2)
                {
                    PrintUnselected(" " + lobbyText[selected] + " ");
                    selected++;
                }
                else if (key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Spacebar)
                {
                    break;
                }
            }
        }

        private void PrintUnselected(string _text)
        {
            SetColors();
            PrintText(_text, defaultFColor, CenterTextX(_text), CenterTextY(offSet + selected));
        }
    }
}

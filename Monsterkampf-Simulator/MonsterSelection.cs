﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsterkampf_Simulator
{
    internal class MonsterSelection
    {
        private static string selectionSettings = @"Choose Player 1 Monster
";
        public static void PrintMonsterSelection() 
        {
            Lobby.SetColorsToDefault();
            Lobby.PrintText(selectionSettings, Lobby.defaultFColor, Lobby.CenterText(selectionSettings), 3);
            
            Monster Orc = new Monster(1, 200, 20, 5, 3);
            Monster Troll = new Monster(2, 150, 15, 10, 5);
            Monster Goblin = new Monster(3, 100, 20, 0, 10);
        }
    }
}

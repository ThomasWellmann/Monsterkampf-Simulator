using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsterkampf_Simulator
{
    internal class Program
    {
        public Lobby lobby;
        public MonsterSettings monsterSettings;
        public HowToPlay howToPlay;
        public Credits credits;
        public Simulation simulation;

        static void Main(string[] args)
        {
            Screen screen = new Lobby();
            do
            {
                screen = screen.Start();
            } while (screen != null);
        }
    }
}
//to do: Simulation non static
//GetMonsterStats in Monster packen
//reset Monsters values nach kampf
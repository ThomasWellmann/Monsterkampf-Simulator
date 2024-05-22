using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Monsterkampf_Simulator
{
    class Monster
    {
        public int type { get; set; }
        public int HP { get; set; }
        public int AP { get; set; }
        public int DP { get; set; }
        public int S { get; set; }

        public Monster(int _type, int _hp, int _ap, int _dp, int _s)
        {
            type = _type; 
            HP = _hp; 
            AP = _ap; 
            DP = _dp; 
            S = _s;
        }
    }
}

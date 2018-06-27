using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudServer.Entities
{
    class Mobile
    {
        public enum EXITS
        {
            UP = 0,
            DOWN = 1,
            N = 2,
            NE = 3,
            E = 4,
            SE = 5,
            S = 6,
            SW = 7,
            W = 8,
            NW = 9,
            IN = 10,
            OUT = 11,
            ENTER = 12
        }
        private long[] exits;

        public void move(short exit)
        {
            
        }
    }
}

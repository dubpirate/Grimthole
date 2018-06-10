using Grimthole.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimthole.NPCs
{
    class Bob : Npc
    {
        private readonly String name;
        private readonly int _x;
        private readonly int _y;
        public Bob(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
}

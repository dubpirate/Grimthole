using Grimthole.Interfaces;
using Grimthole.NPCs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimthole.Core
{
    public class Npc : INpc
    {
        public Npc()
        {

        }
        public String Name { get; protected set; }

        public int x { get; set; }

        public int y { get; set; }

    }
}

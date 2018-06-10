using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimthole.Interfaces
{
    /// <summary>
    /// This interfaces is for all the abilities anyone can learn
    /// </summary>
    public interface INpc
    {
        String Name { get; }

        int x { get; set; }

        int y { get; set; }

    }

}


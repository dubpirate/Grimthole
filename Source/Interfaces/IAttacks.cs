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
    public interface IAttacks
    {
        String Name { get; }

        int Damage { get; }

        float CoolDown { get; }

        float RecoveryTime { get; }

        void Tick();
    }

}

